using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class HospitalName : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        private string sql = "Select FUN_GET_HOSPITALNAME From Dual";
        private string err = "未获取到医院名称，请检查数据库中是否存在函数：FUN_GET_HOSPITALNAME。";

        #region ISystemValue 成员

        public string ValueID
        {
            get { return GetType().Name; }
        }

        public string ValueName
        {
            get { return "医院名称"; }
        }

        public string Value
        {
            get 
            {
                if (ExecQuery(sql) < 0)
                    return err;
                try
                {
                    while (Reader.Read())
                    {
                        return Reader[0].ToString();
                    }
                }
                catch(Exception e)
                {
                    return "获取医院名称失败，原因：" + e.Message;
                }
                finally
                {
                    Reader.Close();
                }
                return err;
            }
        }

        public SystemValueType SystemValueType
        {
            get { return SystemValueType.Dept; }
        }

        #endregion

        public override string ToString()
        {
            return ValueName;
        }
    }
}
