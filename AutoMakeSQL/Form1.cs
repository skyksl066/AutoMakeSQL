using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using ScintillaNET;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AutoMakeSQL
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 存檔路徑
        /// </summary>
        private string SaveFilePath { get; set; }
        /// <summary>
        /// 連線參數
        /// </summary>
        private string ConnectionString { get; set; }
        /// <summary>
        /// 初始化連線
        /// </summary>
        private OracleConnection Connect;
        private OracleCommand Command;
        private OracleTransaction Transaction;

        /// <summary>
        /// 自動存檔秒數
        /// </summary>
        private int AuotSaveInterval
        {
            get
            {
                string result = LoadSetting("TimerTextBox");
                int Interval = string.IsNullOrEmpty(result) ? 60 : Convert.ToInt32(result);
                return Interval * 1000;
            }
        }

        /// <summary>
        /// 建構式
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitializeSetting();
        }

        /// <summary>
        /// borwse按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV (逗號分隔)(*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox_path.Text = openFileDialog1.FileName;
        }

        /// <summary>
        /// convent按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void convent_button_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;
            richTextBox_output.Text = string.Empty;
            string tempi;
            var temp = new StringBuilder();
            using (StreamReader reader = new StreamReader(textBox_path.Text, Encoding.Default))
            {
                try
                {
                    var row = new List<string>();
                    var isStringBlock = false;
                    var sb = new StringBuilder();
                    int currentLineCount = 0;
                    while (reader.Peek() != -1)
                    {
                        char c = (char)reader.Read();

                        if (c == '"')
                        {
                            isStringBlock = !isStringBlock;
                        }

                        if (c == ',' && !isStringBlock)
                        {
                            row.Add(sb.ToString().Trim());
                            sb.Length = 0;
                        }
                        else if (c == '\n' && !isStringBlock)
                        {
                            row.Add(sb.ToString().Trim());
                            sb.Length = 0;
                            currentLineCount++;
                            tempi = richTextBox_inputRepeat.Text;
                            for (int i = 0; i < row.Count; i++)
                            {
                                tempi = tempi.Replace("{" + i + "}", row[i]);
                            }
                            temp.AppendLine(tempi);
                            row = new List<string>();
                        }
                        else
                        {
                            if (c != '"' && c != '\r')
                            {
                                if (c == '\n')
                                    sb.Append(textBox_symbol.Text);
                                else
                                    sb.Append(c);
                            }
                        }
                    }
                    row.Add(sb.ToString().Trim());
                    tempi = richTextBox_inputRepeat.Text;
                    for (int i = 0; i < row.Count; i++)
                    {
                        tempi = tempi.Replace("{" + i + "}", row[i]);
                    }
                    temp.AppendLine(tempi);
                }
                catch (Exception) { }
                richTextBox_output.Text += temp.ToString();
            }
        }

        /// <summary>
        /// 視窗變換大小事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChange(object sender, EventArgs e)
        {
            BoxResize();
        }

        /// <summary>
        /// 視窗載入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string Dir = @".\Data";
            using (FileStream fileStream = new FileStream($@"{Dir}\PLSql.txt", FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(fileStream))
                {
                    string[] temp = sr.ReadToEnd().Split(new char[1] { '\n' });
                    autocompleteMenu1.Items = temp.Length > 0 ? temp : autocompleteMenu1.Items;
                }
            };
        }

        /// <summary>
        /// 視窗關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Dir = @".\Data";
            StateSave();
            using (FileStream fileStream = new FileStream($@"{Dir}\PLSql.txt", FileMode.OpenOrCreate))
            {
                using (var sr = new StreamWriter(fileStream))
                {
                    sr.Write(string.Join("\n", autocompleteMenu1.Items));
                }
            };
            if (Connect != null)
            {
                Connect.Close();
            }
        }

        private void BoxResize()
        {
            int rigthX = 17;
            int liftX = Width / 2 + 10;
            int rigthWidth = Math.Abs(richTextBox_inputRepeat.Location.X + Width / 2) - 50;

            #region rigth
            richTextBox_inputRepeat.Size = new Size(rigthWidth
                , Math.Abs(Height - richTextBox_inputRepeat.Location.Y) - 50 - MessageListBox.Size.Height - 20);
            #endregion
            label2.Location = new Point(liftX, 120);
            richTextBox_output.Location = new Point(liftX, 140);
            richTextBox_output.Size = new Size(Math.Abs(richTextBox_output.Location.X - Width) - 30
                , Math.Abs(Height - richTextBox_output.Location.Y) - 50 - MessageListBox.Size.Height - 20);

            Console.WriteLine($"richTextBox_output {richTextBox_output.Width} {richTextBox_output.Height}");
            #region bottom
            MessageListBox.Location = new Point(rigthX, 120 + richTextBox_output.Size.Height + 30);
            MessageListBox.Size = new Size(Width - 48, 104);
            #endregion
        }

        /// <summary>
        /// 存格子的資料
        /// </summary>
        private void StateSave()
        {

            string Dir = @".\Data";
            if (SaveFilePath == null)
            {
                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }
                SaveFilePath = $@"{Dir}\{DateTime.Now:yyyyMMddHHmmss}.txt";
            }
            using (FileStream fileStream = new FileStream(SaveFilePath, FileMode.OpenOrCreate))
            {
                var d = new Dictionary<string, string>();
                foreach (var item in new string[] { "richTextBox_inputHeader", "richTextBox_output", "textBox_symbol", "richTextBox_inputRepeat" })
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c.Name == item)
                        {
                            d.Add(c.Name, c.Text);
                        }
                    }
                }
                using (var sr = new StreamWriter(fileStream))
                {
                    sr.Write(JsonConvert.SerializeObject(d));
                }
            };
        }

        private void richTextBox_input_TextChanged(object sender, EventArgs e)
        {
            int s_start = richTextBox_inputRepeat.SelectionStart, startIndex = 0;
            var words = richTextBox_inputRepeat.Text.Split(new char[] { '(', ')', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                int index = richTextBox_inputRepeat.Text.IndexOf(words[i], startIndex);
                richTextBox_inputRepeat.Select(index, words[i].Length);
                richTextBox_inputRepeat.SelectionColor = autocompleteMenu1.Items
                .Where(x => x.Contains(words[i].ToUpper()) && x.Length == words[i].Length).Count() > 0
                ? Color.Blue : Color.Black;
                startIndex = index + words[i].Length;
            }
            richTextBox_inputRepeat.SelectionStart = s_start;
            richTextBox_inputRepeat.SelectionLength = 0;
            richTextBox_inputRepeat.SelectionColor = Color.Black;
        }

        /// <summary>
        /// 結束按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 另存先檔按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFilePath = saveFileDialog1.FileName;
                StateSave();
            }
        }

        /// <summary>
        /// 開啟檔案按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文字文件(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            SaveFilePath = openFileDialog1.FileName;
            using (FileStream fileStream = new FileStream(SaveFilePath, FileMode.Open))
            {
                using (var sr = new StreamReader(fileStream))
                {
                    var d = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                    foreach (var item in d)
                    {
                        try
                        {
                            this.Controls[item.Key].Text = item.Value;
                        }
                        catch { }
                    }
                }
            };
        }

        /// <summary>
        /// 開啟程式後60秒自動存檔一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            StateSave();
        }

        /// <summary>
        /// 顯示設定視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SettingForm = new Setting
            {
                StartPosition = FormStartPosition.CenterParent
            };
            SettingForm.Show(this);
        }

        /// <summary>
        /// 讀取設定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string LoadSetting(string key)
        {
            string result = string.Empty;
            using (FileStream fileStream = new FileStream($@".\Data\setting.json", FileMode.Open))
            {
                if (fileStream.Length == 0)
                    return "";
                using (var sr = new StreamReader(fileStream))
                {
                    var t = sr.ReadToEnd();
                    var d = JsonConvert.DeserializeObject<Dictionary<string, string>>(t);
                    result = d[key];
                }
            }
            return result;
        }

        /// <summary>
        /// 初始化設定
        /// </summary>
        public void InitializeSetting()
        {
            new Setting().InitializeSetting();
            timer1.Interval = AuotSaveInterval;
            ConnectionString = LoadSetting("ConnectRichTextBox");
        }

        /// <summary>
        /// 連線按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show(this, "尚未設定連線參數!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ConnectButton.Text == "Connect")
            {
                try
                {
                    Connect = new OracleConnection(ConnectionString);
                    Connect.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BeginTransaction();
                CommitButton.Enabled = true;
                ExecuteButton.Enabled = true;
                RollbackButton.Enabled = true;
                ConnectButton.Text = "Disconnect";
                ConnectButton.BackColor = Color.Green;
            }
            else
            {
                Connect.Close();
                CommitButton.Enabled = false;
                ExecuteButton.Enabled = false;
                RollbackButton.Enabled = false;
                ConnectButton.Text = "Connect";
                ConnectButton.BackColor = Color.Red;
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            string[] sqls = richTextBox_output.Text.Split(new string[] { ";\n", ";" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                MessageListBox.Items.Clear();
                for (int i = 0; i < sqls.Length; i++)
                {
                    int index = richTextBox_output.Text.IndexOf(sqls[i]);
                    richTextBox_output.Select(index, sqls[i].Length);
                    richTextBox_output.Focus();
                    Command.CommandText = sqls[i];
                    Command.ExecuteNonQuery();
                    MessageListBox.Items.Add($"row {i} 成功");
                }
            }
            catch (Exception ex)
            {
                MessageListBox.Items.Add(ex);
            }
        }

        private void RollbackButton_Click(object sender, EventArgs e)
        {
            Transaction.Rollback();
            BeginTransaction();
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            Transaction.Commit();
            BeginTransaction();
        }

        private void BeginTransaction()
        {
            Transaction = Connect.BeginTransaction(IsolationLevel.ReadCommitted);
            Command = Connect.CreateCommand();
            Command.Transaction = Transaction;
        }

        /// <summary>
        /// 連線
        /// </summary>
        /// <returns>成功 success 失敗 錯誤代碼</returns>
        private void Connection()
        {

        }

        /// <summary>
        /// ctrl + c 可複製訊息窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = MessageListBox.SelectedItem.ToString();
                Clipboard.SetData(DataFormats.StringFormat, s);
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripItem;
            var owner = menuItem.Owner as ContextMenuStrip;
            var type = owner.SourceControl.GetType().Name;
            string text = string.Empty;
            switch (type)
            {
                case "RichTextBox":
                    var RichTextBox = owner.SourceControl as RichTextBox;
                    text = RichTextBox.SelectedText;
                    break;
                case "ListBox":
                    var ListBox = owner.SourceControl as ListBox;
                    text = string.Join(Environment.NewLine, ListBox.SelectedItems.OfType<string>());
                    break;
            }
            Clipboard.SetText(string.Join(Environment.NewLine, text));
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            var menuItem = sender as ToolStripItem;
            var owner = menuItem.Owner as ContextMenuStrip;
            var type = owner.SourceControl.GetType().Name;
            switch (type)
            {
                case "RichTextBox":
                    var RichTextBox = owner.SourceControl as RichTextBox;
                    var index = RichTextBox.SelectionStart;
                    RichTextBox.Text = RichTextBox.Text.Insert(index, text);
                    break;
            }
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            var menu = sender as ContextMenuStrip;
            var type = menu.SourceControl.GetType().Name;
            switch (type)
            {
                case "RichTextBox":
                    PasteToolStripMenuItem.Enabled = true;
                    break;
                case "ListBox":
                    PasteToolStripMenuItem.Enabled = false;
                    break;
            }
        }
    }
}
