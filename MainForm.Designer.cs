namespace SoSlow {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.import = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.connectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.location = new System.Windows.Forms.Label();
            this.selectLocation = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressMessage = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbRebuildPostTagsOnly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(366, 511);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(73, 35);
            this.import.TabIndex = 0;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // connectionString
            // 
            this.connectionString.Location = new System.Drawing.Point(170, 41);
            this.connectionString.Multiline = true;
            this.connectionString.Name = "connectionString";
            this.connectionString.Size = new System.Drawing.Size(288, 161);
            this.connectionString.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connection String:";
            // 
            // location
            // 
            this.location.AutoSize = true;
            this.location.Location = new System.Drawing.Point(46, 243);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(165, 13);
            this.location.TabIndex = 3;
            this.location.Text = "( Select your data dump location )";
            // 
            // selectLocation
            // 
            this.selectLocation.Location = new System.Drawing.Point(334, 235);
            this.selectLocation.Name = "selectLocation";
            this.selectLocation.Size = new System.Drawing.Size(124, 29);
            this.selectLocation.TabIndex = 4;
            this.selectLocation.Text = "Select Location...";
            this.selectLocation.UseVisualStyleBackColor = true;
            this.selectLocation.Click += new System.EventHandler(this.selectLocation_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 568);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(488, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // progressMessage
            // 
            this.progressMessage.AutoSize = true;
            this.progressMessage.Location = new System.Drawing.Point(30, 533);
            this.progressMessage.Name = "progressMessage";
            this.progressMessage.Size = new System.Drawing.Size(93, 13);
            this.progressMessage.TabIndex = 6;
            this.progressMessage.Text = "Progress message";
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(33, 301);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(425, 161);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Source";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 63;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Destination";
            this.columnHeader3.Width = 184;
            // 
            // cbRebuildPostTagsOnly
            // 
            this.cbRebuildPostTagsOnly.AutoSize = true;
            this.cbRebuildPostTagsOnly.Location = new System.Drawing.Point(33, 489);
            this.cbRebuildPostTagsOnly.Name = "cbRebuildPostTagsOnly";
            this.cbRebuildPostTagsOnly.Size = new System.Drawing.Size(127, 17);
            this.cbRebuildPostTagsOnly.TabIndex = 8;
            this.cbRebuildPostTagsOnly.Text = "Only rebuild post tags";
            this.cbRebuildPostTagsOnly.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 591);
            this.Controls.Add(this.cbRebuildPostTagsOnly);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.progressMessage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.selectLocation);
            this.Controls.Add(this.location);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectionString);
            this.Controls.Add(this.import);
            this.Name = "MainForm";
            this.Text = "So Slow ... Stack Overflow database importer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button import;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox connectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label location;
        private System.Windows.Forms.Button selectLocation;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressMessage;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox cbRebuildPostTagsOnly;
    }
}

