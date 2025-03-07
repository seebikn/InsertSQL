namespace InsertSQL
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextTable = new TextBox();
            label1 = new Label();
            CheckboxNull = new CheckBox();
            CheckboxDate = new CheckBox();
            CheckboxColumnName = new CheckBox();
            ButtonCreateSql = new Button();
            TextData = new TextBox();
            TextSql = new TextBox();
            CheckboxRemoveLineBreaks = new CheckBox();
            SuspendLayout();
            // 
            // TextTable
            // 
            TextTable.Location = new Point(72, 6);
            TextTable.Name = "TextTable";
            TextTable.Size = new Size(174, 23);
            TextTable.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "テーブル名";
            // 
            // CheckboxNull
            // 
            CheckboxNull.AutoSize = true;
            CheckboxNull.Location = new Point(252, 8);
            CheckboxNull.Name = "CheckboxNull";
            CheckboxNull.Size = new Size(94, 19);
            CheckboxNull.TabIndex = 2;
            CheckboxNull.Text = "空文字はNull";
            CheckboxNull.UseVisualStyleBackColor = true;
            // 
            // CheckboxDate
            // 
            CheckboxDate.AutoSize = true;
            CheckboxDate.Checked = true;
            CheckboxDate.CheckState = CheckState.Checked;
            CheckboxDate.Location = new Point(352, 8);
            CheckboxDate.Name = "CheckboxDate";
            CheckboxDate.Size = new Size(85, 19);
            CheckboxDate.TabIndex = 3;
            CheckboxDate.Text = "toDate処理";
            CheckboxDate.UseVisualStyleBackColor = true;
            // 
            // CheckboxColumnName
            // 
            CheckboxColumnName.AutoSize = true;
            CheckboxColumnName.Location = new Point(450, 8);
            CheckboxColumnName.Name = "CheckboxColumnName";
            CheckboxColumnName.Size = new Size(90, 19);
            CheckboxColumnName.TabIndex = 4;
            CheckboxColumnName.Text = "1行目は列名";
            CheckboxColumnName.UseVisualStyleBackColor = true;
            // 
            // ButtonCreateSql
            // 
            ButtonCreateSql.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonCreateSql.Location = new Point(663, 6);
            ButtonCreateSql.Name = "ButtonCreateSql";
            ButtonCreateSql.Size = new Size(125, 23);
            ButtonCreateSql.TabIndex = 8;
            ButtonCreateSql.Text = "Create Insert SQL";
            ButtonCreateSql.UseVisualStyleBackColor = true;
            // 
            // TextData
            // 
            TextData.AcceptsTab = true;
            TextData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextData.Location = new Point(12, 35);
            TextData.Multiline = true;
            TextData.Name = "TextData";
            TextData.Size = new Size(776, 209);
            TextData.TabIndex = 6;
            TextData.WordWrap = false;
            // 
            // TextSql
            // 
            TextSql.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextSql.Location = new Point(12, 250);
            TextSql.Multiline = true;
            TextSql.Name = "TextSql";
            TextSql.ReadOnly = true;
            TextSql.Size = new Size(776, 155);
            TextSql.TabIndex = 7;
            TextSql.WordWrap = false;
            // 
            // CheckboxRemoveLineBreaks
            // 
            CheckboxRemoveLineBreaks.AutoSize = true;
            CheckboxRemoveLineBreaks.Location = new Point(546, 8);
            CheckboxRemoveLineBreaks.Name = "CheckboxRemoveLineBreaks";
            CheckboxRemoveLineBreaks.Size = new Size(74, 19);
            CheckboxRemoveLineBreaks.TabIndex = 5;
            CheckboxRemoveLineBreaks.Text = "改行削除";
            CheckboxRemoveLineBreaks.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 417);
            Controls.Add(CheckboxRemoveLineBreaks);
            Controls.Add(TextSql);
            Controls.Add(TextData);
            Controls.Add(ButtonCreateSql);
            Controls.Add(CheckboxColumnName);
            Controls.Add(CheckboxDate);
            Controls.Add(CheckboxNull);
            Controls.Add(label1);
            Controls.Add(TextTable);
            Name = "MainForm";
            Text = "Insert SQL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextTable;
        private Label label1;
        private CheckBox CheckboxNull;
        private CheckBox CheckboxDate;
        private CheckBox CheckboxColumnName;
        private Button ButtonCreateSql;
        private TextBox TextData;
        private TextBox TextSql;
        private CheckBox CheckboxRemoveLineBreaks;
    }
}
