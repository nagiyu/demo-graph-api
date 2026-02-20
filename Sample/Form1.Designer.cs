namespace Sample
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnLogin = new Button();
            btnLogout = new Button();
            lblStatus = new Label();
            rtbInfo = new RichTextBox();
            SuspendLayout();

            // btnLogin
            btnLogin.Location = new Point(12, 12);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 32);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "ログイン";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;

            // btnLogout
            btnLogout.Enabled = false;
            btnLogout.Location = new Point(120, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 32);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "ログアウト";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 56);
            lblStatus.Name = "lblStatus";
            lblStatus.TabIndex = 2;
            lblStatus.Text = "状態: -";

            // rtbInfo
            rtbInfo.BackColor = SystemColors.Control;
            rtbInfo.BorderStyle = BorderStyle.FixedSingle;
            rtbInfo.Font = new Font("Consolas", 10F);
            rtbInfo.Location = new Point(12, 80);
            rtbInfo.Name = "rtbInfo";
            rtbInfo.ReadOnly = true;
            rtbInfo.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbInfo.Size = new Size(560, 270);
            rtbInfo.TabIndex = 3;
            rtbInfo.Text = "";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(btnLogin);
            Controls.Add(btnLogout);
            Controls.Add(lblStatus);
            Controls.Add(rtbInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Graph API 委任型ログイン サンプル";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnLogout;
        private Label lblStatus;
        private RichTextBox rtbInfo;
    }
}
