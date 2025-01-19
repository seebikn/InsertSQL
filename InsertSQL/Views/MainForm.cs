namespace InsertSQL
{
    public partial class MainForm : Form
    {
        public event EventHandler? OnHandleCreateInsertSql;

        public MainForm()
        {
            InitializeComponent();

            ButtonCreateSql.Click += (s, e) => OnHandleCreateInsertSql?.Invoke(ButtonCreateSql, EventArgs.Empty);
        }

        public string GetTableName() => TextTable.Text;
        public string GetInputData() => TextData.Text;
        public bool IsNullChecked() => CheckboxNull.Checked;
        public bool IsDateChecked() => CheckboxDate.Checked;
        public bool IsColumnNameChecked() => CheckboxColumnName.Checked;
        public bool IsRemoveLineBreaksChecked() => CheckboxRemoveLineBreaks.Checked;

        public void SetGeneratedSql(string sql)
        {
            TextSql.Text = sql;
            TextSql.Focus();
            TextSql.SelectAll();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
