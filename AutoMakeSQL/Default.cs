using BRSTYPE;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Xml;

namespace BRSBLL
{
    public class Default
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Default()
        {
            Spire.License.LicenseProvider.SetLicenseKey("Fa2hxQ3LxKrtAQCgGGyXAEnlec7gAfL0GKen6NvovXUBqz0Ot7GFliWL4PtbQuNN1fmzbdutJ8Fsjtu/btmQEhdR1lwOBKihF31gDVMvZpGVzZABSEcj/Hy6dePtUE8qD9FmrpAbhJYSY4gttzHYd27UvR2pTRHlAsetlSl+66BcxBWOPaUFr7Lg9EMqR4Zuj6xPR3ZMn47wtV51whFBPL0EHdAqQN7Pxee18ruyu9HbrFpyxfjzcVHbPqaWwj6WXal46r4FBVKQ6WL0vLBYLaiD4t6hvXpjgByt4I2gFNnzWUv9Q1nJuvG/W/9WcoKwUcl6hK+94J+oJnXBH5QRSRGCxRvjazUy+cHpoQ/towgbQ8pMcl9r0L9MMubXUtaOAfEFxijpQzHrgKhMe2UTmGt1c54ChJMOI8Bcf/wJfEp6u9sBdzCuQo26bIm4IA2Lzl/HkaxvvSzjOpfCAsDMMsc5CCUl/RTghc4bbuLoenVpcfs8+QMn5uSKjDvZ0pP65FMpE5HKc9zw3ECtKOHnIqTC7ftGjbQ3gHew71GIIYIo3WZsadyK5LL9kEiH3L9IS0R9dhI0KiPuUiGlXqJg+5oigLJHwqKhTibULl1P81qYHAAP/Uwfq0hCvFM4jvfBL6c2y7rDIUSu3/i1kQ+7xZFpo/tuNmpDQPN4gAi6QP9VAghPMhSk0lDtHfQc8qATuiUvA0DqsIiargOtsgWUPzDCLXGTsr6T2kLA668JRhRpQ0HteUrLuIY6c3M6IG/qqnsnYu8xejENpv7R6kple75Fwa8txJBV4AWnWJGHpnP6RJyZwxadH18hQ6JluNivTVGUFKNu6mieaL0fnCvYWtFMrLQY3PHGjcQsSP1i/SUfOrfoQRmaJs/S1W6xx7PVRnu87TD6sMVcKEC3MDenfGmWBpf7npNW7qW2Y0BzdW8xLz5ldvh21Uz4dWpPs8EI4GVgLsv2UTVdS/RLFAK+IZppuwfGjMMeDGE8bn3chW78GH3ue/NYaBp8aMsMpqGy0lBpXd4ewuAWNDTExVnHVAlMytmsdXDW0iVmRbhDHxu8oGd4hA/tBi8Zr+eoiF7PhoGne0zAeMLIEo6CrUqJlA7hBrzBaXhXjegDWLskwwylN8K70O16FmzWFxccancQ0krw+lGh12XWl2KSWThhy574vcQvF25uLTDHkhE3Jc4+V7J0rXW6xpeuxJNVda0yCLZoKjHW5Cb19hUY6UJr/RU/HSJ09dLDqMosRGtPR4RJpoPhczx280rphG1P+EP61MvSJPMx/Ud325yQ/aclEA8uT2CJPzQ6ePZUqsgYiDHMBQhab6PE+t3Bc1j7/e57F7/QoRqfVh+H+yskbav4gK8ZhKA5rqLHNXmYXzjs7DLN4zddUN9XuVtkt8dlsqIzVaclHtKeReeAjEd4gtxNVqEvrgBGLY/frliMl/8IpxfcPUXcLmIIbgCWaoxppLEpHx9KI2Pe6G73xi+xUaF5Q+FqbFtTGFi6xeUG6YNGW0l9o2rH1J3n1ohFcM+lS9Ko");
        }

        // 資料--------------------------------------------------------------------------------------------------------------------------------

        #region 檢查並新增資料夾
        /// <summary>
        /// 檢查並新增資料夾
        /// </summary>
        /// <param name="uploadDir"></param>
        public bool Check_folders(string uploadDir)
        {
            if (!System.IO.Directory.Exists(uploadDir))
                System.IO.Directory.CreateDirectory(uploadDir);

            return true;
        }
        #endregion

