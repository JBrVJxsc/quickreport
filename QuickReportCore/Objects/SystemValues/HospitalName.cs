using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class HospitalName : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        private string sql = "Select FUN_GET_HOSPITALNAME From Dual";
        private string err = "δ��ȡ��ҽԺ���ƣ��������ݿ����Ƿ���ں�����FUN_GET_HOSPITALNAME��";

        #region ISystemValue ��Ա

        public string ValueID
        {
            get { return GetType().Name; }
        }

        public string ValueName
        {
            get { return "ҽԺ����"; }
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
                    return "��ȡҽԺ����ʧ�ܣ�ԭ��" + e.Message;
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
