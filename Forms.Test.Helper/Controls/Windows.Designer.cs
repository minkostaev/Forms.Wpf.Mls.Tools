﻿namespace Forms.Test.Helper.Controls
{
    partial class Windows
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chBxSystemTray = new CheckBox();
            chBxAlwaysOnTop = new CheckBox();
            chBxShowInTaskbar = new CheckBox();
            chBxWindowsStartup = new CheckBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // chBxSystemTray
            // 
            chBxSystemTray.AutoSize = true;
            chBxSystemTray.Location = new Point(3, 3);
            chBxSystemTray.Name = "chBxSystemTray";
            chBxSystemTray.Size = new Size(146, 19);
            chBxSystemTray.TabIndex = 0;
            chBxSystemTray.Text = "Show System Tray Icon";
            chBxSystemTray.UseVisualStyleBackColor = true;
            // 
            // chBxAlwaysOnTop
            // 
            chBxAlwaysOnTop.AutoSize = true;
            chBxAlwaysOnTop.Location = new Point(3, 28);
            chBxAlwaysOnTop.Name = "chBxAlwaysOnTop";
            chBxAlwaysOnTop.Size = new Size(104, 19);
            chBxAlwaysOnTop.TabIndex = 1;
            chBxAlwaysOnTop.Text = "Always On Top";
            chBxAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // chBxShowInTaskbar
            // 
            chBxShowInTaskbar.AutoSize = true;
            chBxShowInTaskbar.Location = new Point(3, 53);
            chBxShowInTaskbar.Name = "chBxShowInTaskbar";
            chBxShowInTaskbar.Size = new Size(110, 19);
            chBxShowInTaskbar.TabIndex = 2;
            chBxShowInTaskbar.Text = "Show In Taskbar";
            chBxShowInTaskbar.UseVisualStyleBackColor = true;
            // 
            // chBxWindowsStartup
            // 
            chBxWindowsStartup.AutoSize = true;
            chBxWindowsStartup.Location = new Point(3, 78);
            chBxWindowsStartup.Name = "chBxWindowsStartup";
            chBxWindowsStartup.Size = new Size(174, 19);
            chBxWindowsStartup.TabIndex = 3;
            chBxWindowsStartup.Text = "Launch on Windows startup";
            chBxWindowsStartup.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(59, 139);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Windows
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(chBxWindowsStartup);
            Controls.Add(chBxShowInTaskbar);
            Controls.Add(chBxAlwaysOnTop);
            Controls.Add(chBxSystemTray);
            Name = "Windows";
            Size = new Size(400, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chBxSystemTray;
        private CheckBox chBxAlwaysOnTop;
        private CheckBox chBxShowInTaskbar;
        private CheckBox chBxWindowsStartup;
        private Button button1;
    }
}
