namespace Forms.Test.Helper.Controls
{
    partial class Requests
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
            txtUrl = new TextBox();
            btnSend = new Button();
            cbMethod = new ComboBox();
            lblResult = new Label();
            txtInBody = new TextBox();
            txtOutResult = new TextBox();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Dock = DockStyle.Top;
            txtUrl.Location = new Point(0, 0);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(400, 23);
            txtUrl.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(0, 23);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // cbMethod
            // 
            cbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMethod.FormattingEnabled = true;
            cbMethod.Location = new Point(81, 23);
            cbMethod.Name = "cbMethod";
            cbMethod.Size = new Size(75, 23);
            cbMethod.TabIndex = 2;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(162, 27);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(38, 15);
            lblResult.TabIndex = 3;
            lblResult.Text = "label1";
            // 
            // txtInBody
            // 
            txtInBody.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInBody.Location = new Point(0, 47);
            txtInBody.Multiline = true;
            txtInBody.Name = "txtInBody";
            txtInBody.Size = new Size(400, 121);
            txtInBody.TabIndex = 4;
            // 
            // txtOutResult
            // 
            txtOutResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutResult.Location = new Point(0, 170);
            txtOutResult.Multiline = true;
            txtOutResult.Name = "txtOutResult";
            txtOutResult.Size = new Size(400, 130);
            txtOutResult.TabIndex = 5;
            // 
            // Requests
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtOutResult);
            Controls.Add(txtInBody);
            Controls.Add(lblResult);
            Controls.Add(cbMethod);
            Controls.Add(btnSend);
            Controls.Add(txtUrl);
            Name = "Requests";
            Size = new Size(400, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private Button btnSend;
        private ComboBox cbMethod;
        private Label lblResult;
        private TextBox txtInBody;
        private TextBox txtOutResult;
    }
}
