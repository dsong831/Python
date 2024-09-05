using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ClaudeChatApp
{
    public partial class MainForm : Form
    {
        private const string API_URL = "https://api.anthropic.com/v1/messages";
        private const string API_VERSION = "2023-06-01";
        private const string MODEL = "claude-3-sonnet-20240229";

        private string apiKey;
        private HttpClient httpClient;

        public MainForm()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            ApplyDarkTheme();
        }

        private void ApplyDarkTheme()
        {
            BackColor = Color.Black;
            ForeColor = Color.White;

            foreach (Control control in Controls)
            {
                ApplyDarkThemeToControl(control);
            }
        }

        private void ApplyDarkThemeToControl(Control control)
        {
            control.BackColor = Color.Black;
            control.ForeColor = Color.White;

            if (control is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.White;
            }
            else if (control is RichTextBox richTextBox)
            {
                richTextBox.BackColor = Color.Black;
                richTextBox.ForeColor = Color.White;
            }

            foreach (Control childControl in control.Controls)
            {
                ApplyDarkThemeToControl(childControl);
            }
        }

        private void btnStartChat_Click(object sender, EventArgs e)
        {
            apiKey = txtApiKey.Text;
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("Please enter an API key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            panelApiKey.Visible = false;
            panelChat.Visible = true;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtUserInput.Text.Trim();
            if (string.IsNullOrEmpty(userMessage)) return;

            AddToChatLog("You", userMessage, Color.LightBlue);
            txtUserInput.Clear();

            try
            {
                string response = await CallClaudeApi(userMessage);
                AddToChatLog("Claude", response, Color.LightGreen);
            }
            catch (Exception ex)
            {
                AddToChatLog("Error", ex.Message, Color.Red);
            }
        }

        private async Task<string> CallClaudeApi(string message)
        {
            var payload = new JObject
            {
                ["model"] = MODEL,
                ["max_tokens"] = 1000,
                ["messages"] = new JArray
                {
                    new JObject
                    {
                        ["role"] = "user",
                        ["content"] = message
                    }
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, API_URL)
            {
                Content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json")
            };

            request.Headers.Add("x-api-key", apiKey);
            request.Headers.Add("anthropic-version", API_VERSION);

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var responseJson = JObject.Parse(responseBody);

            return responseJson["content"][0]["text"].ToString();
        }

        private void AddToChatLog(string speaker, string message, Color backgroundColor)
        {
            rtxtChatLog.SelectionStart = rtxtChatLog.TextLength;
            rtxtChatLog.SelectionLength = 0;

            rtxtChatLog.SelectionColor = Color.White;
            rtxtChatLog.SelectionBackColor = backgroundColor;
            rtxtChatLog.AppendText($"{speaker}:
{message}

");

            rtxtChatLog.SelectionStart = rtxtChatLog.TextLength;
            rtxtChatLog.ScrollToCaret();
        }

        private void btnClearSession_Click(object sender, EventArgs e)
        {
            SaveSessionToFile();
            rtxtChatLog.Clear();
        }

        private void SaveSessionToFile()
        {
            string fileName = $"ChatSession_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            File.WriteAllText(fileName, rtxtChatLog.Text);
            MessageBox.Show($"Session saved to {fileName}", "Session Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnSend.Focus();
                e.Handled = true;
            }
        }

        private void btnReturnToApiKey_Click(object sender, EventArgs e)
        {
            panelChat.Visible = false;
            panelApiKey.Visible = true;
            txtApiKey.Clear();
            rtxtChatLog.Clear();
        }
    }
}