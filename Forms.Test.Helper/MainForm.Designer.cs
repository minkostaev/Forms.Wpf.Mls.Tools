namespace Forms.Test.Helper
{
    partial class MainForm
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
            tabControl1 = new TabControl();
            tbPgFolders = new TabPage();
            tbPgWindows = new TabPage();
            tbPgLanguage = new TabPage();
            tbPgRequests = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbPgFolders);
            tabControl1.Controls.Add(tbPgWindows);
            tabControl1.Controls.Add(tbPgLanguage);
            tabControl1.Controls.Add(tbPgRequests);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tbPgFolders
            // 
            tbPgFolders.Location = new Point(4, 24);
            tbPgFolders.Name = "tbPgFolders";
            tbPgFolders.Padding = new Padding(3);
            tbPgFolders.Size = new Size(792, 422);
            tbPgFolders.TabIndex = 0;
            tbPgFolders.Text = "Folders";
            tbPgFolders.UseVisualStyleBackColor = true;
            // 
            // tbPgWindows
            // 
            tbPgWindows.Location = new Point(4, 24);
            tbPgWindows.Name = "tbPgWindows";
            tbPgWindows.Padding = new Padding(3);
            tbPgWindows.Size = new Size(792, 422);
            tbPgWindows.TabIndex = 1;
            tbPgWindows.Text = "Windows";
            tbPgWindows.UseVisualStyleBackColor = true;
            // 
            // tbPgLanguage
            // 
            tbPgLanguage.Location = new Point(4, 24);
            tbPgLanguage.Name = "tbPgLanguage";
            tbPgLanguage.Padding = new Padding(3);
            tbPgLanguage.Size = new Size(792, 422);
            tbPgLanguage.TabIndex = 2;
            tbPgLanguage.Text = "Language";
            tbPgLanguage.UseVisualStyleBackColor = true;
            // 
            // tbPgRequests
            // 
            tbPgRequests.Location = new Point(4, 24);
            tbPgRequests.Name = "tbPgRequests";
            tbPgRequests.Padding = new Padding(3);
            tbPgRequests.Size = new Size(792, 422);
            tbPgRequests.TabIndex = 3;
            tbPgRequests.Text = "Requests";
            tbPgRequests.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "MainForm";
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tbPgFolders;
        private TabPage tbPgWindows;
        private TabPage tbPgLanguage;
        private TabPage tbPgRequests;
    }
}