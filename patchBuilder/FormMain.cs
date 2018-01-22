using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using SharpSvn;
using System.Xml;
using System.Xml.Serialization;

// Written By : Bruce Hodge 
// Date : Dec 2, 2016
// PatchBuilder uses SharpSVN to interface with SVN repositories
// Patch builder allows you to quickly build complex hand patches

namespace patchBuilder
{
    public partial class FormMain : Form
    {
        private FolderBrowserDialog dir = new FolderBrowserDialog();
        private List<string> tasks = new List<string>();
        private HashSet<string> files = new HashSet<string>();
        private HashSet<string> scripts = new HashSet<string>();
        private Dictionary<string, string> scriptDate = new Dictionary<string, string>();
        private Dictionary<string, HashSet<string>> fileMode = new Dictionary<string, HashSet<string>>();
        private Dictionary<string, string> sourceNames = new Dictionary<string, string>();
        private Dictionary<string, HashSet<string>> dlls = new Dictionary<string, HashSet<string>>();
        private System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEventArgs;
        private SvnClient svnClient = new SvnClient();
        private SVNLog svnLog = new SVNLog();
        private System.Collections.ObjectModel.Collection<SvnDiffSummaryEventArgs> diffSum;
        private Stopwatch stopWatch = new Stopwatch();
        private BackgroundWorker bg;
        private ProgressCounter progressCnt;
        private int cnt, maxCnt;
        private const string defaultSourceDir = "C:\\InfoEdSvn\\Internal";
        private bool error = false;
        private string sourceDir;

        public FormMain()
        {
            sourceNames.Add("alpha13", "test13");
            sourceNames.Add("alpha13e", "test13e");
            sourceNames.Add("alpha14", "test14");
            sourceNames.Add("alpha15", "test15");
            sourceNames.Add("alpha16", "test16");
            sourceNames.Add("beta13", "qa13");
            sourceNames.Add("beta13e", "qa13e");
            sourceNames.Add("beta14", "qa14");
            sourceNames.Add("beta15", "qa15");
            InitializeComponent();
            dataGridViewApplyOrder.KeyDown += dgv_KeyDown;
            dataGridViewApplyOrder.CellMouseClick += dgv_CellMouseClick;
            dataGridViewFiles.KeyDown += dgv_KeyDown;
            dataGridViewFiles.CellMouseClick += dgv_CellMouseClick;
            dataGridViewDlls.KeyDown += dgv_KeyDown;
            dataGridViewDlls.CellMouseClick += dgv_CellMouseClick;
            dataGridViewScripts.KeyDown += dgv_KeyDown;
            dataGridViewScripts.CellMouseClick += dgv_CellMouseClick;
        }

        private void textBoxSourceDir_Click(object sender, EventArgs e)
        {
            dir.SelectedPath = textBoxSourceDir.Text;
            dir.ShowDialog();
            textBoxSourceDir.Text = dir.SelectedPath;
            string[] seg = textBoxSourceDir.Text.Split('\\');
            if (seg.Length == 4)
            {
                sourceDir = seg[3].ToLower();
                displayMsg("Source Directory: " + sourceDir, false);
            }
        }

        private void textBoxDestinationDir_Click(object sender, EventArgs e)
        {
            dir.SelectedPath = textBoxDestinationDir.Text;
            dir.ShowDialog();
            textBoxDestinationDir.Text = dir.SelectedPath;
            textBoxPatchName.Enabled = true;
            string[] seg = textBoxDestinationDir.Text.Split('\\');
            if (seg.Length < 5) return;
            string destinationDir = seg[4];
            seg = seg[4].Split('_');
            textBoxPatchName.Text = textBoxDestinationDir.Text + "\\" + string.Join("_", seg.ToList().GetRange(0, seg.Length - 1)) + "-" + DateTime.Now.ToString("yyyyMMdd") + ".lst";
            seg = destinationDir.Split('_');
            textBoxSourceDir.Text = defaultSourceDir + "\\Beta" + Convert.ToInt32(seg[seg.Length - 1].Split('.')[0]);
            if (seg[seg.Length - 1].Contains("E")) textBoxSourceDir.Text += "E";
            
            if (File.Exists(textBoxPatchName.Text) && radioButtonPatchFile.Checked)
            {
                MessageBox.Show("Patch File " + textBoxPatchName.Text + " Already Exists! Please Remove/Rename before building Patch ");
                error = true;
            }
            textBoxPatchName.Visible = true;
            textBoxPatchName.Enabled = radioButtonPatchFile.Checked;
        }

