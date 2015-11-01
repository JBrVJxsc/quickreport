using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Neusoft.NFC.Management;
using QuickReportLib.Objects;
using QuickReportLib.Managers;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// ���ݿ�����ࡣ
    /// </summary>
    internal class DataBaseManager : Database
    {
        internal static DataBaseManager GlobalDataBaseManager = new DataBaseManager();

        /// <summary>
        /// ��ȡ���б���Ļ�����Ϣ��
        /// </summary>
        /// <returns>�����ϡ�ֻ����������Ϣ��δ����Sql��Content��</returns>
        public List<Report> QueryAllQuickReports()
        {
            List<Report> list;
            string sql = global::QuickReportLib.Properties.Resources.SQL_QueryAllReports;
            try
            {
                ExecQuery(sql);
                list = new List<Report>();
                while (Reader.Read())
                {
                    Report report = new Report();
                    report.ID = Reader[0].ToString();
                    report.Name = Reader[1].ToString();
                    report.Type = Reader[2].ToString();
                    report.Version = Convert.ToDecimal(Reader[3].ToString());
                    report.IsValid = Reader[4].ToString();
                    list.Add(report);
                }
            }
            catch (Exception e)
            {
                Err = "��ȡ���б���ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return list;
        }

        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        /// <param name="id">�����ID��</param>
        /// <returns>����</returns>
        public Report QueryReportByID(string id)
        {
            Report report=null;
            string sql = global::QuickReportLib.Properties.Resources.SQL_QueryReportByID;
            sql = string.Format(sql, id);
            try
            {
                ExecQuery(sql);
                while (Reader.Read())
                {
                    report = new Report();
                    report = XmlManager.DeserializeReport(EncryptionManager.Decrypt(Encoding.Default.GetString((byte[])Reader[4]))) as Report;
                    report.ID = Reader[0].ToString();
                    report.Name = Reader[1].ToString();
                    report.Type = Reader[2].ToString();
                    report.Version = Convert.ToDecimal(Reader[3].ToString());
                    report.IsValid = Reader[5].ToString();
                }
            }
            catch (Exception e)
            {
                Err = "����ID��ȡ����ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return report;
        }

        /// <summary>
        /// ���ݲ���Ա�����뱨��ID��ȡ���á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportID">����ID��</param>
        /// <returns>���á�</returns>
        public string QuerySettingByOperCodeAndReportID(string operCode,string reportID)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_QuerySettingByOperCodeAndReportID;
            sql = string.Format(sql, operCode,reportID);
            try
            {
                ExecQuery(sql);
                while (Reader.Read())
                {
                    return Encoding.Default.GetString((byte[])Reader[0]);
                }
            }
            catch (Exception e)
            {
                Err = "��ȡ����ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return null;
        }     

        /// <summary>
        /// ���ݱ���ID��ȡ�����е����á�
        /// </summary>
        /// <param name="reportID">����ID��</param>
        /// <returns>���á�</returns>
        public string QuerySharedSettingByReportID(string reportID)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_QuerySharedSettingByReportID;
            sql = string.Format(sql, reportID);
            try
            {
                ExecQuery(sql);
                while (Reader.Read())
                {
                    return Encoding.Default.GetString((byte[])Reader[0]);
                }
            }
            catch (Exception e)
            {
                Err = "��ȡ��������ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return null;
        }

        /// <summary>
        /// ���뱨��
        /// </summary>
        /// <param name="quickReport">����ʵ�塣</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int InsertQuickReport(Report report)
        {
            int i = InsertQuickReportBaseInfo(report);
            if (i < 0)
                return i;
            byte[] content = Encoding.Default.GetBytes(EncryptionManager.Encrypt(XmlManager.SerializeReport(report)));
            return UpdateQuickReportContentByID(report.ID, content);
        }

        /// <summary>
        /// �������á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportID">����ID��</param>
        /// <param name="content">���ݡ�</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int InsertSetting(string operCode,string reportID,string content)
        {
            int i = InsertSettingBaseInfo(operCode,reportID);
            if (i < 0)
                return i;
            return UpdateSettingByOperCodeAndReportID(operCode, reportID, content);
        }

        /// <summary>
        /// ���±���
        /// </summary>
        /// <param name="quickReport">����ʵ�塣</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int UpdateQuickReport(Report report)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_UpdateQuickReport;
            sql = string.Format(sql,report.ID,report.Name,report.Type,report.Version,report.IsValid);
            try
            {
                byte[] content = Encoding.Default.GetBytes(EncryptionManager.Encrypt(XmlManager.SerializeReport(report)));
                return InputBlob(sql, content);
            }
            catch (Exception e)
            {
                Err = "���뱨��ʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// �������á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportID">����ID��</param>
        /// <param name="content">���ݡ�</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int UpdateSettingByOperCodeAndReportID(string operCode,string reportID,string content)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_UpdateSettingByOperCodeAndReportID;
            sql = string.Format(sql, operCode,reportID );
            try
            {
                byte[] c = Encoding.Default.GetBytes(content);
                return InputBlob(sql, c);
            }
            catch (Exception e)
            {
                Err = "��������ʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// ���¹������õı�־λ��
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportID">����ID��</param>
        /// <param name="flag">��־λ��</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int UpdateSharedSettingFlagByOperCodeAndReportID(string operCode, string reportID, string flag)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_UpdateSharedSettingFlagByOperCodeAndReportID;
            sql = string.Format(sql, operCode,reportID,flag);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "���¹������ñ�־λʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// ��ȡ���б������
        /// </summary>
        /// <returns>���б������</returns>
        public ArrayList QueryAllReportTypes()
        {
            ArrayList list;
            string sql = global::QuickReportLib.Properties.Resources.SQL_QueryAllReportTypes;
            try
            {
                
                ExecQuery(sql);
                list = new ArrayList();
                while (Reader.Read())
                {
                    list.Add(Reader[0].ToString());
                }
            }
            catch (Exception e)
            {
                Err = "��ȡ���б������ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return list;
        }

        /// <summary>
        /// ��ѯ�Ƿ���ڱ�QUICKREPORT_REPORTS��
        /// </summary>
        /// <returns>С�ڵ���0���򲻴��ڡ�</returns>
        public int QueryTableExistQUICKREPORT_REPORTS()
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_QueryTableExistQUICKREPORT_REPORTS;
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "��ѯ�Ƿ���ڱ�QUICKREPORT_REPORTSʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ��ѯ�Ƿ���ڱ�QUICKREPORT_SETTINGS��
        /// </summary>
        /// <returns>С�ڵ���0���򲻴��ڡ�</returns>
        public int QueryTableExistQUICKREPORT_SETTINGS()
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_QueryTableExistQUICKREPORT_SETTINGS;
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "��ѯ�Ƿ���ڱ�QUICKREPORT_SETTINGSʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ���ݲ���Ա����ͱ���ID��ѯ�Ƿ�������á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportId">����ID��</param>
        /// <returns>С�ڵ���0���򲻴��ڡ�</returns>
        public int QuerySettingExist(string operCode,string reportId)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_QuerySettingExist;
            sql = string.Format(sql, operCode, reportId);
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "��ѯ�Ƿ��������ʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ���ݲ���Ա����ͱ���ID��ѯ�Ƿ���ڹ�������á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportId">����ID��</param>
        /// <returns>�����򷵻ز���Ա������null�򲻴��ڡ�</returns>
        public string QuerySharedSettingExistByOperCodeAndReportID(string operCode, string reportId)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_QuerySharedSettingExistByOperCodeAndReportID;
            string name = null;
            sql = string.Format(sql, operCode, reportId);
            ExecQuery(sql);
            try
            {
                while (Reader.Read())
                {
                    name = Reader[0].ToString();
                }
            }
            catch (Exception e)
            {
                Err = "��ѯ�Ƿ��������ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return name;
        }

        /// <summary>
        /// ���ݱ���ID��ѯ�Ƿ���ڹ�������á�
        /// </summary>
        /// <param name="reportId">����ID��</param>
        /// <returns>�����򷵻ز���Ա������null�򲻴��ڡ�</returns>
        public string QuerySharedSettingExistByReportID( string reportId)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_QuerySharedSettingExistByReportID;
            string name = null;
            sql = string.Format(sql, reportId);
            ExecQuery(sql);
            try
            {
                while (Reader.Read())
                {
                    name = Reader[0].ToString();
                }
            }
            catch (Exception e)
            {
                Err = "��ѯ�Ƿ��������ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return name;
        }

        /// <summary>
        /// ������QUICKREPORT_REPORTS��
        /// </summary>
        /// <returns>С�ڵ���0��ʧ�ܡ�</returns>
        public int CreateTableQUICKREPORT_REPORTS()
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_CreateTableQUICKREPORT_REPORTS;
            try
            {
                sql = sql.Substring(0, sql.LastIndexOf(';'));
                string[] sqls = sql.Split(';');
                for (int i = 0; i < sqls.Length; i++)
                {
                    int j = ExecNoQuery(sqls[i]);
                    if (j < 0)
                        return j;
                }
                return 1;
            }
            catch (Exception e)
            {
                Err = "������QUICKREPORT_REPORTSʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// ������QUICKREPORT_SETTINGS��
        /// </summary>
        /// <returns>С�ڵ���0��ʧ�ܡ�</returns>
        public int CreateTableQUICKREPORT_SETTINGS()
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_CreateTableQUICKREPORT_SETTINGS;
            try
            {
                sql = sql.Substring(0, sql.LastIndexOf(';'));
                string[] sqls = sql.Split(';');
                for (int i = 0; i < sqls.Length; i++)
                {
                    int j = ExecNoQuery(sqls[i]);
                    if (j < 0)
                        return j;
                }
                return 1;
            }
            catch (Exception e)
            {
                Err = "������QUICKREPORT_SETTINGSʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// ����IDɾ������
        /// </summary>
        /// <param name="quickReport">����ID��</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int DeleteQuickReportByID(string id)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_DeleteQuickReportByID;
            sql = string.Format(sql, id);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "ɾ������ʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// ���뱨��Ļ�����Ϣ��
        /// </summary>
        /// <param name="quickReport">����</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        private int InsertQuickReportBaseInfo(Report report)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_InsertQuickReportBaseInfo;
            sql = string.Format(sql, report.ID, report.Name, report.Type,report.Version, report.IsValid);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "���뱨��ʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// �������õĻ�����Ϣ��
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportId">����ID��</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        private int InsertSettingBaseInfo(string operCode, string reportId)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_InsertSettingBaseInfo;
            sql = string.Format(sql, operCode, reportId);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "��������ʧ�ܡ�" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// ����ID���±����Content��
        /// </summary>
        /// <param name="id">����ID��</param>
        /// <param name="content">����Content��</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        private int UpdateQuickReportContentByID(string id,byte[] content)
        {
            string sql = global::QuickReportLib.Properties.Resources.SQL_UpdateQuickReportContentByID;
            sql = string.Format(sql, id);
            try
            {
                return InputBlob(sql, content);
            }
            catch (Exception e)
            {
                Err = "���뱨��ʧ�ܡ�" + e.Message;
                return -1;
            }
        }
    }
}
