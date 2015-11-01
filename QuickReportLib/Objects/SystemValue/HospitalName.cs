using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Managers;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// ҽԺ���ơ�
    /// </summary>
    internal class HospitalName : BaseSystemValueObject
    {
        private string sql = "Select FUN_GET_HOSPITALNAME From Dual";
        private string err = "δ��ȡ��ҽԺ���ƣ��������ݿ����Ƿ���ں�����FUN_GET_HOSPITALNAME��";

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
                return "ҽԺ����"; 
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
                    return "��ȡҽԺ����ʧ�ܣ�ԭ��" + e.Message;
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
