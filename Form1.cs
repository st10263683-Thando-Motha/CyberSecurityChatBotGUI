/*
 * Cybersecurity Awareness Chatbot
 * Part 2 Assignment
 * 
 * Code Attribution:
 * - Microsoft Learn (Windows Forms, SoundPlayer, C# basics)
 * - GeeksforGeeks (chatbot logic, dictionaries, random responses)
 * - W3Schools (C# syntax reference)
 * - StackOverflow (debugging WinForms events)
 * - OpenAI ChatGPT used as a learning assistant for guidance,
 *   debugging support, and code structuring.
 * 
 * All code has been reviewed, adapted, and implemented by the student.
 */

using System;
using System.Media;
using System.Windows.Forms;

namespace CyberSecurityChatBotGUI
{
    public partial class Form1 : Form
    {
        private ChatBot bot = new ChatBot();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // PLAY VOICE GREETING
            try
            {
                SoundPlayer player = new SoundPlayer("welcome.wav");
                player.Play();
            }
            catch
            {
                MessageBox.Show("Voice greeting file not found.");
            }

            // DARK THEME
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            rtbChat.BackColor = System.Drawing.Color.Black;
            rtbChat.ForeColor = System.Drawing.Color.Lime;

            txtInput.BackColor = System.Drawing.Color.Black;
            txtInput.ForeColor = System.Drawing.Color.White;

            btnSend.BackColor = System.Drawing.Color.DodgerBlue;
            btnSend.ForeColor = System.Drawing.Color.White;

            // USER MEMORY
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:");
            string topic = Microsoft.VisualBasic.Interaction.InputBox(
                "What cybersecurity topic interests you? (password/phishing/privacy)");

            bot.SetUserName(name);
            bot.SetFavouriteTopic(topic);

            // ASCII HEADER
            rtbChat.AppendText("====================================\n");
            rtbChat.AppendText(" CYBERSECURITY AWARENESS CHATBOT\n");
            rtbChat.AppendText("====================================\n\n");

            // WELCOME MESSAGE
            rtbChat.AppendText($"Bot: Welcome {name}! ");
            rtbChat.AppendText($"I’ll remember your interest in {topic}.\n\n");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();

            // INPUT VALIDATION
            if (string.IsNullOrEmpty(input))
            {
                rtbChat.AppendText("Bot: Please type something.\n\n");
                return;
            }

            // DISPLAY USER MESSAGE
            rtbChat.AppendText("You: " + input + "\n");

            // GET BOT RESPONSE
            string response = bot.GetResponse(input);

            // DISPLAY BOT RESPONSE
            rtbChat.AppendText("Bot: " + response + "\n\n");

            // AUTO SCROLL
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();

            // CLEAR INPUT
            txtInput.Clear();
        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {
            // AUTO SCROLL WHEN TEXT CHANGES
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();
        }
    }
}