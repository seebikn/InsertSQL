using System.Reflection;
using System.Text.RegularExpressions;
using InsertSQL.Models;
using Microsoft.VisualBasic;

namespace InsertSQL.Controllers
{
    internal class MainController
    {
        private readonly MainModel model;
        private readonly MainForm view;
        private readonly IniController iniController;

        public MainController(string iniFilePath)
        {
            model = new MainModel();
            view = new MainForm();
            iniController = new IniController(iniFilePath);

            view.OnHandleCreateInsertSql += GenerateSql;
            view.FormClosing += HandleSaveWindowSettings;
            view.Load += HandleRestoreWindowSettings;
        }

        public void Run()
        {
            {
                // アセンブリ名とバージョンを取得
                Assembly assembly = Assembly.GetExecutingAssembly();
                AssemblyName assemblyName = assembly.GetName();
                string appName = assemblyName.Name!;
                Version version = assemblyName.Version!;
                string majorVersion = version.Major.ToString();
                string minorVersion = version.Minor.ToString();

                // フォームのタイトルを設定
                view.Text = $"{appName} - Version {majorVersion}.{minorVersion}";
            }
            {
                // iniファイルを読み込み
                this.LoadSettings();
            }

            Application.Run(view);
        }

        private void LoadSettings()
        {
            iniController.InitializeFile();
        }

        /// <summary>
        /// SQL文を生成する処理を統括します。
        /// テーブル名、データ、オプションの設定を取得し、モデルを使用してSQL文を生成します。
        /// </summary>
        public void GenerateSql(object? sender, EventArgs e)
        {
            try
            {
                // テーブル名を取得
                string tableName = view.GetTableName().Trim();
                if (string.IsNullOrEmpty(tableName)) throw new Exception("テーブル名が空です");

                // 入力データを取得
                string inputData = Regex.Replace(view.GetInputData(), ControlChars.Lf.ToString(), ControlChars.CrLf.ToString());
                if (inputData.Length == 0) throw new Exception("データがありません");

                string[] rows = model.ParseInputData(inputData);

                // 1行目の列名取得
                string[]? columnNames = null;
                if (view.IsColumnNameChecked())
                {
                    columnNames = model.ParseRow(rows[0]);
                    rows = rows.Skip(1).ToArray();
                }

                // Insert文作成
                bool removeLineBreaks = view.IsRemoveLineBreaksChecked();
                var sqlStatements = new List<string>();
                foreach (var row in rows)
                {
                    if (string.IsNullOrWhiteSpace(row))
                    {
                        sqlStatements.Add(string.Empty);
                    }
                    else
                    {
                        var sql = model.GenerateSql(tableName, row, columnNames!, view.IsNullChecked(), view.IsDateChecked(), removeLineBreaks);
                        sqlStatements.Add(sql);
                    }
                }

                // Insert文をViewへ設定
                view.SetGeneratedSql(string.Join(ControlChars.CrLf.ToString(), sqlStatements) + ControlChars.CrLf.ToString());
            }
            catch (Exception ex)
            {
                view.ShowError(ex.Message);
            }
        }

        private void HandleSaveWindowSettings(object? sender, EventArgs e)
        {
            // viewの位置とサイズを保存
            iniController.Set(Constants.IniMain.section, Constants.IniMain.x, view.Location.X);
            iniController.Set(Constants.IniMain.section, Constants.IniMain.y, view.Location.Y);
            iniController.Set(Constants.IniMain.section, Constants.IniMain.width, view.Width);
            iniController.Set(Constants.IniMain.section, Constants.IniMain.height, view.Height);
            iniController.Set(Constants.IniMain.section, Constants.IniMain.maximized, view.WindowState == FormWindowState.Maximized);

            iniController.Set(Constants.IniMain.section, Constants.IniMain.IsNullChecked, view.IsNullChecked());
            iniController.Set(Constants.IniMain.section, Constants.IniMain.IsDateChecked, view.IsDateChecked());
            iniController.Set(Constants.IniMain.section, Constants.IniMain.IsColumnNameChecked, view.IsColumnNameChecked());
            iniController.Set(Constants.IniMain.section, Constants.IniMain.IsRemoveLineBreaksChecked, view.IsRemoveLineBreaksChecked());
        }

        private void HandleRestoreWindowSettings(object? sender, EventArgs e)
        {
            // viewの位置とサイズ
            int x = iniController.Get(Constants.IniMain.section, Constants.IniMain.x, 50);
            int y = iniController.Get(Constants.IniMain.section, Constants.IniMain.y, 50);
            int width = iniController.Get(Constants.IniMain.section, Constants.IniMain.width, 816);
            int height = iniController.Get(Constants.IniMain.section, Constants.IniMain.height, 456);
            bool isMaximized = iniController.Get(Constants.IniMain.section, Constants.IniMain.maximized, false);

            if (isMaximized)
            {
                // 最大化
                view.WindowState = FormWindowState.Maximized;
            }
            else
            {
                view.StartPosition = FormStartPosition.Manual;
                view.Location = new System.Drawing.Point(x, y);
                view.Size = new System.Drawing.Size(width, height);
            }
        }
    }
}
