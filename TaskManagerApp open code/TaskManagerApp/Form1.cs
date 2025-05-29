using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TaskManagerApp
{
    public partial class Form1 : Form
    {
        List<TaskItem> tasks = new List<TaskItem>();
        private System.Timers.Timer notificationTimer;
        private Dictionary<string, bool> notifiedTasks = new Dictionary<string, bool>();

        public Form1()
        {
            InitializeComponent();
            InitializeListView();
            InitializeNotificationTimer();
        }

        private void InitializeListView()
        {
            listViewTasks.View = View.Details;
            listViewTasks.FullRowSelect = true;
            listViewTasks.Columns.Add("Задача", 200);
            listViewTasks.Columns.Add("Статус", 100);
            listViewTasks.Columns.Add("Дедлайн", 150);
            listViewTasks.Columns.Add("Залишилось", 120);
        }

        private void InitializeNotificationTimer()
        {
            notificationTimer = new System.Timers.Timer(60000);
            notificationTimer.Elapsed += CheckDeadlines;
            notificationTimer.AutoReset = true;
            notificationTimer.Enabled = true;
        }

        private void CheckDeadlines(object sender, ElapsedEventArgs e)
        {
            foreach (var task in tasks.Where(t => !t.IsCompleted && t.Deadline.HasValue))
            {
                CheckTaskNotification(task);
            }
        }

        private void CheckTaskNotification(TaskItem task)
        {
            TimeSpan timeLeft = task.Deadline.Value - DateTime.Now;
            string taskKey = $"{task.Name}_{task.Deadline}";

            if (timeLeft.TotalMinutes <= 15 && timeLeft.TotalMinutes > 0)
            {
                if (!notifiedTasks.ContainsKey(taskKey)) notifiedTasks[taskKey] = false;

                if (!notifiedTasks[taskKey])
                {
                    if (timeLeft.TotalMinutes <= 15 && timeLeft.TotalMinutes > 10)
                    {
                        ShowNotification(task, 15);
                        notifiedTasks[taskKey] = true;
                    }
                    else if (timeLeft.TotalMinutes <= 10 && timeLeft.TotalMinutes > 5)
                    {
                        ShowNotification(task, 10);
                        notifiedTasks[taskKey] = true;
                    }
                    else if (timeLeft.TotalMinutes <= 5)
                    {
                        ShowNotification(task, 5);
                        notifiedTasks[taskKey] = true;
                    }
                }
            }
            UpdateTaskListView();
        }

        private void ShowNotification(TaskItem task, int minutes)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowNotification(task, minutes)));
                return;
            }

            notifyIcon.ShowBalloonTip(5000, "Дедлайн наближається!",
                $"Завдання '{task.Name}' має бути виконане через {minutes} хв.",
                ToolTipIcon.Info);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNewTask();
        }

        private void AddNewTask()
        {
            string taskName = textBoxTask.Text.Trim();
            if (!string.IsNullOrEmpty(taskName))
            {
                DateTime? deadline = dateTimePickerDeadline.Checked ? dateTimePickerDeadline.Value : (DateTime?)null;

                TaskItem task = new TaskItem
                {
                    Name = taskName,
                    IsCompleted = false,
                    Deadline = deadline,
                    CreationDate = DateTime.Now
                };

                tasks.Add(task);
                AddTaskToListView(task);
                textBoxTask.Clear();
                SortTasksByDeadline();
            }
            else
            {
                MessageBox.Show("Введіть назву завдання", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddTaskToListView(TaskItem task)
        {
            ListViewItem item = new ListViewItem(task.Name)
            {
                Tag = task
            };

            item.SubItems.Add(task.IsCompleted ? "Виконано" : "В процесі");
            item.SubItems.Add(task.Deadline.HasValue ? task.Deadline.Value.ToString("g") : "Без дедлайну");

            if (task.Deadline.HasValue && !task.IsCompleted)
            {
                TimeSpan timeLeft = task.Deadline.Value - DateTime.Now;
                item.SubItems.Add(timeLeft.TotalMinutes > 0 ? $"{timeLeft:hh\\:mm\\:ss}" : "Просрочено");
                item.ForeColor = timeLeft.TotalMinutes < 60 ? System.Drawing.Color.Red :
                                 (timeLeft.TotalMinutes < 1440 ? System.Drawing.Color.Orange : System.Drawing.Color.Black);
            }
            else
            {
                item.SubItems.Add("");
            }

            listViewTasks.Items.Add(item);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditSelectedTask();
        }

        private void EditSelectedTask()
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewTasks.SelectedItems[0];
                TaskItem task = (TaskItem)selectedItem.Tag;

                string newTaskName = Interaction.InputBox("Введіть нову назву:", "Редагування", task.Name);

                if (!string.IsNullOrEmpty(newTaskName))
                {
                    task.Name = newTaskName;
                    DateTime? newDeadline = ShowDeadlineDialog(task.Deadline);
                    if (newDeadline != task.Deadline)
                    {
                        task.Deadline = newDeadline;
                        notifiedTasks.Remove($"{task.Name}_{task.Deadline}");
                    }
                    UpdateTaskListView();
                    SortTasksByDeadline();
                }
            }
            else
            {
                MessageBox.Show("Виберіть завдання для редагування", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DateTime? ShowDeadlineDialog(DateTime? currentDeadline)
        {
            using (var form = new Form())
            {
                // Код диалогового вікна для дедлайну
                return currentDeadline;
            }
        }

        private void SortTasksByDeadline()
        {
            tasks = tasks.OrderBy(t => t.IsCompleted)
                        .ThenBy(t => t.Deadline.HasValue ? 0 : 1)
                        .ThenBy(t => t.Deadline ?? DateTime.MaxValue)
                        .ToList();
            UpdateTaskListView();
        }

        private void UpdateTaskListView()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateTaskListView));
                return;
            }

            listViewTasks.BeginUpdate();
            listViewTasks.Items.Clear();
            foreach (TaskItem task in tasks)
            {
                AddTaskToListView(task);
            }
            listViewTasks.EndUpdate();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedTask();
        }

        private void DeleteSelectedTask()
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewTasks.SelectedItems[0];
                TaskItem task = (TaskItem)selectedItem.Tag;
                tasks.Remove(task);
                listViewTasks.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Виберіть завдання для видалення", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonMarkComplete_Click(object sender, EventArgs e)
        {
            MarkTaskAsComplete();
        }

        private void MarkTaskAsComplete()
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewTasks.SelectedItems[0];
                TaskItem task = (TaskItem)selectedItem.Tag;
                task.IsCompleted = true;
                task.CompletionDate = DateTime.Now;
                UpdateTaskListView();
                SortTasksByDeadline();
            }
            else
            {
                MessageBox.Show("Виберіть завдання", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveTasksToFile();
        }

        private void SaveTasksToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText("tasks.json", json);
                MessageBox.Show("Збережено!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadTasksFromFile();
        }

        private void LoadTasksFromFile()
        {
            try
            {
                if (File.Exists("tasks.json"))
                {
                    string json = File.ReadAllText("tasks.json");
                    tasks = JsonSerializer.Deserialize<List<TaskItem>>(json);
                    notifiedTasks.Clear();
                    UpdateTaskListView();
                    SortTasksByDeadline();
                }
                else
                {
                    MessageBox.Show("Файл не знайдено", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchTasks();
        }

        private void SearchTasks()
        {
            string query = textBoxSearch.Text.Trim().ToLower();
            foreach (ListViewItem item in listViewTasks.Items)
            {
                var task = (TaskItem)item.Tag;
                item.BackColor = task.Name.ToLower().Contains(query) ?
                    System.Drawing.Color.Yellow : System.Drawing.Color.White;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void showUpcomingTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUpcomingTasks();
        }

        private void ShowUpcomingTasks()
        {
            var upcoming = tasks
                .Where(t => !t.IsCompleted && t.Deadline.HasValue && t.Deadline > DateTime.Now)
                .OrderBy(t => t.Deadline)
                .Take(5)
                .ToList();

            string message = upcoming.Any() ?
                string.Join("\n", upcoming.Select(t =>
                    $"{t.Name} - {t.Deadline:g} (залишилось: {t.Deadline - DateTime.Now:hh\\:mm})")) :
                "Немає майбутніх завдань";

            MessageBox.Show(message, "Найближчі завдання", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notificationTimer?.Stop();
            notificationTimer?.Dispose();
        }
    }

    public class TaskItem
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}