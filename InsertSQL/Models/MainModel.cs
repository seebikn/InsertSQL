namespace InsertSQL.Models
{
    internal class MainModel
    {

        /// <summary>
        /// 入力データを行単位で分割し、必要に応じて複数行にまたがるデータを結合します。
        /// </summary>
        /// <param name="inputData">入力されたデータ全体</param>
        /// <returns>行ごとに分割されたデータの配列</returns>
        public string[] ParseInputData(string inputData)
        {
            var rows = new System.Collections.Generic.List<string>();
            var currentRow = String.Empty;
            bool inQuotes = false;

            foreach (var line in inputData.Split(new[] { "\r\n" }, StringSplitOptions.None))
            {
                if (inQuotes)
                {
                    currentRow += "\r\n" + line;
                    if (line.Count(c => c == '"') % 2 != 0) // クォートが閉じたかチェック
                        inQuotes = false;
                }
                else
                {
                    if (line.Count(c => c == '"') % 2 != 0) // クォートが開いたかチェック
                    {
                        inQuotes = true;
                        currentRow = line;
                    }
                    else
                    {
                        rows.Add(line);
                    }
                }

                if (!inQuotes && !string.IsNullOrEmpty(currentRow))
                {
                    rows.Add(currentRow);
                    currentRow = String.Empty;
                }
            }

            return rows.ToArray();
        }

        /// <summary>
        /// 行データを列ごとに分割します。
        /// </summary>
        /// <param name="row">分割する1行分のデータ</param>
        /// <returns>列ごとに分割されたデータの配列</returns>
        public string[] ParseRow(string row)
        {
            var values = new System.Collections.Generic.List<string>();
            var currentField = String.Empty;
            bool inQuotes = false;

            foreach (var c in row)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == '\t' && !inQuotes)
                {
                    values.Add(currentField.TrimEnd('\r', '\n'));
                    currentField = String.Empty;
                }
                else
                {
                    currentField += c;
                }
            }

            if (!string.IsNullOrEmpty(currentField))
                values.Add(currentField.TrimEnd('\r', '\n'));

            return values.ToArray();
        }

        /// <summary>
        /// SQL文を生成します。
        /// </summary>
        /// <param name="tableName">テーブル名</param>
        /// <param name="row">1行分のデータ</param>
        /// <param name="columnNames">列名の配列</param>
        /// <param name="treatNullAsEmpty">空文字をNULLとして扱うかどうか</param>
        /// <param name="treatDateAsToDate">日付をTO_DATEとして扱うかどうか</param>
        /// <param name="removeLineBreaks">データ内の改行を削除するかどうか</param>
        /// <returns>生成されたSQL文</returns>
        public string GenerateSql(string tableName, string row, string[] columnNames, bool treatNullAsEmpty, bool treatDateAsToDate, bool removeLineBreaks)
        {
            string[] values = ParseRow(row).Select(value => ProcessValue(value, treatNullAsEmpty, treatDateAsToDate, removeLineBreaks)).ToArray();

            if (columnNames == null)
            {
                return $"INSERT INTO {tableName} VALUES ({string.Join(", ", values)});";
            }
            else
            {
                return $"INSERT INTO {tableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", values)});";
            }
        }

        /// <summary>
        /// 値を適切な形式に変換します。
        /// </summary>
        /// <param name="value">変換する値</param>
        /// <param name="treatNullAsEmpty">空文字をNULLとして扱うかどうか</param>
        /// <param name="treatDateAsToDate">日付をTO_DATEとして扱うかどうか</param>
        /// <param name="removeLineBreaks">データ内の改行を削除するかどうか</param>
        /// <returns>変換された値</returns>
        private string ProcessValue(string value, bool treatNullAsEmpty, bool treatDateAsToDate, bool removeLineBreaks)
        {
            value = value.Trim('"');

            if (removeLineBreaks)
            {
                value = value.Replace("\r", "").Replace("\n", "");
            }

            if (string.IsNullOrEmpty(value))
            {
                return treatNullAsEmpty ? "NULL" : "\"\"";
            }

            if (treatDateAsToDate && DateTime.TryParse(value, out DateTime date))
            {
                // 時刻が含まれる場合はフォーマットに時分秒を追加
                string format = date.TimeOfDay.TotalSeconds > 0
                    ? $"TO_DATE('{date:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS')"
                    : $"TO_DATE('{date:yyyy-MM-dd}', 'YYYY-MM-DD')";
                return format;
            }

            return $"'{value.Replace("\"", "\"\"").TrimEnd('\r', '\n')}'";
        }

    }
}
