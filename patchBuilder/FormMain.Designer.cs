namespace patchBuilder
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelTasks = new System.Windows.Forms.Label();
            this.textBoxSourceDir = new System.Windows.Forms.TextBox();
            this.textBoxDestinationDir = new System.Windows.Forms.TextBox();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxTasks = new System.Windows.Forms.RichTextBox();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxDbType = new System.Windows.Forms.GroupBox();
            this.radioButtonOra = new System.Windows.Forms.RadioButton();
            this.radioButtonSql = new System.Windows.Forms.RadioButton();
            this.tabControlBox = new System.Windows.Forms.TabControl();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.dataGridViewApplyOrder = new System.Windows.Forms.DataGridView();
            this.Done = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Date_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.FileCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDlls = new System.Windows.Forms.TabPage();
            this.dataGridViewDlls = new System.Windows.Forms.DataGridView();
            this.dllCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dllRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageScript = new System.Windows.Forms.TabPage();
            this.dataGridViewScripts = new System.Windows.Forms.DataGridView();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scriptRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxPatchName = new System.Windows.Forms.TextBox();
            this.radioButtonPatchFile = new System.Windows.Forms.RadioButton();
            this.radioButtonClipboard = new System.Windows.Forms.RadioButton();
            this.groupBoxPatch = new System.Windows.Forms.GroupBox();
            this.checkBox7z = new System.Windows.Forms.CheckBox();
            this.checkBoxCacheSVN = new System.Windows.Forms.CheckBox();
            this.progressBarSVN = new System.Windows.Forms.ProgressBar();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.checkBoxMerge = new System.Windows.Forms.CheckBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxDbType.SuspendLayout();
            this.tabControlBox.SuspendLayout();
            this.tabOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApplyOrder)).BeginInit();
            this.tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.tabDlls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDlls)).BeginInit();
            this.tabPageScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScripts)).BeginInit();
            this.groupBoxPatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTasks
            // 
            this.labelTasks.AutoSize = true;
            this.labelTasks.Location = new System.Drawing.Point(12, 9);
            this.labelTasks.Name = "labelTasks";
            this.labelTasks.Size = new System.Drawing.Size(42, 13);
            this.labelTasks.TabIndex = 1;
            this.labelTasks.Text = "Task(s)";
            this.labelTasks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelTasks_MouseClick);
            // 
            // textBoxSourceDir
            // 
            this.textBoxSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceDir.Location = new System.Drawing.Point(213, 37);
            this.textBoxSourceDir.Name = "textBoxSourceDir";
            this.textBoxSourceDir.Size = new System.Drawing.Size(580, 20);
            this.textBoxSourceDir.TabIndex = 2;
            this.textBoxSourceDir.Text = "C:\\InfoEdSvn\\Internal";
            this.textBoxSourceDir.Click += new System.EventHandler(this.textBoxSourceDir_Click);
            this.textBoxSourceDir.TextChanged += new System.EventHandler(this.textBoxSourceDir_TextChanged);
            // 
            // textBoxDestinationDir
            // 
            this.textBoxDestinationDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestinationDir.Location = new System.Drawing.Point(213, 63);
            this.textBoxDestinationDir.Name = "textBoxDestinationDir";
            this.textBoxDestinationDir.Size = new System.Drawing.Size(580, 20);
            this.textBoxDestinationDir.TabIndex = 3;
            this.textBoxDestinationDir.Text = "C:\\InfoEdSvn\\Clients\\HandPatches";
            this.textBoxDestinationDir.Click += new System.EventHandler(this.textBoxDestinationDir_Click);
            // 
            // buttonBuild
            // 
            this.buttonBuild.BackColor = System.Drawing.SystemColors.Info;
            this.buttonBuild.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBuild.Location = new System.Drawing.Point(15, 324);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(117, 23);
            this.buttonBuild.TabIndex = 4;
            this.buttonBuild.Text = "Build Patch";
            this.buttonBuild.UseVisualStyleBackColor = false;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Source";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Destination";
            // 
            // richTextBoxTasks
            // 
            this.richTextBoxTasks.Location = new System.Drawing.Point(15, 25);
            this.richTextBoxTasks.Name = "richTextBoxTasks";
            this.richTextBoxTasks.Size = new System.Drawing.Size(117, 293);
            this.richTextBoxTasks.TabIndex = 7;
            this.richTextBoxTasks.Text = "";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInfo.Controls.Add(this.groupBoxDbType);
            this.groupBoxInfo.Controls.Add(this.tabControlBox);
            this.groupBoxInfo.Location = new System.Drawing.Point(213, 151);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(580, 389);
            this.groupBoxInfo.TabIndex = 10;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            this.groupBoxInfo.Visible = false;
            // 
            // groupBoxDbType
            // 
            this.groupBoxDbType.Controls.Add(this.radioButtonOra);
            this.groupBoxDbType.Controls.Add(this.radioButtonSql);
            this.groupBoxDbType.Location = new System.Drawing.Point(425, 0);
            this.groupBoxDbType.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBoxDbType.Name = "groupBoxDbType";
            this.groupBoxDbType.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBoxDbType.Size = new System.Drawing.Size(145, 38);
            this.groupBoxDbType.TabIndex = 22;
            this.groupBoxDbType.TabStop = false;
            this.groupBoxDbType.Visible = false;
            // 
            // radioButtonOra
            // 
            this.radioButtonOra.AutoSize = true;
            this.radioButtonOra.Location = new System.Drawing.Point(8, 13);
            this.radioButtonOra.Name = "radioButtonOra";
            this.radioButtonOra.Size = new System.Drawing.Size(56, 17);
            this.radioButtonOra.TabIndex = 14;
            this.radioButtonOra.Text = "Oracle";
            this.radioButtonOra.UseVisualStyleBackColor = true;
            this.radioButtonOra.Click += new System.EventHandler(this.radioButtonOra_Click);
            // 
            // radioButtonSql
            // 
            this.radioButtonSql.AutoSize = true;
            this.radioButtonSql.Location = new System.Drawing.Point(67, 13);
            this.radioButtonSql.Name = "radioButtonSql";
            this.radioButtonSql.Size = new System.Drawing.Size(71, 17);
            this.radioButtonSql.TabIndex = 13;
            this.radioButtonSql.Text = "SqlServer";
            this.radioButtonSql.UseVisualStyleBackColor = true;
            this.radioButtonSql.Click += new System.EventHandler(this.radioButtonSql_Click);
            // 
            // tabControlBox
            // 
            this.tabControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlBox.Controls.Add(this.tabOrder);
            this.tabControlBox.Controls.Add(this.tabFiles);
            this.tabControlBox.Controls.Add(this.tabDlls);
            this.tabControlBox.Controls.Add(this.tabPageScript);
            this.tabControlBox.Location = new System.Drawing.Point(6, 20);
            this.tabControlBox.Name = "tabControlBox";
            this.tabControlBox.SelectedIndex = 0;
            this.tabControlBox.Size = new System.Drawing.Size(568, 368);
            this.tabControlBox.TabIndex = 1;
            this.tabControlBox.SelectedIndexChanged += new System.EventHandler(this.tabControlBox_SelectedIndexChanged);
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.dataGridViewApplyOrder);
            this.tabOrder.Location = new System.Drawing.Point(4, 22);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrder.Size = new System.Drawing.Size(560, 342);
            this.tabOrder.TabIndex = 0;
            this.tabOrder.Text = "Apply Order";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // dataGridViewApplyOrder
            // 
            this.dataGridViewApplyOrder.AllowUserToOrderColumns = true;
            this.dataGridViewApplyOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewApplyOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewApplyOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApplyOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Done,
            this.Date_Time,
            this.Revision,
            this.Author,
            this.LogEntry});
            this.dataGridViewApplyOrder.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewApplyOrder.Name = "dataGridViewApplyOrder";
            this.dataGridViewApplyOrder.RowHeadersWidth = 12;
            this.dataGridViewApplyOrder.Size = new System.Drawing.Size(548, 334);
            this.dataGridViewApplyOrder.TabIndex = 0;
            // 
            // Done
            // 
            this.Done.HeaderText = "Done";
            this.Done.Name = "Done";
            this.Done.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Done.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Done.Width = 58;
            // 
            // Date_Time
            // 
            this.Date_Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date_Time.HeaderText = "DateTime";
            this.Date_Time.Name = "Date_Time";
            this.Date_Time.Width = 78;
            // 
            // Revision
            // 
            this.Revision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Revision.HeaderText = "Revision";
            this.Revision.Name = "Revision";
            this.Revision.Width = 73;
            // 
            // Author
            // 
            this.Author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            this.Author.Width = 63;
            // 
            // LogEntry
            // 
            this.LogEntry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LogEntry.HeaderText = "LogEntry";
            this.LogEntry.Name = "LogEntry";
            this.LogEntry.Width = 74;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.dataGridViewFiles);
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(560, 342);
            this.tabFiles.TabIndex = 1;
            this.tabFiles.Text = "Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.AllowUserToOrderColumns = true;
            this.dataGridViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileCount,
            this.Action,
            this.File_name,
            this.fileRev});
            this.dataGridViewFiles.Location = new System.Drawing.Point(6, 4);
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowHeadersWidth = 12;
            this.dataGridViewFiles.ShowEditingIcon = false;
            this.dataGridViewFiles.Size = new System.Drawing.Size(548, 274);
            this.dataGridViewFiles.TabIndex = 1;
            // 
            // FileCount
            // 
            this.FileCount.HeaderText = "Cnt";
            this.FileCount.Name = "FileCount";
            this.FileCount.Width = 48;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Width = 62;
            // 
            // File_name
            // 
            this.File_name.HeaderText = "File";
            this.File_name.Name = "File_name";
            this.File_name.ReadOnly = true;
            this.File_name.Width = 48;
            // 
            // fileRev
            // 
            this.fileRev.HeaderText = "Revision";
            this.fileRev.Name = "fileRev";
            this.fileRev.ReadOnly = true;
            this.fileRev.Visible = false;
            this.fileRev.Width = 73;
            // 
            // tabDlls
            // 
            this.tabDlls.Controls.Add(this.dataGridViewDlls);
            this.tabDlls.Location = new System.Drawing.Point(4, 22);
            this.tabDlls.Name = "tabDlls";
            this.tabDlls.Size = new System.Drawing.Size(560, 342);
            this.tabDlls.TabIndex = 2;
            this.tabDlls.Text = "DLLs";
            this.tabDlls.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDlls
            // 
            this.dataGridViewDlls.AllowUserToOrderColumns = true;
            this.dataGridViewDlls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDlls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDlls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDlls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dllCount,
            this.fileName,
            this.dllRev});
            this.dataGridViewDlls.Location = new System.Drawing.Point(6, 4);
            this.dataGridViewDlls.Name = "dataGridViewDlls";
            this.dataGridViewDlls.RowHeadersWidth = 12;
            this.dataGridViewDlls.Size = new System.Drawing.Size(548, 274);
            this.dataGridViewDlls.TabIndex = 1;
            // 
            // dllCount
            // 
            this.dllCount.HeaderText = "Cnt";
            this.dllCount.Name = "dllCount";
            this.dllCount.Width = 48;
            // 
            // fileName
            // 
            this.fileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fileName.HeaderText = "File";
            this.fileName.Name = "fileName";
            this.fileName.Width = 48;
            // 
            // dllRev
            // 
            this.dllRev.HeaderText = "Revision";
            this.dllRev.Name = "dllRev";
            this.dllRev.ReadOnly = true;
            this.dllRev.Visible = false;
            this.dllRev.Width = 73;
            // 
            // tabPageScript
            // 
            this.tabPageScript.Controls.Add(this.dataGridViewScripts);
            this.tabPageScript.Location = new System.Drawing.Point(4, 22);
            this.tabPageScript.Name = "tabPageScript";
            this.tabPageScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScript.Size = new System.Drawing.Size(560, 342);
            this.tabPageScript.TabIndex = 3;
            this.tabPageScript.Text = "Scripts";
            this.tabPageScript.UseVisualStyleBackColor = true;
            // 
            // dataGridViewScripts
            // 
            this.dataGridViewScripts.AllowUserToOrderColumns = true;
            this.dataGridViewScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewScripts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Count,
            this.sDate,
            this.sName,
            this.scriptRev});
            this.dataGridViewScripts.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewScripts.Name = "dataGridViewScripts";
            this.dataGridViewScripts.RowHeadersWidth = 12;
            this.dataGridViewScripts.Size = new System.Drawing.Size(548, 330);
            this.dataGridViewScripts.TabIndex = 2;
            // 
            // Count
            // 
            this.Count.HeaderText = "Cnt";
            this.Count.Name = "Count";
            this.Count.Width = 48;
            // 
            // sDate
            // 
            this.sDate.HeaderText = "Date";
            this.sDate.Name = "sDate";
            this.sDate.Width = 55;
            // 
            // sName
            // 
            this.sName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sName.HeaderText = "Scripts";
            this.sName.Name = "sName";
            this.sName.Width = 64;
            // 
            // scriptRev
            // 
            this.scriptRev.HeaderText = "Revision";
            this.scriptRev.Name = "scriptRev";
            this.scriptRev.ReadOnly = true;
            this.scriptRev.Visible = false;
            this.scriptRev.Width = 73;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(213, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(70, 13);
            this.labelMessage.TabIndex = 11;
            this.labelMessage.Text = "Patch Builder";
            // 
            // textBoxPatchName
            // 
            this.textBoxPatchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPatchName.Location = new System.Drawing.Point(213, 125);
            this.textBoxPatchName.Name = "textBoxPatchName";
            this.textBoxPatchName.Size = new System.Drawing.Size(580, 20);
            this.textBoxPatchName.TabIndex = 12;
            this.textBoxPatchName.Visible = false;
            // 
            // radioButtonPatchFile
            // 
            this.radioButtonPatchFile.AutoSize = true;
            this.radioButtonPatchFile.Checked = true;
            this.radioButtonPatchFile.Location = new System.Drawing.Point(126, 15);
            this.radioButtonPatchFile.Name = "radioButtonPatchFile";
            this.radioButtonPatchFile.Size = new System.Drawing.Size(84, 17);
            this.radioButtonPatchFile.TabIndex = 13;
            this.radioButtonPatchFile.TabStop = true;
            this.radioButtonPatchFile.Text = "Copy To File";
            this.radioButtonPatchFile.UseVisualStyleBackColor = true;
            this.radioButtonPatchFile.Click += new System.EventHandler(this.radioButtonPatchFile_Click);
            // 
            // radioButtonClipboard
            // 
            this.radioButtonClipboard.AutoSize = true;
            this.radioButtonClipboard.Location = new System.Drawing.Point(8, 15);
            this.radioButtonClipboard.Name = "radioButtonClipboard";
            this.radioButtonClipboard.Size = new System.Drawing.Size(112, 17);
            this.radioButtonClipboard.TabIndex = 14;
            this.radioButtonClipboard.Text = "Copy To Clipboard";
            this.radioButtonClipboard.UseVisualStyleBackColor = true;
            this.radioButtonClipboard.Click += new System.EventHandler(this.radioButtonClipboard_Click);
            // 
            // groupBoxPatch
            // 
            this.groupBoxPatch.Controls.Add(this.radioButtonClipboard);
            this.groupBoxPatch.Controls.Add(this.radioButtonPatchFile);
            this.groupBoxPatch.Location = new System.Drawing.Point(213, 84);
            this.groupBoxPatch.Name = "groupBoxPatch";
            this.groupBoxPatch.Size = new System.Drawing.Size(211, 38);
            this.groupBoxPatch.TabIndex = 15;
            this.groupBoxPatch.TabStop = false;
            // 
            // checkBox7z
            // 
            this.checkBox7z.AutoSize = true;
            this.checkBox7z.Checked = true;
            this.checkBox7z.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7z.Location = new System.Drawing.Point(452, 98);
            this.checkBox7z.Name = "checkBox7z";
            this.checkBox7z.Size = new System.Drawing.Size(94, 17);
            this.checkBox7z.TabIndex = 16;
            this.checkBox7z.Text = "Create Zip File";
            this.checkBox7z.UseVisualStyleBackColor = true;
            this.checkBox7z.CheckedChanged += new System.EventHandler(this.checkBox7z_CheckedChanged);
            // 
            // checkBoxCacheSVN
            // 
            this.checkBoxCacheSVN.AutoSize = true;
            this.checkBoxCacheSVN.Checked = true;
            this.checkBoxCacheSVN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCacheSVN.Location = new System.Drawing.Point(564, 98);
            this.checkBoxCacheSVN.Name = "checkBoxCacheSVN";
            this.checkBoxCacheSVN.Size = new System.Drawing.Size(108, 17);
            this.checkBoxCacheSVN.TabIndex = 17;
            this.checkBoxCacheSVN.Text = "Cache SVN Logs";
            this.checkBoxCacheSVN.UseVisualStyleBackColor = true;
            this.checkBoxCacheSVN.CheckedChanged += new System.EventHandler(this.checkBoxCacheSVN_CheckedChanged);
            // 
            // progressBarSVN
            // 
            this.progressBarSVN.Location = new System.Drawing.Point(213, 24);
            this.progressBarSVN.Name = "progressBarSVN";
            this.progressBarSVN.Size = new System.Drawing.Size(580, 10);
            this.progressBarSVN.TabIndex = 18;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoading.Image")));
            this.pictureBoxLoading.Location = new System.Drawing.Point(187, 4);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLoading.TabIndex = 19;
            this.pictureBoxLoading.TabStop = false;
            this.pictureBoxLoading.Visible = false;
            // 
            // checkBoxMerge
            // 
            this.checkBoxMerge.AutoSize = true;
            this.checkBoxMerge.Location = new System.Drawing.Point(685, 98);
            this.checkBoxMerge.Name = "checkBoxMerge";
            this.checkBoxMerge.Size = new System.Drawing.Size(88, 17);
            this.checkBoxMerge.TabIndex = 20;
            this.checkBoxMerge.Text = "Merge Tasks";
            this.checkBoxMerge.UseVisualStyleBackColor = true;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(213, 9);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(83, 13);
            this.labelWarning.TabIndex = 21;
            this.labelWarning.Text = "Patch Builder";
            this.labelWarning.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 546);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.checkBoxMerge);
            this.Controls.Add(this.pictureBoxLoading);
            this.Controls.Add(this.progressBarSVN);
            this.Controls.Add(this.checkBoxCacheSVN);
            this.Controls.Add(this.checkBox7z);
            this.Controls.Add(this.groupBoxPatch);
            this.Controls.Add(this.textBoxPatchName);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.richTextBoxTasks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.textBoxDestinationDir);
            this.Controls.Add(this.textBoxSourceDir);
            this.Controls.Add(this.labelTasks);
            this.Name = "FormMain";
            this.Text = "Patch Builder";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxDbType.ResumeLayout(false);
            this.groupBoxDbType.PerformLayout();
            this.tabControlBox.ResumeLayout(false);
            this.tabOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApplyOrder)).EndInit();
            this.tabFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.tabDlls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDlls)).EndInit();
            this.tabPageScript.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScripts)).EndInit();
            this.groupBoxPatch.ResumeLayout(false);
            this.groupBoxPatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTasks;
        private System.Windows.Forms.TextBox textBoxSourceDir;
        private System.Windows.Forms.TextBox textBoxDestinationDir;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxTasks;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.DataGridView dataGridViewApplyOrder;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TabControl tabControlBox;
        private System.Windows.Forms.TabPage tabOrder;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private System.Windows.Forms.TabPage tabDlls;
        private System.Windows.Forms.DataGridView dataGridViewDlls;
        private System.Windows.Forms.TextBox textBoxPatchName;
        private System.Windows.Forms.RadioButton radioButtonPatchFile;
        private System.Windows.Forms.RadioButton radioButtonClipboard;
        private System.Windows.Forms.GroupBox groupBoxPatch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Done;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogEntry;
        private System.Windows.Forms.CheckBox checkBox7z;
        private System.Windows.Forms.CheckBox checkBoxCacheSVN;
        private System.Windows.Forms.ProgressBar progressBarSVN;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.CheckBox checkBoxMerge;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.TabPage tabPageScript;
        private System.Windows.Forms.DataGridView dataGridViewScripts;
        private System.Windows.Forms.GroupBox groupBoxDbType;
        private System.Windows.Forms.RadioButton radioButtonOra;
        private System.Windows.Forms.RadioButton radioButtonSql;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileRev;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllRev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sName;
        private System.Windows.Forms.DataGridViewTextBoxColumn scriptRev;
    }
}

