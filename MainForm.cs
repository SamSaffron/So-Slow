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
            connectionString.Text = settings.ConnectionString;
        }

        private void selectLocation_Click(object sender, EventArgs e) {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                location.Text = folderBrowserDialog1.SelectedPath;
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

        private void import_Click(object sender, EventArgs e) {

            import.Enabled = false;

            // reset db and open connection

            SqlConnection cnn = new SqlConnection(connectionString.Text);
            cnn.Open();
            using (var cmd = cnn.CreateCommand()) {
                cmd.CommandText = LoadResource("SoSlow.RecreateDB.sql");
                cmd.ExecuteNonQuery();
            }

            string[] files = new string[] { "comments", "badges", "posts", "users", "votes" };

            var importers = new List<Importer>();

            foreach (var file in files) {
                Importer importer = new Importer(
                    string.Format("c:\\temp\\{0}.xml",file), TitleCase(file), cnn);
                importer.Progress += new EventHandler<ProgressEventArgs>(importer_Progress);
                importers.Add(importer);
            }

           

            ThreadPool.QueueUserWorkItem(_ => {

                foreach (var importer in importers) {
                    baseProgressMessage = "Importing " + importer.TargetTable + " ";
                    importer.Import(); 
                }


                SetProgressMessage("Importing cc_wiki_field!");
                ImportCCWiki(cnn); 

                SetProgressMessage("Done !");
                EnableImportButton(); 
            });

        }

        private void ImportCCWiki(SqlConnection cnn) {

            using (var cmd = cnn.CreateCommand()) {
                cmd.CommandText = LoadResource("SoSlow.AddCCWikiColumn.sql");
                cmd.ExecuteNonQuery();
            }

            // this is done for performance
            var sb = new StringBuilder();
            sb.Append("UPDATE Posts SET IsWiki = 1 WHERE Id in (");
            var list = LoadResource("SoSlow.community_wiki.list");
            sb.Append(string.Join(",", list.Split('\n')));
            sb.Append(")");

            using (var cmd = cnn.CreateCommand()) {
                cmd.CommandText = sb.ToString();
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
