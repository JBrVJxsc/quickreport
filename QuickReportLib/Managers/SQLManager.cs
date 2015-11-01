using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Managers;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// 提供与SQL相关的常用方法的静态类。
    /// </summary>
    internal static class SQLManager
    {
        /// <summary>
        /// 根据字符串获得该字符串在SQL中的表示方式。
        /// </summary>
        /// <param name="code">字符串。</param>
        /// <param name="type">Code的类型。</param>
        /// <returns>其在SQL中的表示方式。</returns>
        public static string GetSQLCode(string code, SQLCodeType type)
        {
            return "[" + type.ToString() + "-" + code + "]";
        }

        /// <summary>
        /// 将SQL解析为列。
        /// </summary>
        /// <param name="sql">SQL语句。</param>
        /// <param name="err">错误信息。</param>
        /// <returns>解析出来的列。</returns>
        public static List<Column> ParseSQLToColumns(string sql,ref string err)
        {
            sql = SystemValueManager.Translate(sql);
            sql = "Select * From ( \n " + sql + " \n )  Where 1<>1";
            DataSet ds = new DataSet();
            int i = DataBaseManager.GlobalDataBaseManager.ExecQuery(sql, ref ds);
            if (i < 0 || ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                err = DataBaseManager.GlobalDataBaseManager.Err;
                return null;
            }
            DataTable dt = ds.Tables[0];
            List<Column> columnList = new List<Column>();
            ArrayList repeaterTest = new ArrayList();
            for (int index = 0; index < dt.Columns.Count; index++)
            {
                string columnName = dt.Columns[index].ColumnName;
                Type columnDataType=dt.Columns[index].DataType;
                if (repeaterTest.Contains(columnName))
                {
                    err = "SQL中不能含有相同名称的列。";
                    return null;
                }
                repeaterTest.Add(columnName);
                Column column = new Column();
                column.ID = columnName;
                column.Name = columnName;
                column.SortID = index;
                if (columnDataType == typeof(Decimal) || columnDataType == typeof(Int32))
                {
                    column.IsNumber = true;
                }
                column.SetDataType(columnDataType);
                columnList.Add(column);
            }
            return columnList;
        }
    }
}
