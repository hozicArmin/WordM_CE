namespace WordManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_importText = new Button();
            btn_abortProcess = new Button();
            listView1 = new ListView();
            Word = new ColumnHeader();
            Number = new ColumnHeader();
            openFileDialog1 = new OpenFileDialog();
            lblStatus = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // btn_importText
            // 
            btn_importText.Location = new Point(131, 29);
            btn_importText.Name = "btn_importText";
            btn_importText.Size = new Size(123, 37);
            btn_importText.TabIndex = 0;
            btn_importText.Text = "Import";
            btn_importText.UseVisualStyleBackColor = true;
            btn_importText.Click += btn_importText_Click;
            // 
            // btn_abortProcess
            // 
            btn_abortProcess.Location = new Point(437, 29);
            btn_abortProcess.Name = "btn_abortProcess";
            btn_abortProcess.Size = new Size(130, 37);
            btn_abortProcess.TabIndex = 1;
            btn_abortProcess.Text = "Abort";
            btn_abortProcess.UseVisualStyleBackColor = true;
            btn_abortProcess.Click += btn_abortProcess_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Word, Number });
            listView1.Location = new Point(11, 81);
            listView1.Name = "listView1";
            listView1.Size = new Size(706, 317);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Word
            // 
            Word.Text = "Word";
            Word.Width = 557;
            // 
            // Number
            // 
            Number.Text = "Number";
            Number.Width = 123;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 413);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(79, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Processing";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 442);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(150, 26);
            progressBar1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 487);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            Controls.Add(listView1);
            Controls.Add(btn_abortProcess);
            Controls.Add(btn_importText);
            Name = "Form1";
            Text = "Word Manager";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_importText;
        private Button btn_abortProcess;
        private ListView listView1;
        private OpenFileDialog openFileDialog1;
        private ColumnHeader Word;
        private ColumnHeader Number;
        private Label lblStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
    }
}