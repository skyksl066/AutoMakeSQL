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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox_path.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;
            richTextBox_output.Text = string.Empty;
            richTextBox_output.Text = richTextBox_inputHeader.Text + (char)13;
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

        private void Form1_SizeChange(object sender, EventArgs e)
        {
            BoxResize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string Dir = @".\Data";
            StateRead();
            using (FileStream fileStream = new FileStream($@"{Dir}\PLSql.txt", FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(fileStream))
                {
                    string [] temp = sr.ReadToEnd().Split(new char[1] { '\n' });
                    autocompleteMenu1.Items = temp.Length > 0 ? temp : autocompleteMenu1.Items;
                }
            };
            BoxResize();
        }

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
        }

        private void BoxResize()
        {
            richTextBox_inputHeader.Location = new Point(richTextBox_inputHeader.Location.X, Height - richTextBox_inputHeader.Height - 50);
            richTextBox_inputHeader.Size = new Size(Math.Abs(richTextBox_inputHeader.Location.X + Width / 2) - 50
                , richTextBox_inputHeader.Size.Height);
            richTextBox_inputRepeat.Size = new Size(Math.Abs(richTextBox_inputRepeat.Location.X + Width / 2) - 50
                , Math.Abs(Height - richTextBox_inputRepeat.Location.Y - richTextBox_inputHeader.Height) - 60);
            label2.Location = new Point(Width / 2 + 10, 100);
            richTextBox_output.Location = new Point(Width / 2 + 10, 120);
            richTextBox_output.Size = new Size(Math.Abs(richTextBox_output.Location.X - Width) - 30
                , Math.Abs(richTextBox_output.Location.Y - Height) - 50);
        }

        private void StateSave()
        {
            string Dir = @".\Data";
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }
            foreach (var item in new string[] { "richTextBox_inputHeader", "richTextBox_output", "textBox_symbol", "richTextBox_inputRepeat" })
            {
                using (FileStream fileStream = new FileStream($@"{Dir}\{item}.txt", FileMode.OpenOrCreate))
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c.Name == item)
                        {
                            using (var sr = new StreamWriter(fileStream))
                            {
                                sr.Write(c.Text);
                            }
                        }
                    }
                };
            }
        }

        private void StateRead()
        {
            string Dir = @".\Data";
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }
            foreach (var item in new string[] { "richTextBox_inputHeader", "richTextBox_output", "textBox_symbol", "richTextBox_inputRepeat" })
            {
                using (FileStream fileStream = new FileStream($@"{Dir}\{item}.txt", FileMode.OpenOrCreate))
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c.Name == item)
                        {
                            using (var sr = new StreamReader(fileStream))
                            {
                                c.Text = sr.ReadToEnd();
                            }
                        }
                    }
                };
            }
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

        
    }
}
