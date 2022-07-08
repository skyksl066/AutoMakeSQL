namespace AutoMakeSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_inputRepeat = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_output = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_symbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.richTextBox_inputHeader = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input";
            // 
            // richTextBox_inputRepeat
            // 
            this.richTextBox_inputRepeat.AcceptsTab = true;
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox_inputRepeat, this.autocompleteMenu1);
            this.richTextBox_inputRepeat.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox_inputRepeat.Location = new System.Drawing.Point(17, 120);
            this.richTextBox_inputRepeat.Name = "richTextBox_inputRepeat";
            this.richTextBox_inputRepeat.Size = new System.Drawing.Size(358, 282);
            this.richTextBox_inputRepeat.TabIndex = 1;
            this.richTextBox_inputRepeat.Text = "UPDATE DUAL SET=\'{0}\' WHERE A=\'{1}\' AND B=\'{2}\';";
            this.richTextBox_inputRepeat.TextChanged += new System.EventHandler(this.richTextBox_input_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(426, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output";
            // 
            // richTextBox_output
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox_output, null);
            this.richTextBox_output.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox_output.Location = new System.Drawing.Point(430, 122);
            this.richTextBox_output.Name = "richTextBox_output";
            this.richTextBox_output.Size = new System.Drawing.Size(358, 383);
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
            this.textBox_path.Location = new System.Drawing.Point(13, 13);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(672, 29);
            this.textBox_path.TabIndex = 4;
            // 
            // button_browse
            // 
            this.button_browse.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_browse.Location = new System.Drawing.Point(691, 13);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(97, 29);
            this.button_browse.TabIndex = 5;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(691, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Convent";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_symbol
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.textBox_symbol, null);
            this.textBox_symbol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_symbol.Location = new System.Drawing.Point(117, 54);
            this.textBox_symbol.Name = "textBox_symbol";
            this.textBox_symbol.Size = new System.Drawing.Size(258, 29);
            this.textBox_symbol.TabIndex = 7;
            this.textBox_symbol.Text = "$$$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 57);
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
            // richTextBox_inputHeader
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox_inputHeader, this.autocompleteMenu1);
            this.richTextBox_inputHeader.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox_inputHeader.Location = new System.Drawing.Point(17, 408);
            this.richTextBox_inputHeader.Name = "richTextBox_inputHeader";
            this.richTextBox_inputHeader.Size = new System.Drawing.Size(358, 97);
            this.richTextBox_inputHeader.TabIndex = 9;
            this.richTextBox_inputHeader.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 517);
            this.Controls.Add(this.richTextBox_inputHeader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_symbol);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.richTextBox_output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_inputRepeat);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "沒路用小工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChange);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_symbol;
        private System.Windows.Forms.Label label3;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private System.Windows.Forms.RichTextBox richTextBox_inputHeader;
    }
}

