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
            this.SuspendLayout();
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(360, 166);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(73, 35);
            this.import.TabIndex = 0;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // connectionString
            // 
            this.connectionString.Location = new System.Drawing.Point(153, 41);
            this.connectionString.Name = "connectionString";
            this.connectionString.Size = new System.Drawing.Size(280, 20);
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
            this.location.Location = new System.Drawing.Point(30, 99);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(165, 13);
            this.location.TabIndex = 3;
            this.location.Text = "( Select your data dump location )";
            // 
            // selectLocation
            // 
            this.selectLocation.Location = new System.Drawing.Point(309, 91);
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
            this.progressBar1.Location = new System.Drawing.Point(0, 231);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(453, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // progressMessage
            // 
            this.progressMessage.AutoSize = true;
            this.progressMessage.Location = new System.Drawing.Point(12, 215);
            this.progressMessage.Name = "progressMessage";
            this.progressMessage.Size = new System.Drawing.Size(93, 13);
            this.progressMessage.TabIndex = 6;
            this.progressMessage.Text = "Progress message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 254);
            this.Controls.Add(this.progressMessage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.selectLocation);
            this.Controls.Add(this.location);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectionString);
            this.Controls.Add(this.import);
            this.Name = "Form1";
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
    }
}

