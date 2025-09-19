namespace WinFormsApp1
{
    public partial class XtraMainForm : DevExpress.XtraEditors.XtraForm
    {
        public XtraMainForm()
        {
            InitializeComponent();
        }

        Dictionary<string, string> msgList = new Dictionary<string, string>()
        {
            { "merhaba", "Merhaba. Bugün nasılsınız?" },
            { "nasılsın", "Teşekkür ederim, iyiyim. Siz nasılsınız?" },
            { "hava nasıl", "Bugün hava güneşli ve sıcak." },
            { "teşekkürler", "Rica ederim! Başka bir şey var mı?" },
            { "görüşürüz", "Görüşmek üzere! İyi günler!" },
            { "yardım", "Size nasıl yardımcı olabilirim?" },
            {"nartaş madencilik", "Gümüştaş Madencilik alt işveren olarak , altın madenciliği süreçlerinde yer altından çıkarma işlemlerini yüksek güvenlik ve verimlilikle yerine getiriyoruz. " },
            { "saat", DateTime.Now.ToShortTimeString() },
            { "tarih", DateTime.Now.ToShortDateString() + " " + DateTime.Now.DayOfWeek}
        };
        Dictionary<string, string> actList = new Dictionary<string, string>()
        {
            { "notepad", "notepad.exe" },
            { "hesap makinesi", "calc.exe" }
        };

        private void XtraMainForm_Load(object sender, EventArgs e)
        {
            rchChat.SelectionColor = System.Drawing.Color.Green;
            rchChat.SelectionStart = rchChat.Text.Length;
            rchChat.ScrollToCaret();
            rchChat.ReadOnly = true;
            rchChat.AppendText("ChatBot: Merhaba! Size nasıl yardımcı olabilirim?\n");
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            string userMessage = txtUserMsg.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
                return;

            AppendMessage("Siz: " + userMessage, System.Drawing.Color.Blue);

            txtUserMsg.Text = string.Empty;

            string botResponse = GetBotResponse(userMessage);
            AppendMessage("ChatBot: " + botResponse, System.Drawing.Color.Green);
        }
        private void AppendMessage(string message, System.Drawing.Color textColor)
        {
            rchChat.SelectionStart = rchChat.TextLength;
            rchChat.SelectionColor = textColor;
            rchChat.AppendText(message + "\n");
        }
        private string GetBotResponse(string message)
        {
            foreach (var key in msgList.Keys)
            {
                if (message.ToLower().Contains(key))
                {
                    return msgList[key];
                }
            }
            foreach (var key in actList.Keys)
            {
                if (message.ToLower().Contains(key))
                {
                    return OpenProgram(actList[key]);
                }
            }
            //if (msgList.ContainsKey(message.ToLower()))
            //{
            //    return msgList[message.ToLower()];
            //}
            //else
            //{
            //    return "Üzgünüm, bunu anlamıyorum.";
            //}
            return "Üzgünüm, bunu anlamıyorum.";
        }
        private void txtUserMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter tuşunun yeni satır eklemesini engelle
                btnSendMsg.PerformClick(); // Gönder butonuna tıklama işlemini tetikle
            }
        }
        private string OpenProgram(string programPath)
        {
            try
            {
                System.Diagnostics.Process.Start(programPath);
                return "Program açıldı: " + programPath;
            }
            catch (Exception ex)
            {
                AppendMessage("ChatBot: Program açılamadı. Hata: " + ex.Message, System.Drawing.Color.Red);
                return "Program açılamadı.";
            }
        }
    }
}