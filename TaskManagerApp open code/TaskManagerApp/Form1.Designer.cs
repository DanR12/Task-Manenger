namespace TaskManagerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listViewTasks = new ListView();
            textBoxTask = new TextBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonMarkComplete = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            label1 = new Label();
            label2 = new Label();
            dateTimePickerDeadline = new DateTimePicker();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            showUpcomingTasksToolStripMenuItem = new ToolStripMenuItem();
            label3 = new Label();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // listViewTasks
            // 
            listViewTasks.Location = new Point(14, 14);
            listViewTasks.Margin = new Padding(4, 3, 4, 3);
            listViewTasks.Name = "listViewTasks";
            listViewTasks.Size = new Size(676, 346);
            listViewTasks.TabIndex = 0;
            listViewTasks.UseCompatibleStateImageBehavior = false;
            listViewTasks.View = View.Details;
            // 
            // textBoxTask
            // 
            textBoxTask.Location = new Point(14, 381);
            textBoxTask.Margin = new Padding(4, 3, 4, 3);
            textBoxTask.Name = "textBoxTask";
            textBoxTask.Size = new Size(233, 23);
            textBoxTask.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(254, 378);
            buttonAdd.Margin = new Padding(4, 3, 4, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(117, 27);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Додати";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(14, 410);
            buttonEdit.Margin = new Padding(4, 3, 4, 3);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(117, 27);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = "Редагувати";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(14, 443);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(117, 27);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Видалити";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonMarkComplete
            // 
            buttonMarkComplete.Location = new Point(139, 411);
            buttonMarkComplete.Margin = new Padding(4, 3, 4, 3);
            buttonMarkComplete.Name = "buttonMarkComplete";
            buttonMarkComplete.Size = new Size(117, 27);
            buttonMarkComplete.TabIndex = 5;
            buttonMarkComplete.Text = "Виконано";
            buttonMarkComplete.UseVisualStyleBackColor = true;
            buttonMarkComplete.Click += buttonMarkComplete_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(574, 450);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(117, 27);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Зберегти";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(574, 378);
            buttonLoad.Margin = new Padding(4, 3, 4, 3);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(117, 27);
            buttonLoad.TabIndex = 7;
            buttonLoad.Text = "Завантажити";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(14, 508);
            textBoxSearch.Margin = new Padding(4, 3, 4, 3);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(233, 23);
            textBoxSearch.TabIndex = 8;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(254, 505);
            buttonSearch.Margin = new Padding(4, 3, 4, 3);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(117, 27);
            buttonSearch.TabIndex = 9;
            buttonSearch.Text = "Пошук";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 362);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 10;
            label1.Text = "Назва завдання:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 489);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 11;
            label2.Text = "Пошук:";
            // 
            // dateTimePickerDeadline
            // 
            dateTimePickerDeadline.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePickerDeadline.Format = DateTimePickerFormat.Custom;
            dateTimePickerDeadline.Location = new Point(385, 381);
            dateTimePickerDeadline.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerDeadline.Name = "dateTimePickerDeadline";
            dateTimePickerDeadline.ShowCheckBox = true;
            dateTimePickerDeadline.Size = new Size(181, 23);
            dateTimePickerDeadline.TabIndex = 12;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Text = "Менеджер завдань";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { showUpcomingTasksToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(189, 26);
            // 
            // showUpcomingTasksToolStripMenuItem
            // 
            showUpcomingTasksToolStripMenuItem.Name = "showUpcomingTasksToolStripMenuItem";
            showUpcomingTasksToolStripMenuItem.Size = new Size(188, 22);
            showUpcomingTasksToolStripMenuItem.Text = "Показати найближчі";
            showUpcomingTasksToolStripMenuItem.Click += showUpcomingTasksToolStripMenuItem_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(382, 362);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 13;
            label3.Text = "Дедлайн:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 543);
            Controls.Add(label3);
            Controls.Add(dateTimePickerDeadline);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxSearch);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonMarkComplete);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxTask);
            Controls.Add(listViewTasks);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Менеджер завдань";
            FormClosing += Form1_FormClosing;
            Resize += Form1_Resize;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView listViewTasks;
        private System.Windows.Forms.TextBox textBoxTask;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonMarkComplete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeadline;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showUpcomingTasksToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}