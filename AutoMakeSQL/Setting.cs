using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMakeSQL
{
    public partial class Setting : Form
    {
        /// <summary>
        /// 設定路徑
        /// </summary>
        private static readonly string Path = $@".\Data\setting.txt";
        /// <summary>
        /// 建構式
        /// </summary>
        public Setting()
        {
            InitializeComponent();
            InitializeSetting();
        }

        /// <summary>
        /// 初始化Setting
        /// </summary>
        public void InitializeSetting()
        {
            if (!File.Exists(Path))
            {
                SaveSetting();
            }
        }

        /// <summary>
        /// 存設定
        /// </summary>
        private void SaveSetting()
        {
            using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                var d = new Dictionary<string, string>();
                foreach (var item in new string[] { "TimerTextBox", "ConnectRichTextBox" })
                {
                    d.Add(item, this.Controls[item].Text);
                }
                using (var sr = new StreamWriter(fileStream))
                {
                    sr.Write(JsonConvert.SerializeObject(d));
                }
            };
        }

        /// <summary>
        /// 驗證填入是否數字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimertextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// 讀取設定並顯示到介面上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_Load(object sender, EventArgs e)
        {
            using (FileStream fileStream = new FileStream(Path, FileMode.Open))
            {
                using (var sr = new StreamReader(fileStream))
                {
                    var d = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                    foreach (var item in d)
                    {
                        this.Controls[item.Key].Text = item.Value;
                    }
                }
            }
        }

        /// <summary>
        /// 存檔按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSetting();
            this.Close();
            Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            frm.InitializeSetting();
        }
    }
}
