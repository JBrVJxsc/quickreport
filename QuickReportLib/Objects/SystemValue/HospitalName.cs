using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Managers;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// 医院名称。
    /// </summary>
    internal class HospitalName : BaseSystemValueObject
    {
        private string sql = "Select FUN_GET_HOSPITALNAME From Dual";
        private string err = "未获取到医院名称，请检查数据库中是否存在函数：FUN_GET_HOSPITALNAME。";

        public override string ValueID
        {
            get
            {
                return GetType().Name;
            }
        }

        public override string ValueName
        {
            get 
            {
                return "医院名称"; 
            }
        }

        public override string Value
        {
            get 
            {
                if (DataBaseManager.GlobalDataBaseManager.ExecQuery(sql) < 0)
                    return err;
                try
                {
                    while (DataBaseManager.GlobalDataBaseManager.Reader.Read())
                    {
                        return DataBaseManager.GlobalDataBaseManager.Reader[0].ToString();
                    }
                }
                catch(Exception e)
                {
                    return "获取医院名称失败，原因：" + e.Message;
                }
                finally
                {
                    DataBaseManager.GlobalDataBaseManager.Reader.Close();
                }
                return err;
            }
        }

        public override SystemValueType ValueType
        {
            get
            {
                return SystemValueType.Department; 
            }
        }
    }
}
