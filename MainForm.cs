using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SoSlow.Properties;
using System.Xml;
using System.Threading;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Globalization;

namespace SoSlow {
    public partial class MainForm : Form {

        Settings settings;

        public MainForm() {
            InitializeComponent();

            settings = Settings.Default;

            SetProgressMessage("");
            progressBar1.Visible = false;

            location.Text = settings.DataLocation;

            RefreshGrid();


            connectionString.Text = settings.ConnectionString;
        }

        private void RefreshGrid() {
            if (Directory.Exists(location.Text)) {
                listView.Items.Clear();
                foreach (var folder in Directory.GetDirectories(location.Text)) {
                    ListViewItem item = new ListViewItem(Path.GetFileName(folder));
                    var size = CalculateFolderSize(folder);
                    double sizeInMb = (((double)size) / 1024.0) / 1024.0;
                    string sizeText = sizeInMb.ToString("###.## MB");
                    item.SubItems.Add(sizeText);
                    item.SubItems.Add(GuessDBNameFromFolder(folder));
                    listView.Items.Add(item);
                }
            }
        }

        static string GuessDBNameFromFolder(string folder) {
            string name = Path.GetFileName(folder);

            if (name.Contains("SO")) {
                name = "StackOverflow";
            }
            else if (name.Contains("SU")) {
                name = "SuperUser";
            }
            else if (name.Contains("META")) {
                name = "Meta";
            } else if (name.Contains("SF")) {
                name = "ServerFault";
            } else {
                var split = name.Split(' ');
                name = split[split.Length - 1];
            }

            return name;
        }


        static long CalculateFolderSize(string folder) {
            long folderSize = 0;
            try {
                //Checks if the path is valid or not
                if (!Directory.Exists(folder))
                    return folderSize;
                else {
                    try {
                        foreach (string file in Directory.GetFiles(folder)) {
                            if (File.Exists(file)) {
                                FileInfo finfo = new FileInfo(file);
                                folderSize += finfo.Length;
                            }
                        }

                        foreach (string dir in Directory.GetDirectories(folder))
                            folderSize += CalculateFolderSize(dir);
                    } catch (NotSupportedException e) {
                        Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                    }
                }
            } catch (UnauthorizedAccessException e) {
                Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
            }
            return folderSize;
        }

        private void selectLocation_Click(object sender, EventArgs e) {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                location.Text = folderBrowserDialog1.SelectedPath;
                RefreshGrid();
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (settings != null) {
                settings.DataLocation = location.Text;
                settings.ConnectionString = connectionString.Text;
                settings.Save();
            }
            base.OnClosing(e);
        }

        void SetProgressMessage(string message) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)(() => SetProgressMessage(message)));
            } else {
                progressMessage.Text = message;
            }
        }

        string baseProgressMessage = "";

        void SetProgress(int count) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)(() => SetProgress(count)));
            } else {
                progressMessage.Text = baseProgressMessage + string.Format("{0} rows imported", count);
            }
        }

        class DBInfo {
            public DBInfo(SqlConnection connection, string sourceFolder, string connectionString) {
                Connection = connection;
                SourceFolder = sourceFolder;
                ConnectionString = connectionString;
            }
            public SqlConnection Connection { get; private set; }
            public string SourceFolder { get;  private set; }
            public string ConnectionString { get; private set; }
        }

        private void import_Click(object sender, EventArgs e) {

            import.Enabled = false;

            var dbs = new List<DBInfo>();
            foreach (ListViewItem item in listView.Items) {
                if (item.Checked) {
                    string str = connectionString.Text;
                    
                    var start = str.IndexOf("Database=");
                    if (start < 0) { 
                        start = str.IndexOf("Initial Catalog=");
                    }
                    var stop = str.IndexOf(";", start);

                    str = str.Substring(0, start) + "Database=" + item.SubItems[2].Text + str.Substring(stop);

                    var path = Path.Combine(location.Text, item.Text);

                    var info = new DBInfo(new SqlConnection(str), path, str);
                    
                    dbs.Add(info); 
                }
            }

            var importers = new List<Importer>();

            foreach (var db in dbs) {
                
                db.Connection.Open();
                CreateDB(db.Connection);

                string[] files = new string[] { "comments", "badges", "posts", "users", "votes" };

                

                foreach (var file in files) {
                    Importer importer = new Importer(
                        Path.Combine(db.SourceFolder, string.Format("{0}.xml", file)),
                        TitleCase(file),
                        db.Connection
                    );
                    importer.Progress += new EventHandler<ProgressEventArgs>(importer_Progress);
                    importers.Add(importer);
                }  
            }
  
            

            ThreadPool.QueueUserWorkItem(_ =>
            {

                foreach (var importer in importers) {
                    baseProgressMessage = "Importing " + importer.TargetTable + " ";
                    importer.Import();
                }


                SetProgressMessage("Creating Tag Refs!");
                baseProgressMessage = "Impoting tag refs";
                foreach (var db in dbs) {
                    ImportTagRefs(db.Connection, db.ConnectionString);
                }

                SetProgressMessage("Done !");
                EnableImportButton();
            });

        }

        private void ImportTagRefs(SqlConnection cnn, string connectionString) {

            SqlBulkCopy copy = new SqlBulkCopy(cnn, SqlBulkCopyOptions.TableLock, null);
            copy.DestinationTableName = "PostTags";
            copy.BatchSize = 5000;
            copy.NotifyAfter = 5000;
            copy.SqlRowsCopied += new SqlRowsCopiedEventHandler(copy_SqlRowsCopied);
            // connection objects strip out the password so cnn.ConnectionString does not work
            using (var reader = new TagReader(connectionString)) {
                copy.WriteToServer(reader);
            }
        }

        void copy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e) {
            importer_Progress(this, new ProgressEventArgs() { RowsImported = (int)e.RowsCopied });
        }

        private void CreateDB(SqlConnection cnn) {
            using (var cmd = cnn.CreateCommand()) {
                cmd.CommandText = LoadResource("SoSlow.RecreateDB.sql");
                cmd.ExecuteNonQuery();
            }
        }


        private string TitleCase(string name) {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name);
        }

        private void EnableImportButton() {
            if (InvokeRequired) {
                Invoke((MethodInvoker)(() => EnableImportButton()));
            } else {
                import.Enabled = true;
            }
        }

        private string LoadResource(string resource) {

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)) {
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        void importer_Progress(object sender, ProgressEventArgs e) {
            SetProgress(e.RowsImported);
        }



    }
}
