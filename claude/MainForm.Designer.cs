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
        private System.Windows.Forms.TextBox txtChatLog;

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
            this.txtChatLog = new System.Windows.Forms.TextBox();
            this.panelApiKey.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelApiKey
            // 
            this.panelApiKey.Controls.Add(this.txtApiKey);
            this.panelApiKey.Controls.Add(this.btnStartChat);
            this.panelApiKey.Location = new System.Drawing.Point(12, 12);
            this.panelApiKey.Name = "panelApiKey";
            this.panelApiKey.Size = new System.Drawing.Size(360, 100);
            this.panelApiKey.TabIndex = 0;
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(15, 15);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(330, 20);
            this.txtApiKey.TabIndex = 1;
            // 
            // btnStartChat
            // 
            this.btnStartChat.Location = new System.Drawing.Point(270, 50);
            this.btnStartChat.Name = "btnStartChat";
            this.btnStartChat.Size = new System.Drawing.Size(75, 23);
            this.btnStartChat.TabIndex = 0;
            this.btnStartChat.Text = "Start Chat";
            this.btnStartChat.UseVisualStyleBackColor = true;
            this.btnStartChat.Click += new System.EventHandler(this.btnStartChat_Click);
            // 
            // panelChat
            // 
            this.panelChat.Controls.Add(this.txtUserInput);
            this.panelChat.Controls.Add(this.btnSend);
            this.panelChat.Controls.Add(this.txtChatLog);
            this.panelChat.Location = new System.Drawing.Point(12, 118);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(360, 330);
            this.panelChat.TabIndex = 1;
            this.panelChat.Visible = false;
            // 
            // txtUserInput
            // 
            this.txtUserInput.Location = new System.Drawing.Point(15, 290);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(250, 20);
            this.txtUserInput.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(270, 290);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChatLog
            // 
            this.txtChatLog.Location = new System.Drawing.Point(15, 15);
            this.txtChatLog.Multiline = true;
            this.txtChatLog.Name = "txtChatLog";
            this.txtChatLog.ReadOnly = true;
            this.txtChatLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatLog.Size = new System.Drawing.Size(330, 260);
            this.txtChatLog.TabIndex = 0;
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
