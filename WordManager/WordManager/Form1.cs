using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace WordManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_importText_Click(object sender, EventArgs e)
        {
            WorkingCode();
        }

        private void WorkingCode()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|" + "Comma-Delimited Files (*.csv)|*.csv|All Files (*.*)|*.*";

            lblStatus.ForeColor = Color.Green; //reset label
            lblStatus.Text = "Processing..., please wait!";

            string content;
            string ContextHolder = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundWorker1.RunWorkerAsync(ContextHolder); // Seting -> Progres Bar 

                content = openFileDialog.FileName;
                ContextHolder = File.ReadAllText(content);
            }

            /// <summary>
            /// Only ANSI input! It is not necessary to encoding.
            ///System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            ///string input1 = File.ReadAllText(filePath, Encoding.GetEncoding(1252));
            /// </summary>


            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                lblStatus.Text = "Busy processing, please wait";
            }

            Editing editing = new Editing();
            String reHolderRegex = editing.RegexSelector(ContextHolder);

            String allWords = reHolderRegex;
            String[] wordsArray = allWords.Split(' ');

            List<WordCounter> wordCounters = new List<WordCounter>();

            try
            {
                foreach (string w in wordsArray)
                {
                    WordCounter? foundWord = wordCounters.Find(x => x.Word == w);
                    if (foundWord == null)
                    {
                        wordCounters.Add(new WordCounter(w, 1));
                    }
                    else
                    {
                        foundWord.Frequency++;
                    }
                }
                wordCounters.Sort((Left, Right) => Left.Frequency.CompareTo(Right.Frequency)); //Sort List

                foreach (WordCounter word in wordCounters)
                {
                    String[] rowItem = new string[] { word.Word, word.Frequency.ToString() };
                    listView1.Items.Add(new ListViewItem(rowItem)); // ListView -> Items ListItem obj.
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally(){}
        }


        private void btn_abortProcess_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync(); //If User Klik na Abort, backgroundWorker1.CancelAsync -> close process.
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 1; i <= 100; i++)
            {
                backgroundWorker1.ReportProgress(i); // Use the BackgroundWorker.ReportProgress method to report the % complete

                if (backgroundWorker1.CancellationPending)  // If the BackgroundWorker.CancellationPending property is true, cancel
                {
                    //e.Cancel = true;                          
                    backgroundWorker1.ReportProgress(0);
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            //e.Result = sum;
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //lblStatus.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                backgroundWorker1.CancelAsync(); //to close in Lauf background-Operations
                MessageBox.Show("Successfully processed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }
            lblStatus.Text = "Processing";
            lblStatus.ForeColor = Color.Black; //

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}