using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSQL
{
    public static class Constants
    {
        /// <summary>
        /// ウィンドウの表示設定(config.ini)
        /// </summary>
        public static class IniMain
        {
            public const string section = "Window_Setting";
            public const string x = "X";
            public const string y = "Y";
            public const string width = "Width";
            public const string height = "Height";
            public const string maximized = "Maximized";

            public const string IsNullChecked = "IsNullChecked";
            public const string IsDateChecked = "IsDateChecked";
            public const string IsColumnNameChecked = "IsColumnNameChecked";
            public const string IsRemoveLineBreaksChecked = "IsRemoveLineBreaksChecked";
        }

    }

}
