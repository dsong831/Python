namespace ClaudeChatApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelApiKey;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Button btnStartChat;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtxtChatLog;
        private System.Windows.Forms.Button btnClearSession;
        private System.Windows.Forms.Button btnReturnToApiKey;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelApiKey = new System.Windows.Forms.Panel();
            this.panelChat = new System.Windows.Forms.Panel();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.btnStartChat = new System.Windows.Forms.Button();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtxtChatLog = new System.Windows.Forms.RichTextBox();
            this.btnClearSession = new System.Windows.Forms.Button();
            this.btnReturnToApiKey = new System.Windows.Forms.Button();
            this.panelApiKey.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelApiKey
            // 
            this.panelApiKey.Controls.Add(this.txtApiKey);
            this.panelApiKey.Controls.Add(this.btnStartChat);
            this.panelApiKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApiKey.Location = new System.Drawing.Point(0, 0);
            this.panelApiKey.Name = "panelApiKey";
            this.panelApiKey.Size = new System.Drawing.Size(384, 461);
            this.panelApiKey.TabIndex = 0;
            // 
            // txtApiKey
            // 
            this.txtApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiKey.Location = new System.Drawing.Point(42, 200);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(300, 20);
            this.txtApiKey.TabIndex = 1;
            // 
            // btnStartChat
            // 
            this.btnStartChat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartChat.Location = new System.Drawing.Point(152, 240);
            this.btnStartChat.Name = "btnStartChat";
            this.btnStartChat.Size = new System.Drawing.Size(80, 23);
            this.btnStartChat.TabIndex = 0;
            this.btnStartChat.Text = "Start Chat";
            this.btnStartChat.UseVisualStyleBackColor = true;
            this.btnStartChat.Click += new System.EventHandler(this.btnStartChat_Click);
            // 
            // panelChat
            // 
            this.panelChat.Controls.Add(this.txtUserInput);
            this.panelChat.Controls.Add(this.btnSend);
            this.panelChat.Controls.Add(this.rtxtChatLog);
            this.panelChat.Controls.Add(this.btnClearSession);
            this.panelChat.Controls.Add(this.btnReturnToApiKey);
            this.panelChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChat.Location = new System.Drawing.Point(0, 0);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(384, 461);
            this.panelChat.TabIndex = 1;
            this.panelChat.Visible = false;
            // 
            // txtUserInput
            // 
            this.txtUserInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserInput.Location = new System.Drawing.Point(12, 400);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(279, 20);
            this.txtUserInput.TabIndex = 2;
            this.txtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(297, 398);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtxtChatLog
            // 
            this.rtxtChatLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtChatLog.Location = new System.Drawing.Point(12, 41);
            this.rtxtChatLog.Name = "rtxtChatLog";
            this.rtxtChatLog.ReadOnly = true;
            this.rtxtChatLog.Size = new System.Drawing.Size(360, 351);
            this.rtxtChatLog.TabIndex = 0;
            this.rtxtChatLog.Text = "";
            // 
            // btnClearSession
            // 
            this.btnClearSession.Location = new System.Drawing.Point(12, 12);
            this.btnClearSession.Name = "btnClearSession";
            this.btnClearSession.Size = new System.Drawing.Size(100, 23);
            this.btnClearSession.TabIndex = 3;
            this.btnClearSession.Text = "Clear Session";
            this.btnClearSession.UseVisualStyleBackColor = true;
            this.btnClearSession.Click += new System.EventHandler(this.btnClearSession_Click);
            // 
            // btnReturnToApiKey
            // 
            this.btnReturnToApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnToApiKey.Location = new System.Drawing.Point(272, 12);
            this.btnReturnToApiKey.Name = "btnReturnToApiKey";
            this.btnReturnToApiKey.Size = new System.Drawing.Size(100, 23);
            this.btnReturnToApiKey.TabIndex = 4;
            this.btnReturnToApiKey.Text = "Change API Key";
            this.btnReturnToApiKey.UseVisualStyleBackColor = true;
            this.btnReturnToApiKey.Click += new System.EventHandler(this.btnReturnToApiKey_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.panelApiKey);
            this.Name = "MainForm";
            this.Text = "Claude Chat App";
            this.panelApiKey.ResumeLayout(false);
            this.panelApiKey.PerformLayout();
            this.panelChat.ResumeLayout(false);
            this.panelChat.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}