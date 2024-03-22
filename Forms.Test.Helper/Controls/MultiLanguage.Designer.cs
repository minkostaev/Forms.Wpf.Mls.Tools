namespace Forms.Test.Helper.Controls
{
    partial class MultiLanguage
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
            btnEn = new Button();
            btnBg = new Button();
            btnNl = new Button();
            lbl = new Label();
            SuspendLayout();
            // 
            // btnEn
            // 
            btnEn.Location = new Point(3, 3);
            btnEn.Name = "btnEn";
            btnEn.Size = new Size(75, 23);
            btnEn.TabIndex = 0;
            btnEn.Text = "English";
            btnEn.UseVisualStyleBackColor = true;
            // 
            // btnBg
            // 
            btnBg.Location = new Point(84, 3);
            btnBg.Name = "btnBg";
            btnBg.Size = new Size(75, 23);
            btnBg.TabIndex = 1;
            btnBg.Text = "Български";
            btnBg.UseVisualStyleBackColor = true;
            // 
            // btnNl
            // 
            btnNl.Location = new Point(40, 87);
            btnNl.Name = "btnNl";
            btnNl.Size = new Size(100, 23);
            btnNl.TabIndex = 2;
            btnNl.Text = "Missing File Language";
            btnNl.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(40, 49);
            lbl.Name = "lbl";
            lbl.Size = new Size(38, 15);
            lbl.TabIndex = 3;
            lbl.Text = "label1";
            // 
            // MultiLanguage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl);
            Controls.Add(btnNl);
            Controls.Add(btnBg);
            Controls.Add(btnEn);
            Name = "MultiLanguage";
            Size = new Size(400, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEn;
        private Button btnBg;
        private Button btnNl;
        private Label lbl;
    }
}
