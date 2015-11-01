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
    /// �ṩ��SQL��صĳ��÷����ľ�̬�ࡣ
    /// </summary>
    internal static class SQLManager
    {
        /// <summary>
        /// �����ַ�����ø��ַ�����SQL�еı�ʾ��ʽ��
        /// </summary>
        /// <param name="code">�ַ�����</param>
        /// <param name="type">Code�����͡�</param>
        /// <returns>����SQL�еı�ʾ��ʽ��</returns>
        public static string GetSQLCode(string code, SQLCodeType type)
        {
            return "[" + type.ToString() + "-" + code + "]";
        }

        /// <summary>
        /// ��SQL����Ϊ�С�
        /// </summary>
        /// <param name="sql">SQL��䡣</param>
        /// <param name="err">������Ϣ��</param>
        /// <returns>�����������С�</returns>
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
                    err = "SQL�в��ܺ�����ͬ���Ƶ��С�";
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
