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
            this.locationEdit = new System.Windows.Forms.TextBox();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // import
            // 
            this.import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.import.Font = new System.Drawing.Font("Segoe Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import.Location = new System.Drawing.Point(33, 165);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(124, 29);
            this.import.TabIndex = 0;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = false;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // connectionString
            // 
            this.connectionString.Location = new System.Drawing.Point(33, 34);
            this.connectionString.Multiline = true;
            this.connectionString.Name = "connectionString";
            this.connectionString.Size = new System.Drawing.Size(400, 38);
            this.connectionString.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connection String:";
            // 
            // location
            // 
            this.location.AutoSize = true;
            this.location.ForeColor = System.Drawing.Color.White;
            this.location.Location = new System.Drawing.Point(30, 97);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(96, 13);
            this.location.TabIndex = 3;
            this.location.Text = "Xml dump location:";
            // 
            // selectLocation
            // 
            this.selectLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.selectLocation.Location = new System.Drawing.Point(309, 115);
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
            this.progressBar1.Location = new System.Drawing.Point(0, 250);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(451, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // progressMessage
            // 
            this.progressMessage.AutoSize = true;
            this.progressMessage.ForeColor = System.Drawing.Color.Yellow;
            this.progressMessage.Location = new System.Drawing.Point(30, 218);
            this.progressMessage.Name = "progressMessage";
            this.progressMessage.Size = new System.Drawing.Size(93, 13);
            this.progressMessage.TabIndex = 6;
            this.progressMessage.Text = "Progress message";
            // 
            // locationEdit
            // 
            this.locationEdit.Location = new System.Drawing.Point(33, 115);
            this.locationEdit.Multiline = true;
            this.locationEdit.Name = "locationEdit";
            this.locationEdit.Size = new System.Drawing.Size(258, 29);
            this.locationEdit.TabIndex = 7;
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewReport.Font = new System.Drawing.Font("Segoe Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(310, 165);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(124, 29);
            this.btnViewReport.TabIndex = 8;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Visible = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(451, 273);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.locationEdit);
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
        private System.Windows.Forms.TextBox locationEdit;
        private System.Windows.Forms.Button btnViewReport;
    }
}

