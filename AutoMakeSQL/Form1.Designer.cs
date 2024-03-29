﻿namespace AutoMakeSQL
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_inputRepeat = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_output = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.convent_button = new System.Windows.Forms.Button();
            this.textBox_symbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MessageListBox = new System.Windows.Forms.ListBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.CommitButton = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input";
            // 
            // richTextBox_inputRepeat
            // 
            this.richTextBox_inputRepeat.AcceptsTab = true;
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox_inputRepeat, this.autocompleteMenu1);
            this.richTextBox_inputRepeat.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox_inputRepeat.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox_inputRepeat.Location = new System.Drawing.Point(17, 244);
            this.richTextBox_inputRepeat.Name = "richTextBox_inputRepeat";
            this.richTextBox_inputRepeat.Size = new System.Drawing.Size(375, 282);
            this.richTextBox_inputRepeat.TabIndex = 1;
            this.richTextBox_inputRepeat.Text = "UPDATE DUAL SET=\'{0}\' WHERE A=\'{1}\' AND B=\'{2}\';";
            this.richTextBox_inputRepeat.TextChanged += new System.EventHandler(this.RichTextBox_input_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.SelectAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "ContextMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyToolStripMenuItem.Text = "複製";
            this.CopyToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.PasteToolStripMenuItem.Text = "貼上";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(418, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output";
            // 
            // richTextBox_output
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox_output, null);
            this.richTextBox_output.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox_output.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox_output.Location = new System.Drawing.Point(418, 140);
            this.richTextBox_output.Name = "richTextBox_output";
            this.richTextBox_output.Size = new System.Drawing.Size(368, 386);
            this.richTextBox_output.TabIndex = 3;
            this.richTextBox_output.Text = "";
            this.richTextBox_output.WordWrap = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "CSV (逗號分隔)(*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // textBox_path
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.textBox_path, null);
            this.textBox_path.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_path.Location = new System.Drawing.Point(13, 34);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(672, 29);
            this.textBox_path.TabIndex = 4;
            // 
            // button_browse
            // 
            this.button_browse.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_browse.Location = new System.Drawing.Point(691, 34);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(97, 29);
            this.button_browse.TabIndex = 5;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.Button_browse_Click);
            // 
            // convent_button
            // 
            this.convent_button.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.convent_button.Location = new System.Drawing.Point(691, 69);
            this.convent_button.Name = "convent_button";
            this.convent_button.Size = new System.Drawing.Size(97, 29);
            this.convent_button.TabIndex = 6;
            this.convent_button.Text = "Convent";
            this.convent_button.UseVisualStyleBackColor = true;
            this.convent_button.Click += new System.EventHandler(this.Convent_button_Click);
            // 
            // textBox_symbol
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.textBox_symbol, null);
            this.textBox_symbol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_symbol.Location = new System.Drawing.Point(117, 75);
            this.textBox_symbol.Name = "textBox_symbol";
            this.textBox_symbol.Size = new System.Drawing.Size(258, 29);
            this.textBox_symbol.TabIndex = 7;
            this.textBox_symbol.Text = "$$$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "\"\\n\" Replace";
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.AllowsTabKey = true;
            this.autocompleteMenu1.AppearInterval = 50;
            this.autocompleteMenu1.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu1.Colors")));
            this.autocompleteMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenu1.ImageList = null;
            this.autocompleteMenu1.Items = new string[] {
        "ABORT",
        "ACCEPT",
        "ACCESS",
        "ADD",
        "ALL",
        "ALTER",
        "AND",
        "ANY",
        "ARRAY",
        "ARRAYLEN",
        "AS",
        "ASC",
        "ASSERT",
        "ASSIGN",
        "AT",
        "ATTRIBUTES",
        "AUDIT",
        "AUTHORIZATION",
        "AVG",
        "BASE_TABLE",
        "BEGIN",
        "BETWEEN",
        "BINARY_INTEGER",
        "BODY",
        "BOOLEAN",
        "BY",
        "CASE",
        "CAST",
        "CHAR",
        "CHAR_BASE",
        "CHECK",
        "CLOSE",
        "CLUSTER",
        "CLUSTERS",
        "COLAUTH",
        "COLUMN",
        "COMMENT",
        "COMMIT",
        "COMPRESS",
        "CONNECT",
        "CONNECTED",
        "CONSTANT",
        "CONSTRAINT",
        "CRASH",
        "CREATE",
        "CURRENT",
        "CURRVAL",
        "CURSOR",
        "DATABASE",
        "DATA_BASE",
        "DATE",
        "DBA",
        "DEALLOCATE",
        "DEBUGOFF",
        "DEBUGON",
        "DECLARE",
        "DECIMAL",
        "DEFAULT",
        "DEFINITION",
        "DELAY",
        "DELETE",
        "DESC",
        "DIGITS",
        "DISPOSE",
        "DISTINCT",
        "DO",
        "DROP",
        "ELSE",
        "ELSIF",
        "ENABLE",
        "END",
        "ENTRY",
        "ESCAPE",
        "EXCEPTION",
        "EXCEPTION_INIT",
        "EXCHANGE",
        "EXCLUSIVE",
        "EXISTS",
        "EXIT",
        "EXTERNAL",
        "FAST",
        "FETCH",
        "FILE",
        "FOR",
        "FORCE",
        "FORM",
        "FROM",
        "FUNCTION",
        "GENERIC",
        "GOTO",
        "GRANT",
        "GROUP",
        "HAVING",
        "IDENTIFIED",
        "IF",
        "IN",
        "INCREMENT",
        "INDEX",
        "INDEXES",
        "INDICATOR",
        "INITIAL",
        "INITRANS",
        "INSERT",
        "INTERFACE",
        "INTERSECT",
        "INTO",
        "IMMEDIATE",
        "IS",
        "KEY",
        "LEVEL",
        "LIBRARY",
        "LIKE",
        "LIMITED",
        "LOCAL",
        "LOCK",
        "LOG",
        "LOGGING",
        "LONG",
        "LOOP",
        "MASTER",
        "MAXEXTENTS",
        "MAXTRANS",
        "MEMBER",
        "MINEXTENTS",
        "MINUS",
        "MISLABEL",
        "MODE",
        "MODIFY",
        "MULTISET",
        "NEW",
        "NEXT",
        "NO",
        "NOAUDIT",
        "NOCOMPRESS",
        "NOLOGGING",
        "NOPARALLEL",
        "NOT",
        "NOWAIT",
        "NUMBER_BASE",
        "OBJECT",
        "OF",
        "OFF",
        "OFFLINE",
        "ON",
        "ONLINE",
        "ONLY",
        "OPEN",
        "OPTION",
        "OR",
        "ORDER",
        "OUT",
        "PACKAGE",
        "PARALLEL",
        "PARTITION",
        "PCTFREE",
        "PCTINCREASE",
        "PCTUSED",
        "PLS_INTEGER",
        "POSITIVE",
        "POSITIVEN",
        "PRAGMA",
        "PRIMARY",
        "PRIOR",
        "PRIVATE",
        "PRIVILEGES",
        "PROCEDURE",
        "PUBLIC",
        "RAISE",
        "RANGE",
        "RAW",
        "READ",
        "REBUILD",
        "RECORD",
        "REF",
        "REFERENCES",
        "REFRESH",
        "RELEASE",
        "REMR",
        "RENAME",
        "REPLACE",
        "RESOURCE",
        "RESTRICT",
        "RETURN",
        "RETURNING",
        "REVERSE",
        "REVOKE",
        "ROLLBACK",
        "ROW",
        "ROWID",
        "ROWLABEL",
        "ROWNUM",
        "ROWS",
        "RUN",
        "SAVEPOINT",
        "SCHEMA",
        "SEGMENT",
        "SELECT",
        "SEPARATE",
        "SESSION",
        "SET",
        "SHARE",
        "SNAPSHOT",
        "SPACE",
        "SQL",
        "SOME",
        "SPLIT",
        "START",
        "STATEMENT",
        "STORAGE",
        "SUBTYPE",
        "SUCCESSFUL",
        "SYNONYM",
        "TABAUTH",
        "TABLE",
        "TABLES",
        "TABLESPACE",
        "TASK",
        "TERMINATE",
        "THEN",
        "TO",
        "TRIGGER",
        "TRUNCATE",
        "TYPE",
        "UNION",
        "UNIQUE",
        "UNLIMITED",
        "UNRECOVERABLE",
        "UNUSABLE",
        "UPDATE",
        "USE",
        "USING",
        "VALIDATE",
        "VALUE",
        "VALUES",
        "VARIABLE",
        "VIEW",
        "VIEWS",
        "WHEN",
        "WHENEVER",
        "WHERE",
        "WHILE",
        "WITH",
        "WORK",
        "ACOS",
        "ABS",
        "ADD_MONTHS",
        "ASCII",
        "ASIN",
        "ATAN",
        "ATAN2",
        "AVERAGE",
        "BFILENAME",
        "CEIL",
        "CHR",
        "CHARTOROWID",
        "CONCAT",
        "CONVERT",
        "COS",
        "COSH",
        "COUNT",
        "DECODE",
        "DEREF",
        "DUAL",
        "DUMP",
        "DUP_VAL_ON_INDEX",
        "EMPTY",
        "ERROR",
        "EXP",
        "FALSE",
        "FLOOR",
        "FOUND",
        "GLB",
        "GREATEST",
        "HEXTORAW",
        "INITCAP",
        "INSTR",
        "INSTRB",
        "ISOPEN",
        "LAST_DAY",
        "LEAST",
        "LENGTH",
        "LENGHTB",
        "LN",
        "LOWER",
        "LPAD",
        "LTRIM",
        "LUB",
        "MAKE_REF",
        "MAX",
        "MIN",
        "MOD",
        "MONTHS_BETWEEN",
        "NEW_TIME",
        "NEXT_DAY",
        "NEXTVAL",
        "NLS_CHARSET_DECL_LEN",
        "NLS_CHARSET_ID",
        "NLS_CHARSET_NAME",
        "NLS_INITCAP",
        "NLS_LOWER",
        "NLS_SORT",
        "NLS_UPPER",
        "NLSSORT",
        "NO_DATA_FOUND",
        "NOTFOUND",
        "NULL",
        "NVL",
        "OTHERS",
        "POWER",
        "RAWTOHEX",
        "REFTOHEX",
        "ROUND",
        "ROWCOUNT",
        "ROWIDTOCHAR",
        "RPAD",
        "RTRIM",
        "SIGN",
        "SIN",
        "SINH",
        "SQLCODE",
        "SQLERRM",
        "SQRT",
        "SOUNDEX",
        "STDDEV",
        "SUBSTR",
        "SUBSTRB",
        "SUM",
        "SYSDATE",
        "TAN",
        "TANH",
        "TO_CHAR",
        "TO_DATE",
        "TO_LABEL",
        "TO_MULTI_BYTE",
        "TO_NUMBER",
        "TO_SINGLE_BYTE",
        "TRANSLATE",
        "TRUE",
        "TRUNC",
        "UID",
        "UPPER",
        "USER",
        "USERENV",
        "VARIANCE",
        "VSIZE",
        "BFILE",
        "BLOB",
        "CHARACTER",
        "CLOB",
        "DEC",
        "FLOAT",
        "INT",
        "INTEGER",
        "MLSLABEL",
        "NATURAL",
        "NATURALN",
        "NCHAR",
        "NCLOB",
        "NUMBER",
        "NUMERIC",
        "NVARCHAR2",
        "REAL",
        "ROWTYPE",
        "SIGNTYPE",
        "SMALLINT",
        "STRING",
        "VARCHAR",
        "VARCHAR2"};
            this.autocompleteMenu1.MinFragmentLength = 1;
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.SaveAsToolStripMenuItem,
            this.SettingToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.TempToolStripMenuItem});
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.ShortcutKeyDisplayString = "";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.ToolStripMenuItem1.Text = "開啟";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.FileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.FileToolStripMenuItem.Text = "檔案";
            this.FileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // TempToolStripMenuItem
            // 
            this.TempToolStripMenuItem.Name = "TempToolStripMenuItem";
            this.TempToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+O";
            this.TempToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.TempToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.TempToolStripMenuItem.Text = "暫存";
            this.TempToolStripMenuItem.Click += new System.EventHandler(this.TempToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.SaveAsToolStripMenuItem.Text = "存檔";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.SettingToolStripMenuItem.Text = "設定";
            this.SettingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ExitToolStripMenuItem.Text = "結束";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "文字文件(*.txt)|*.txt|All files (*.*)|*.*\"";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MessageListBox
            // 
            this.MessageListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.MessageListBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MessageListBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MessageListBox.FormattingEnabled = true;
            this.MessageListBox.HorizontalScrollbar = true;
            this.MessageListBox.ItemHeight = 20;
            this.MessageListBox.Location = new System.Drawing.Point(17, 532);
            this.MessageListBox.Name = "MessageListBox";
            this.MessageListBox.Size = new System.Drawing.Size(771, 104);
            this.MessageListBox.TabIndex = 11;
            this.MessageListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageListBox_KeyDown);
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.Red;
            this.ConnectButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ConnectButton.Location = new System.Drawing.Point(17, 120);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(97, 29);
            this.ConnectButton.TabIndex = 12;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Enabled = false;
            this.ExecuteButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExecuteButton.Location = new System.Drawing.Point(120, 120);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(97, 29);
            this.ExecuteButton.TabIndex = 13;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.Enabled = false;
            this.RollbackButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RollbackButton.Location = new System.Drawing.Point(17, 155);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(97, 29);
            this.RollbackButton.TabIndex = 14;
            this.RollbackButton.Text = "Rollback";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // CommitButton
            // 
            this.CommitButton.Enabled = false;
            this.CommitButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CommitButton.Location = new System.Drawing.Point(120, 155);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(97, 29);
            this.CommitButton.TabIndex = 15;
            this.CommitButton.Text = "Commit";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SelectAllToolStripMenuItem.Text = "全選";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 644);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.MessageListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_symbol);
            this.Controls.Add(this.convent_button);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.richTextBox_output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_inputRepeat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "沒路用小工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChange);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_inputRepeat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_output;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button convent_button;
        private System.Windows.Forms.TextBox textBox_symbol;
        private System.Windows.Forms.Label label3;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ListBox MessageListBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TempToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
    }
}

