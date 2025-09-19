using DevExpress.Diagram.Core.Routing;
using OpenAI.Chat;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WinFormsApp1
{
    public partial class XtraMainForm : DevExpress.XtraEditors.XtraForm
    {
        public XtraMainForm()
        {
            InitializeComponent();
        }

        bool isGptModel = false;

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
            { "tarih", DateTime.Now.ToShortDateString() + " " + DateTime.Now.DayOfWeek},
            { "chatgpt", "gptModel"},
            { "botiq", "myModel"}
        };
        Dictionary<string, string> actList = new Dictionary<string, string>()
        {
            { "notepad", "notepad.exe" },
            { "hesap makinesi", "calc.exe" },
            { "internet tarayıcısı", "chrome.exe" },
            { "word", "winword.exe" },
            { "excel", "excel.exe" },
            { "powerpoint", "powerpnt.exe" },
            { "paint", "mspaint.exe" },
            { "dosya gezgini", "explorer.exe" },
            { "görev yöneticisi", "taskmgr.exe" },
            { "komut istemcisi", "cmd.exe" },
            { "powerShell", "powershell.exe" },
            { "müzik", "wmplayer.exe" },
            { "film", "msedge.exe" },
            { "zipped dosyalar", "explorer.exe" },
            { "google drive", "googledrivesync.exe" },
            { "spotify", "spotify.exe" },
            { "slack", "slack.exe" },
            { "discord", "discord.exe" },
            { "skype", "skype.exe" },
            { "teams", "Teams.exe" },
            { "video düzenleyici", "movieeditorapp.exe" },
            { "pdf okuyucu", "acrord32.exe" },
            { "screenshot", "snippingtool.exe" },

            // Popüler Steam oyunları
            { "counter strike", @"C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo.exe" },
            { "dota 2", @"C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\dota2.exe" },
            { "tekken 7", @"C:\Program Files (x86)\Steam\steamapps\common\TEKKEN 7\TekkenGame\Binaries\Win64\Tekken7.exe" },
            { "stardew valley", @"C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley\StardewValley.exe" },
            { "the witcher 3", @"C:\Program Files (x86)\Steam\steamapps\common\The Witcher 3 Wild Hunt\bin\x64\witcher3.exe" },
            { "grand theft auto v", @"C:\Program Files (x86)\Steam\steamapps\common\Grand Theft Auto V\GTAV.exe" },
            { "among us", @"C:\Program Files (x86)\Steam\steamapps\common\Among Us\AmongUs.exe" },
            { "minecraft", @"C:\Program Files (x86)\Minecraft\MinecraftLauncher.exe" }, // Eğer Minecraft Java sürümü yüklüyse
            { "cyberpunk 2077", @"C:\Program Files (x86)\Steam\steamapps\common\Cyberpunk 2077\Cyberpunk2077.exe" },
            { "valve index", @"C:\Program Files (x86)\Steam\steamapps\common\SteamVR\bin\win64\vrserver.exe" }, // VR oyunları için
            { "fall guys", @"C:\Program Files (x86)\Steam\steamapps\common\Fall Guys\FallGuys_client.exe" },
            { "rocket league", @"C:\Program Files (x86)\Steam\steamapps\common\rocketleague\TslGame.exe" },
            { "apex legends", @"C:\Program Files (x86)\Steam\steamapps\common\Apex Legends\Apex.exe" },
            { "valorant", @"C:\Program Files\Riot Games\VALORANT\live\VALORANT.exe" }, // Riot Games dışında da olsa, popüler bir oyun
            { "dark souls 3", @"C:\Program Files (x86)\Steam\steamapps\common\DARK SOULS III\Game\DarkSoulsIII.exe" },
            { "overwatch", @"C:\Program Files (x86)\Overwatch\Overwatch.exe" }, // Blizzard için
            { "ets", @"F:\SteamLibrary\steamapps\common\Euro Truck Simulator 2\bin\win_x64\eurotrucks2.exe" }
        };

        Dictionary<string, string> infoList = new Dictionary<string, string>()
        {
            { "disk bilgisi", "diskInformation" },
            { "disk alan", "diskInformation" }
        };

        private void XtraMainForm_Load(object sender, EventArgs e)
        {
            rchChat.SelectionColor = System.Drawing.Color.Green;
            rchChat.ReadOnly = true;
            rchChat.AppendText("ChatBot: Merhaba! Size nasıl yardımcı olabilirim?\n");
        }

        private async void btnSendMsg_Click(object sender, EventArgs e)
        {
            string userMessage = txtUserMsg.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
                return;

            if (userMessage == "botiq")
            {
                rchChat.BackColor = System.Drawing.Color.White;
                isGptModel = false;
            }
            if (userMessage == "chatgpt")
            {
                rchChat.BackColor = System.Drawing.Color.LightGray;
                isGptModel = true;
            }
            if (isGptModel)
            {
                AppendMessage("Siz: " + userMessage, System.Drawing.Color.Blue);
                txtUserMsg.Text = string.Empty;

                string botResponse = await OpenAI(userMessage);
                AppendMessage("ChatBot (GPT-5): " + botResponse, System.Drawing.Color.Purple);

                rchChat.SelectionStart = rchChat.Text.Length;
                rchChat.ScrollToCaret();
            }
            else
            {
                AppendMessage("Siz: " + userMessage, System.Drawing.Color.Blue);
                txtUserMsg.Text = string.Empty;

                string botResponse = GetBotResponse(userMessage);
                AppendMessage("ChatBot: " + botResponse, System.Drawing.Color.Green);

                rchChat.SelectionStart = rchChat.Text.Length;
                rchChat.ScrollToCaret();
            }
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
            foreach (var key in infoList.Keys)
            {
                if (message.ToLower().Contains(key))
                {
                    var info = GetInformation();
                    return string.Join("\n", info);
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
        private string OpenProgram(string programPath)
        {
            try
            {
                System.Diagnostics.Process.Start(programPath);
                return "Program açıldı.";
            }
            catch (Exception ex)
            {
                AppendMessage("ChatBot: Program açılamadı. Hata: " + ex.Message, System.Drawing.Color.Red);
                return "Program açılamadı.";
            }
        }
        private List<string> GetInformation()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            var list = new List<string>();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {
                    list.Add($"Disk Adı:" + d.VolumeLabel.ToString());
                    list.Add($"Disk Tipi:" + d.DriveType);
                    list.Add($"Disk Harf: " + d.Name);
                    list.Add("Boş Alan: " + (d.AvailableFreeSpace / 1048576).ToString() + " GB");
                    list.Add("Toplam Alan: " + (d.TotalSize / 1048576).ToString() + " GB\n");
                }
            }
            return list;
        }

        private void txtUserMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSendMsg.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // OpenAI API entegrasyonu
        private async Task<string> OpenAI(string userMsg)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.apiKey);

            var requestBody = new
            {
                model = Constants.modelName,
                messages = new[]
                    {
                        new { role = "user", content = userMsg }
                    }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(Constants.apiUrl, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using var doc = JsonDocument.Parse(responseBody);
                    var result = doc.RootElement
                        .GetProperty("choices")[0]
                        .GetProperty("message")
                        .GetProperty("content")
                        .GetString();

                    return result;
                }
                else
                {
                    Console.WriteLine("Hata oluştu:");
                    Console.WriteLine(responseBody);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"İstisna oluştu: {ex.Message}");
            }

            return null;
        }
    }
}