        private void radioButtonClipboard_Click(object sender, EventArgs e)
        {
            textBoxPatchName.Enabled = false;
            checkBox7z.Checked = false;
        }

        private void radioButtonPatchFile_Click(object sender, EventArgs e)
        {

            textBoxPatchName.Enabled = true;
            checkBox7z.Checked = true;
        }

        private void labelTasks_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                richTextBoxTasks.Text = @"Ent-1412-017
Ent-1608-001
COI-1608-009
COI-1608-014
COI-1606-002
TT-1608-004
Ent-1608-006
COI-1610-001
COI-1001-001
Comp-1608-015
Ent-1611-019
COI-1611-008
Ent-1608-029
Ent-1701-010
Pre-1611-005
";
        }

        private bool parseLogMessage(SVNLogEntry logEntry)
        {
            progressBarSVN.Increment(1);
            string msg = logEntry.logMessage.ToLower().Trim();
            if (tasks.Any(msg.Contains)) return true;
            return false;
        }

        void progress(object sender, SvnProgressEventArgs e)
        {
            cnt = Convert.ToInt32(e.Progress);
            if (maxCnt > 0)
            {
                progressUpdate(Convert.ToInt32((float)cnt / maxCnt * 100), Color.Green);
            }
            Console.WriteLine("ProgressTotal: " + e.TotalProgress + ", Progress : " + e.Progress);
        }