        #region 檢查檔案是否存在檔名重複加上(x)
        /// <summary>
        /// 檢查檔案是否存在
        /// 存在檔名加上(x)
        /// ex: TEST(1).txt
        /// </summary>
        /// <param name="fullpath">檔案路徑</param>
        /// <returns>路徑</returns>
        public string FileCheckReplace(string fullpath)
        {
            int Count = 1;
            bool FileExists = File.Exists(fullpath);
            string newPath = "";
            while (FileExists)
            {
                newPath = Path.Combine(Path.GetDirectoryName(fullpath), $"{Path.GetFileNameWithoutExtension(fullpath)}({Count}){Path.GetExtension(fullpath)}");
                FileExists = File.Exists(newPath);
                Count++;
            }
            return newPath == "" ? fullpath : newPath;
        }
        #endregion

        #region 替換文字(檔名用)
        /// <summary>
        /// 如果文件名包特定符號,取代成中文字，避免NTFS檔案系統錯誤
        /// </summary>
        /// <param name="FileName">檔名</param>
        /// <returns>新檔名</returns>
        public string ReplaceFileName(string FileName)
        {
            char[] Invalid = Path.GetInvalidFileNameChars();
            string[] ReplaceKey = new string[] { ":", "/", "\\" };
            string[] ReplaceList = new string[] { "比", "與", "與" };
            foreach (char item in Invalid)
            {
                int pos = Array.IndexOf(ReplaceKey, item.ToString());
                FileName = FileName.Replace(item.ToString(), pos > -1 ? ReplaceList[pos] : string.Empty);
            }
            return FileName;
        }
        #endregion

        // 日期--------------------------------------------------------------------------------------------------------------------------------

        #region 日期轉換成民國年
        public string Convert_to_TW_date(DateTime input_date)
        {
            var taiwanCalendar = new System.Globalization.TaiwanCalendar();
            //string date = input_date.Substring(4, 4);
            //string year = Convert.ToString((int.Parse(input_date.Substring(0, 4)) - 1911));
            return string.Format("{0}{1:00}{2:00}", taiwanCalendar.GetYear(input_date), input_date.Month, input_date.Day);
        }
        #endregion

        #region 民國年轉換成西元年
        /// <summary>
        /// 民國年轉換成西元年
        /// </summary>
        /// <param name="chinese_date">ex:1110111</param>
        /// <returns>ex:20220111</returns>
        public string Convert_to_AD_date(string chinese_date)
        {
            chinese_date = chinese_date.PadLeft(8, '0');
            CultureInfo culture = new CultureInfo("zh-TW", true);
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();
            //string date = chinese_date.Substring(3, 4);
            //string year = Convert.ToString((int.Parse(chinese_date.Substring(0, 3)) + 1911));
            return DateTime.ParseExact(chinese_date, "yMMdd", culture).ToString("yyyyMMdd");
        }
        #endregion

        // Model操作---------------------------------------------------------------------------------------------------------------------------

        #region ListModel To DataTable
        public DataTable ToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            foreach (PropertyDescriptor prop in props)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyDescriptor prop in props)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        #endregion

        #region Model to Model
        /// <summary>
        /// 將A Model 資料填入 B Model
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="Model">A Model</param>
        /// <returns>B Model</returns>
        public T Mapping<T>(object Model)
        {
            Type type = typeof(T);
            object obj = Activator.CreateInstance(type);
            Type t = Model.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var temp = type.GetProperty(prop.Name);
                if (temp != null)
                {
                    temp.SetValue(obj, prop.GetValue(Model), null);
                }
            }
            return (T)obj;
        }
        #endregion

        #region Dict To Model
        /// <summary>
        /// 字典填入Model
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="dict">anyDict</param>
        /// <returns>Model</returns>
        public T DictToModel<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);
            foreach (var kv in dict)
            {
                type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }
            return (T)obj;
        }
        #endregion

        #region Model To Dict
        /// <summary>
        /// Model To Dict
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="model">Model</param>
        /// <returns>Dict</returns>
        public Dictionary<string, object> ModelToDict<T>(T model)
        {
            return model.GetType().
                    GetProperties(BindingFlags.Instance | BindingFlags.Public).
                    ToDictionary(prop => prop.Name, prop => prop.GetValue(model, null));
        }
        #endregion

        #region TXT To Model
        /// <summary>
        /// 文字檔自動填入Model
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="filePath">路徑</param>
        /// <param name="partition">分割符號</param>
        /// <returns>List<Model></returns>
        static List<T> OpenCSV<T>(string filePath, char partition)
        {
            List<T> result = new List<T>();
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs, Encoding.Default);
                while (reader.EndOfStream == false)
                {
                    string strLine = reader.ReadLine().Trim();
                    var temp = strLine.Split(partition);
                    Type type = typeof(T);
                    var obj = Activator.CreateInstance(type);
                    PropertyInfo[] props = type.GetProperties();
                    for (var i = 0; i < props.Count(); i++)
                    {
                        props[i].SetValue(obj, temp[i]);
                    }
                    result.Add((T)obj);
                }
                reader.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("OpenCSV error:" + ex);
                logger.Error(ex);
            }
            return result;
        }
        #endregion

        // AD----------------------------------------------------------------------------------------------------------------------------------

        #region 模擬AD使用者
        public class Impersonation
        {
            [DllImport("advapi32.dll")]
            private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
            private IntPtr phToken;
            private WindowsImpersonationContext impersonationContext;
            private readonly XmlDocument doc = new XmlDocument();
            private readonly XmlNode node;
            private readonly XmlElement element;
            private string Path { get; set; }
            private string Domain { get; set; }
            private string Username { get; set; }
            private string Password { get; set; }
            public Impersonation(string path)
            {
                Path = path;
                doc.Load(Path);
                node = doc.SelectSingleNode("//system.web");
                element = (XmlElement)node.SelectSingleNode("//identity");
                Domain = element.GetAttribute("userName").ToString().Substring(0, 4);
                Username = element.GetAttribute("userName").ToString().Substring(5);
                Password = element.GetAttribute("password").ToString();
            }

            public bool Runasuser(string lpszDomain = "", string lpszUsername = "", string lpszPassword = "")
            {

                lpszDomain = lpszDomain == "" ? Domain : lpszDomain;
                lpszUsername = lpszUsername == "" ? Username : lpszUsername;
                lpszPassword = lpszPassword == "" ? Password : lpszPassword;
                if (LogonUser(lpszUsername, lpszDomain, lpszPassword, 9, 0, out phToken))
                {
                    try
                    {
                        impersonationContext = WindowsIdentity.Impersonate(phToken);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Undo()
            {
                if (impersonationContext != null)
                {
                    impersonationContext.Undo();
                    impersonationContext.Dispose();
                }
            }
        }
        #endregion

        #region 查詢AD資料
        public Dictionary<string, string> Get_AD_Detail(string LDAP, string Query)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (DirectorySearcher ds = new DirectorySearcher(new DirectoryEntry(LDAP)))
            {
                ds.Filter = Query;
                SearchResult sr = ds.FindOne();
                result.Add("I_EMP", sr.Properties["samaccountname"].Count > 0 ? sr.Properties["samaccountname"][0].ToString().ToUpper() : null);
                result.Add("N_EMP_NAME", sr.Properties["name"].Count > 0 ? sr.Properties["name"][0].ToString() : null);
                result.Add("EMAIL", sr.Properties["mail"].Count > 0 ? sr.Properties["mail"][0].ToString() : null);
                result.Add("I_DEPT", sr.Properties["department"].Count > 0 ? sr.Properties["department"][0].ToString() : null);
                result.Add("company", sr.Properties["company"].Count > 0 ? sr.Properties["company"][0].ToString() : null);
            }
            return result;
        }
        #endregion

        // 壓縮--------------------------------------------------------------------------------------------------------------------------------

        #region 檔案不落地壓縮zip
        /// <summary>
        /// 檔案不落地壓縮zip
        /// </summary>
        /// <param name="f">檔案</param>
        /// <param name="Name">檔名</param>
        /// <returns></returns>
        public byte[] Zip(List<byte[]> f, string[] Name)
        {
            using (var ms = new MemoryStream())
            {
                using (Ionic.Zip.ZipOutputStream zs = new Ionic.Zip.ZipOutputStream(ms))
                {
                    zs.AlternateEncoding = Encoding.UTF8;
                    zs.AlternateEncodingUsage = Ionic.Zip.ZipOption.AsNecessary;

                    for (var i = 0; i < Name.Length; i++)
                    {
                        string filename = Path.GetFileName(Name[i]);
                        zs.PutNextEntry(filename.Substring(0, filename.Length - 4));
                        zs.Write(f[i], 0, f[i].Length);
                    }
                    zs.Dispose();
                    return ms.ToArray();
                }
            }
        }
        #endregion

        #region 解壓縮檔案

        public List<unZipFile> UnZip(string path)
        {
            var result = new List<unZipFile>();
            using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(path))
            {
                foreach (Ionic.Zip.ZipEntry zEntry in zip)
                {
                    MemoryStream tempS = new MemoryStream();
                    zEntry.Extract(tempS);

                    result.Add(new unZipFile()
                    {
                        Name = zEntry.FileName,
                        Byte = tempS.ToArray()
                    });
                }
            }
            return result;
        }
        #endregion

        #region 壓縮檔加入檔案
        /// <summary>
        /// 壓縮檔加入新檔案
        /// </summary>
        /// <param name="path">ZIP檔路徑</param>
        /// <param name="streamName">檔名</param>
        /// <param name="stream">串流檔</param>
        /// <param name="Rename">重新命名</param>
        /// <returns></returns>
        public bool ZipFileJoinFile(string path, string streamName, Stream stream, string Rename = null)
        {
            try
            {
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(path))
                {
                    try
                    {
                        zip.RemoveEntry(streamName);
                    }
                    catch
                    {

                    }
                    zip.AddEntry(streamName, stream);
                    if (Rename == null)
                    {
                        zip.Save(path);
                    }
                    else
                    {
                        zip.Save(Rename);
                        File.Delete(path);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
            return true;
        }
        #endregion

        // Csv---------------------------------------------------------------------------------------------------------------------------------

        #region Read csv To Array
        public List<List<string>> Csv_To_Array(Stream csv)
        {
            List<List<string>> Array = new List<List<string>>();
            using (StreamReader reader = new StreamReader(csv, Encoding.Default))
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
                            Array.Add(row);
                            row = new List<string>();
                        }
                        else
                        {
                            if (c != '"' && c != '\r')
                            {
                                sb.Append(c == '\n' ? ' ' : c);
                            }
                        }
                    }
                    row.Add(sb.ToString().Trim());
                    Array.Add(row);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return Array;
                }
            }
            return Array;
        }
        #endregion

        // Mail--------------------------------------------------------------------------------------------------------------------------------

        #region 發送mail
        /// <summary>
        /// 發送Email
        /// </summary>
        /// <param name="SMTPHost">SMTP Server</param>
        /// <param name="Send">寄件者mail</param>
        /// <param name="Reciver">收件者mail</param>
        /// <param name="Subject">郵件標題</param>
        /// <param name="Descript">郵件內容</param>
        public void SendMail(string SMTPHost, string Send, string Reciver, string Subject, string Descript)
        {
            /*1.先設定SMTP Client
             *2.建立寄件者及收件者帳號
             *3.建立郵件
             *4.發送郵件
             */

            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient(SMTPHost);
            // Specify the e-mail sender.Create a mailing address that includes a UTF8 character in the display name.
            MailAddress from = new MailAddress(Send, "Administrator", Encoding.UTF8);
            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress(Reciver);

            //----------------------------------------------Specify the message content.
            MailMessage message = new MailMessage(from, to)
            {
                Body = Descript,
                BodyEncoding = Encoding.UTF8,
                Subject = Subject,
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };
            //message.CC.Add("ia00395@sdcc.corp");
            //client.Credentials = new NetworkCredential("Fpgmail", "*fptmail", "CSBCMIS");
            //client.Credentials = new NetworkCredential("Fpgmail", "*fptmail", "CSBCMIS");
            client.Send(message);
            // Clean up.
            message.Dispose();
        }
        #endregion

        #region 發送mail附檔名
        /// <summary>
        /// 發送Email
        /// </summary>
        /// <param name="SMTPHost">SMTP Server</param>
        /// <param name="Send">寄件者mail</param>
        /// <param name="Reciver">收件者mail</param>
        /// <param name="Subject">郵件標題</param>
        /// <param name="Descript">郵件內容</param>
        /// <param name="FileName">檔案名稱</param>
        public void SendMail(string SMTPHost, string Send, string Reciver, string Subject, string Descript, string FileName)
        {
            /*1.先設定SMTP Client
             *2.建立寄件者及收件者帳號
             *3.建立郵件
             *4.發送郵件
             */

            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient(SMTPHost);
            // Specify the e-mail sender.Create a mailing address that includes a UTF8 character in the display name.
            MailAddress from = new MailAddress(Send, "Administrator", Encoding.UTF8);
            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress(Reciver);

            //----------------------------------------------Specify the message content.
            MailMessage message = new MailMessage(from, to)
            {
                Body = Descript,
                BodyEncoding = Encoding.UTF8,
                Subject = Subject,
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };
            message.Attachments.Add(new Attachment(FileName));
            client.Credentials = new NetworkCredential("Fpgmail", "*fptmail", "CSBCMIS");
            client.Send(message);
            // Clean up.
            message.Dispose();
        }
        #endregion

        #region 發送mail附stream檔
        /// <summary>
        /// 發送Email附stream檔
        /// </summary>
        /// <param name="SMTPHost">SMTP Server</param>
        /// <param name="Send">寄件者mail</param>
        /// <param name="Reciver">收件者mail</param>
        /// <param name="Subject">郵件標題</param>
        /// <param name="Descript">郵件內容</param>
        /// <param name="FileStream">Stream檔</param>
        /// <param name="FileName">檔名.附檔名</param>
        /// <param name="FileType">檔案型別</param>
        public void SendMail(string SMTPHost, string Send, string Reciver, string Subject, string Descript, MemoryStream FileStream, string FileName, string FileType)
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient(SMTPHost);
            // Specify the e-mail sender.Create a mailing address that includes a UTF8 character in the display name.
            MailAddress from = new MailAddress(Send, "Administrator", Encoding.UTF8);
            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress(Reciver);

            //----------------------------------------------Specify the message content.
            MailMessage message = new MailMessage(from, to)
            {
                Body = Descript,
                BodyEncoding = Encoding.UTF8,
                Subject = Subject,
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };
            message.Attachments.Add(new Attachment(FileStream, FileName, FileType));
            client.Send(message);
            // Clean up.
            message.Dispose();
        }
        #endregion

        // 文件--------------------------------------------------------------------------------------------------------------------------------

        #region 合併PDF
        public Stream CombinePDF(List<byte[]> fs)
        {
            var Stream = new MemoryStream();
            Stream[] temp = fs.Select(x => new MemoryStream(x)).ToArray();
            Spire.Pdf.PdfDocument.MergeFiles(temp, Stream);
            Stream.Position = 0L;
            return Stream;
        }
        #endregion

        #region 文件轉PDF
        public byte[] DocToPDF(unZipFile f)
        {
            Stream stream = new MemoryStream();
            Stream temp = new MemoryStream(f.Byte);
            switch (System.IO.Path.GetExtension(f.Name))
            {
                case ".docx":
                case ".doc":
                    Spire.Doc.Document doc = new Spire.Doc.Document();
                    doc.LoadFromStream(temp, Spire.Doc.FileFormat.Auto, null);
                    doc.SaveToStream(stream, Spire.Doc.FileFormat.PDF);
                    break;
                case ".xls":
                case ".xlsx":
                    Spire.Xls.Workbook wb = new Spire.Xls.Workbook();
                    wb.LoadFromStream(temp);
                    wb.SaveToStream(stream, Spire.Xls.FileFormat.PDF);
                    break;
                case ".ppt":
                case ".pptx":
                    Spire.Presentation.Presentation ppt = new Spire.Presentation.Presentation();
                    ppt.LoadFromStream(temp, Spire.Presentation.FileFormat.Auto);
                    ppt.SaveToFile(stream, Spire.Presentation.FileFormat.PDF);
                    break;
                case ".pdf":
                    stream = temp;
                    break;
            }
            stream.Position = 0L;
            Int32 length = stream.Length > Int32.MaxValue ? Int32.MaxValue : Convert.ToInt32(stream.Length);
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            return buffer;
        }
        #endregion
    }
}