        private void progressUpdate(int value, Color c)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    progressUpdate(value, c);
                }));
            }
            else
            {
                progressBarSVN.Value = value;
                progressBarSVN.BackColor = c;
            }
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            Uri path = (Uri)e.Argument;
            Console.WriteLine("Work Thread ID: " + Thread.CurrentThread.ManagedThreadId);
            svnClient.Progress += new EventHandler<SvnProgressEventArgs>(progress);
            bool result = svnClient.GetLog(path, out logEventArgs);
            svnClient.Progress -= progress;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressCnt.max = cnt;
            svnLog.logEntries.Clear();
            foreach (SvnLogEventArgs l in logEventArgs)
            {
                svnLog.logEntries.Add(new SVNLogEntry(l));
            }
            saveSVN2File();
            stopwatch("Loaded SVN from Source", false);
            processLogs();
        }

        private void killCache()
        {
            var dir = new DirectoryInfo("./");
            foreach (var file in dir.EnumerateFiles("*.cache"))
            {
                file.Delete();
            }
        }

        private void loadSVNFromSource()
        {
            killCache();
            stopwatch("Loading SVN from Source! Please Wait...", true);
            svnLog.updated = DateTime.Today;
            Uri targetUri = new Uri("svn://devsourcecontrol/AppSource/Internal/" + textBoxSourceDir.Text.Split('\\').Last<string>());
            maxCnt = progressCnt.max;
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync(targetUri);
        }

        private void loadSVNFromFile()
        {
            if (!checkBoxCacheSVN.Checked)
            {
                loadSVNFromSource();
                return;
            }
            stopwatch("Loading SVN from Cache File", true);
            using (Stream stream = File.Open(sourceDir + "_" + DateTime.Today.ToString("yyyyMMdd") + ".cache", FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                svnLog = (SVNLog)bformatter.Deserialize(stream);
            }
            processLogs();
        }

        private void saveSVN2File()
        {
            if (!checkBoxCacheSVN.Checked) return;
            stopwatch("Saving SVN to Cache File", true);
            using (Stream stream = File.Open(sourceDir + "_" + DateTime.Today.ToString("yyyyMMdd") + ".cache", FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, svnLog);
            }
        }

        private void getSvnLogs()
        {
            if (svnLog.updated == DateTime.Today)
            {
                processLogs();
                return;
            }
            if (logEventArgs != null) logEventArgs.Clear();
            if (File.Exists(sourceDir + "_" + DateTime.Today.ToString("yyyyMMdd") + ".cache") && checkBoxCacheSVN.Checked)
                loadSVNFromFile();
            else
                loadSVNFromSource();
        }

        private bool validSource(SVNPaths c)
        {
            if (c.path.ToLower().Contains(sourceDir) || c.path.ToLower().Contains(sourceNames[sourceDir])) return true;
            return false;
        }

        private void listFile7ZipCompress(string sourceName, string targetName)
        {
            stopwatch("Creating 7z Zip File", true);
            ProcessStartInfo p = new ProcessStartInfo();
            //p.UseShellExecute = false;
            //p.RedirectStandardError = true;
            //p.RedirectStandardOutput = true;
            p.WorkingDirectory = textBoxDestinationDir.Text;
            p.FileName = "7z.exe";
            p.Arguments = "a -i@\"" + sourceName + "\" \"" + targetName + "\"";
            //p.WindowStyle = ProcessWindowStyle.Hidden;
            Process x = Process.Start(p);            
            x.WaitForExit();
            /*if(x.ExitCode != 0)
            {
                //string stdout = x.StandardOutput.ReadToEnd();
                //MessageBox.Show(stdout);
                string stderr = x.StandardError.ReadToEnd();
                MessageBox.Show("Error:" + stderr);
            }*/
        }

        private void save7z(bool overRide = false)
        {
            if (!File.Exists(textBoxPatchName.Text) || !checkBox7z.Checked) return;// return if no list file
            string zipFileName = textBoxPatchName.Text.Substring(0, textBoxPatchName.Text.Length - 3) + "7z";
            if (overRide)
            {
                listFile7ZipCompress(textBoxPatchName.Text, zipFileName);
                return;
            }

            if (File.Exists(zipFileName))
            {
                MessageBox.Show("File " + zipFileName + " Already Exists!\nPlease Remove/Rename before building Patch");
                error = true;
            }
            else
            {
                listFile7ZipCompress(textBoxPatchName.Text, zipFileName);
            }
        }

        private void checkBox7z_CheckedChanged(object sender, EventArgs e)
        {
            checkBox7z.Refresh();
            save7z();
        }

        private void dgv_CellMouseClick(Object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
            dgv.CurrentCell = clickedCell;  // Select the clicked cell
            string[] seg = new string[] { };
            string title = "";
            Dictionary<string, HashSet<string>> dict = null;
            contextMenuStrip1.Items.Clear();
            if (e.Button == MouseButtons.Right)
            {
                switch (dgv.Name)
                {
                    case "dataGridViewFiles":
                        seg = new string[1];
                        seg[0] = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["File_Name"].Value.ToString();
                        dict = fileMode;
                        title = "File History";
                        break;
                    case "dataGridViewDlls":
                        seg = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["fileName"].Value.ToString().Split('/');
                        dict = dlls;
                        title = "Compiled Files";
                        break;                   
                }
                if (seg == default(string[])) return;
                var menuLabel = new ToolStripLabel(title);
                menuLabel.Font = new Font("Courier New", 12, FontStyle.Bold);
                menuLabel.ForeColor = Color.BlueViolet;
                contextMenuStrip1.Items.Add(menuLabel);
                foreach (string item in dict[seg[seg.Length - 1]].OrderBy(x => x))
                {
                    contextMenuStrip1.Items.Add(item);
                }
                var relativeMousePosition = dgv.PointToClient(Cursor.Position);
                contextMenuStrip1.Show(dgv, relativeMousePosition);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            DataGridView dgv = (DataGridView)sender;
            string removed = "";

            switch (dgv.Name)
            {
                case "dataGridViewApplyOrder": removed = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["Revision"].Value.ToString();
                    //Delete all files,dlls (if no other revision uses them), and scripts for this revision here ...................
                    break;
                case "dataGridViewFiles": removed = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["File_name"].Value.ToString(); break;
                case "dataGridViewDlls": removed = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["fileName"].Value.ToString(); break;
                case "dataGridViewScripts": removed = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["sName"].Value.ToString(); break;
            }
            dgv.Rows.RemoveAt(dgv.SelectedCells[0].RowIndex);            
            dgv.Refresh();
        }

        private void stopwatch(string msg, bool start)
        {
            if (start)
            {
                stopWatch.Start();
                displayMsg(msg, false);
            }
            else
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                displayMsg(msg + " " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10), false);
            }
        }

        private void saveListFile(bool overRide = false)
        {
            if (!File.Exists(textBoxPatchName.Text) || overRide)
            {
                stopwatch("Creating List File", true);
                StreamWriter sw = new StreamWriter(textBoxPatchName.Text);
                sw.Write(buildPatchData());
                sw.Close();
                stopwatch("Created List File", false);
            }
            else
            {
                MessageBox.Show("File " + textBoxPatchName.Text + " Already Exists!\nPlease Remove/Rename before building Patch");
                error = true;
            }
        }

        private void checkBoxCacheSVN_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxCacheSVN.Checked)
            {
                killCache();
            }
        }

        private void filterScript(string dbType)
        {
            string pattern = "database/" + dbType;
                
            foreach (DataGridViewRow row in dataGridViewScripts.Rows)
            {
                if (row.Cells["Script"].Value != null)
                {
                    if (row.Cells["Script"].Value.ToString().Contains(pattern))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void radioButtonOra_Click(object sender, EventArgs e)
        {
            if (radioButtonOra.Checked)
            {
                filterScript("oracle");
            }
            else
            {
                filterScript("sql");
            }
        }

        private void radioButtonSql_Click(object sender, EventArgs e)
        {
            if (radioButtonSql.Checked)
            {
                filterScript("sql");
            }
            else
            {
                filterScript("oracle");
            }
        }

        private void tabControlBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlBox.SelectedIndex == 3)
            {
                if (dataGridViewScripts.Columns[0].HeaderCell.Value.ToString() != "Done")
                {
                    dataGridViewScripts.Columns.RemoveAt(0);
                    dataGridViewScripts.Columns.Insert(0, new DataGridViewCheckBoxColumn());
                    dataGridViewScripts.Columns[0].HeaderCell.Value = "Done";
                }
                groupBoxDbType.Visible = true;
            }
            else
                groupBoxDbType.Visible = false;
        }

        private void displayMsg(string msg, bool warning)
        {
            if (warning)
            {
                labelMessage.Visible = false;
                labelWarning.Visible = true;
                labelWarning.Text = msg;
                labelWarning.Refresh();
                error = true;
                pictureBoxLoading.Visible = false;
            }
            else
            {
                labelWarning.Visible = false;
                labelMessage.Visible = true;
                labelMessage.Text = msg;
                labelMessage.Refresh();
            }
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (textBoxSourceDir.Text == defaultSourceDir)
            {
                displayMsg("You must select Source Directory!", true);
                return;
            }
            if (textBoxDestinationDir.Text == "C:\\InfoEdSvn\\Clients\\HandPatches")
            {
                displayMsg("You must select Destination Directory!", true);
                return;
            }
            string[] seg = textBoxSourceDir.Text.Split('\\');
            if (seg.Length == 4)
            {
                sourceDir = seg[3].ToLower();
                displayMsg("Source Directory: " + sourceDir, false);
            }
            labelWarning.Visible = false;
            labelMessage.Visible = true;
            error = false;
            displayMsg("", false);
            dataGridViewApplyOrder.Rows.Clear();
            dataGridViewFiles.Rows.Clear();
            dataGridViewDlls.Rows.Clear();
            dataGridViewScripts.Rows.Clear();
            dataGridViewScripts.Columns.RemoveAt(0);
            dataGridViewScripts.Columns.Insert(0, new DataGridViewTextBoxColumn());
            dataGridViewScripts.Columns[0].HeaderCell.Value = "Cnt";
            files.Clear();
            dlls.Clear();
            scripts.Clear();

            tasks = richTextBoxTasks.Text.Split(Environment.NewLine.ToCharArray()).Select(x => x.ToLower().Trim()).Where(x => x.Length > 0).ToList<string>();
            if (tasks.Count == 0)
            {
                displayMsg("You must supply a list of Tasks!", true);
                return;
            }
            if (textBoxSourceDir.Text.Length > 0)
            {
                groupBoxInfo.Visible = false;
                pictureBoxLoading.Visible = true;
                if (checkBoxMerge.Checked)
                {
                    //svnClient.Merge(textBoxDestinationDir.Text,SvnTarget.FromString(textBoxSourceDir.Text),) Not yet implemented
                }
                progressCnt = new ProgressCounter(textBoxSourceDir.Text);
                getSvnLogs();
            }
        }
        private string buildPatchData()
        {
            string patchData = "";
            
            foreach (DataGridViewRow row in dataGridViewScripts.Rows)
            {
                if(row.Cells["sName"].Value != null) patchData += row.Cells["sName"].Value + "\n";                
            }

            foreach (DataGridViewRow row in dataGridViewFiles.Rows)
            {
                if (row.Cells["File_Name"].Value != null && row.Cells["Action"].Value.ToString() != "Delete" ) patchData += row.Cells["File_Name"].Value + "\n";                
            }

            foreach (DataGridViewRow row in dataGridViewDlls.Rows)
            {
                if (row.Cells["fileName"].Value != null) patchData += row.Cells["fileName"].Value + "\n";
            }
            
            return patchData;
        }

        private void textBoxSourceDir_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSourceDir.Text[textBoxSourceDir.Text.Length - 1].ToString().ToUpper() == "E")
                textBoxSourceDir.Text = textBoxSourceDir.Text.Substring(0, textBoxSourceDir.Text.Length -1) + "E";
        }

        private void processLogs()
        {
            string[] seg;
            int cnt = 0;
            progressBarSVN.Value = 0;
            stopwatch("Parsing Logs! Please Wait...", true);
            progressBarSVN.Maximum = svnLog.logEntries.Count;
            List<SVNLogEntry> logList = svnLog.logEntries.OrderBy(x => x.time).Where(x => parseLogMessage(x)).ToList();
            if (logList.Count == 0)
            {
                displayMsg("No Tasks by the Name Found. Check spelling/SVN log for typos!", true);
                return;
            }
            foreach (SVNLogEntry logEntry in logList)
            {
                int index = dataGridViewApplyOrder.Rows.Add();
                String date = logEntry.time.ToString("yyyy-MM-dd HH:mm:ss");
                dataGridViewApplyOrder.Rows[index].Cells["Date_Time"].Value = date;
                dataGridViewApplyOrder.Rows[index].Cells["Revision"].Value = logEntry.revision;
                dataGridViewApplyOrder.Rows[index].Cells["Author"].Value = logEntry.author;
                dataGridViewApplyOrder.Rows[index].Cells["LogEntry"].Value = logEntry.logMessage;
                foreach (SVNPaths f in logEntry.paths.Where(x => validSource(x)))
                {
                    //Console.WriteLine("Processing File: (" + f.action +") " + f.path);
                    if (f.nodeKind.ToString() != "Directory")
                    {
                        string path = f.path.ToLower().Trim();
                        seg = path.Split('/');
                        path = string.Join("/", seg.ToList().GetRange(4, seg.Length - 4)).Trim();
                        //Console.WriteLine("File: " + path);
                        if (seg[4] == "portalnet" && System.Text.RegularExpressions.Regex.IsMatch(path, ".vb$|.cs$|.csproj$|.vbproj$"))
                        {
                            if (!dlls.ContainsKey(seg[5] + ".dll")) dlls.Add(seg[5] + ".dll", new HashSet<string>());
                            dlls[seg[5] + ".dll"].Add(path);
                            //Console.WriteLine("Path: " + path + ", DLL: " + seg[5] + ".dll");
                        }
                        else
                        {
                            files.Add(path);
                            if (!fileMode.ContainsKey(path)) fileMode.Add(path, new HashSet<string>());
                            fileMode[path].Add("Date: " + date + ", Mode: " +f.action + ", Rev: " + logEntry.revision + ", Log: "+ logEntry.logMessage);
                            //Console.WriteLine("Mode: " + f.action + ", Date: " + date + ", Path: " + path);
                            if (System.Text.RegularExpressions.Regex.IsMatch(path, ".sql$"))
                            {
                                scripts.Add(path);
                                if (!scriptDate.ContainsKey(path))scriptDate.Add(path, date);//Save Script Creation Date!
                            }
                        }
                    }
                }
            }
            // Need to get first file in list and check its timestamp!!!!!!!!!!!!!!!!
            /*string enableDll = textBoxDestinationDir.Text + "\\PortalNet\\Enable\\bin\\Debug\\Enable.dll";

            if (dlls.Count > 0 && (!File.Exists(enableDll) || File.GetLastWriteTime(enableDll).Date != DateTime.Today))
            {
                displayMsg("You must compile before running Patch Builder!", true);
                groupBoxInfo.Visible = svnLog.logEntries.Count > 0;
                return;
            }*/

            FileCrawler fileCrawler = new FileCrawler(textBoxDestinationDir.Text);// way faster than recursively calling Directory.getFiles
            List<string> dllList = fileCrawler.find(dlls.Keys.ToList(), "*.dll");            
            cnt = 0;
            foreach (string path in files.OrderBy(x => x))
            {
                int fileIndex = dataGridViewFiles.Rows.Add();
                dataGridViewFiles.Rows[fileIndex].Cells["FileCount"].Value = ++cnt;
                string action = fileMode[path].FirstOrDefault().Split(',')[1].Split(':')[1].Trim();
                dataGridViewFiles.Rows[fileIndex].Cells["Action"].Value = action;
                dataGridViewFiles.Rows[fileIndex].Cells["File_Name"].Value = path;
                switch (action)
                {
                    case "Add":
                        dataGridViewFiles.Rows[fileIndex].Cells["Action"].Style.ForeColor = Color.DarkGreen;
                        dataGridViewFiles.Rows[fileIndex].Cells["File_Name"].Style.ForeColor = Color.DarkGreen;
                        break;
                    case "Delete":
                        dataGridViewFiles.Rows[fileIndex].Cells["Action"].Style.ForeColor = Color.DarkRed;
                        dataGridViewFiles.Rows[fileIndex].Cells["File_Name"].Style.ForeColor = Color.DarkRed;
                        break;
                }                
            }

            cnt = 0;
            foreach (string dll in dlls.Keys.OrderBy(x => x))
            {
                foreach (string path in dllList.Where(x => !x.ToLower().Contains("\\obj\\") && x.ToLower().Contains(dll)).OrderBy(x => x))
                {
                    seg = path.ToLower().Split('\\');
                    string relPath = string.Join("/", seg.ToList().GetRange(5, seg.Length - 5));                    
                    int index = dataGridViewDlls.Rows.Add();
                    dataGridViewDlls.Rows[index].Cells["dllCount"].Value = ++cnt;
                    dataGridViewDlls.Rows[index].Cells["fileName"].Value = relPath;
                }
            }
            
            cnt = 0;
            foreach (string path in scripts.ToList().OrderBy(x => x))
            {
                int fileIndex = dataGridViewScripts.Rows.Add();
                dataGridViewScripts.Rows[fileIndex].Cells[0].Value = ++cnt;
                dataGridViewScripts.Rows[fileIndex].Cells["sDate"].Value = scriptDate[path];
                dataGridViewScripts.Rows[fileIndex].Cells["sName"].Value = path;
            }

            stopwatch("Processed Log", false);
            groupBoxInfo.Visible = svnLog.logEntries.Count > 0;
            if (radioButtonPatchFile.Checked)
            {
                saveListFile();
                save7z();
            }
            else Clipboard.SetText(buildPatchData());
            pictureBoxLoading.Visible = false;
            if (error)
                displayMsg("Patch was not built!", true);
            else
                stopwatch("Patch is built!", false);
        }
    }

    [Serializable]
    class SVNLog
    {
        public DateTime updated = default(DateTime);
        public List<SVNLogEntry> logEntries = new List<SVNLogEntry>();
    }

    [Serializable]
    class SVNLogEntry
    {
        public DateTime time;
        public string revision, author, logMessage;
        public List<SVNPaths> paths;

        public SVNLogEntry(SvnLogEventArgs l)
        {
            time = l.Time;
            revision = l.Revision.ToString();
            author = l.Author;
            logMessage = l.LogMessage;
            paths = new List<SVNPaths>();
            foreach (SvnChangeItem f in l.ChangedPaths)
            {
                paths.Add(new SVNPaths(f.Action.ToString(), f.NodeKind.ToString(), f.Path, revision));
            }
        }
    }

    [Serializable]
    class SVNPaths
    {
        public string action;
        public string nodeKind;
        public string path;
        public string revision;

        public SVNPaths(string a, string n, string p, string r)
        {
            action = a;
            nodeKind = n;
            path = p;
            revision = r;
        }
    }

    [Serializable]
    class ProgressCounter
    {
        private Dictionary<string, int> maxCount = new Dictionary<string, int>();
        private string path;

        public ProgressCounter(string p)
        {
            path = p;
            using (Stream stream = File.Open("progress.bin", FileMode.OpenOrCreate))
            {
                if (stream.Length > 0)
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    maxCount = (Dictionary<string, int>)bformatter.Deserialize(stream);
                }
            }
            if (!maxCount.Keys.Contains(path)) maxCount[path] = 0;
        }

        public int max
        {
            get
            {
                return maxCount[path];
            }
            set
            {
                maxCount[path] = value;
                using (Stream stream = File.Open("progress.bin", FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, maxCount);
                }
            }
        }
    }
}
