using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace QuickReportCore.Managers
{
    /// <summary>
    /// ��ݱ����ҵ���ࡣ
    /// </summary>
    internal class QuickReportManager : Neusoft.NFC.Management.Database
    {
        /// <summary>
        /// ��ȡ���п�ݱ���Ļ�����Ϣ��
        /// </summary>
        /// <returns>��ݱ����ϡ�ֻ����������Ϣ��δ����Sql��Content��</returns>
        public List<Objects.QuickReportObject> QueryAllQuickReports()
        {
            List<Objects.QuickReportObject> list;
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryAllReports", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QueryAllReportsʧ�ܡ�";
                return null;
            }
            try
            {
                ExecQuery(sql);
                list = new List<Objects.QuickReportObject>();
                while (Reader.Read())
                {
                    Objects.QuickReportObject quickReport = new Objects.QuickReportObject();
                    quickReport.ID = Reader[0].ToString();
                    quickReport.Name = Reader[1].ToString();
                    quickReport.Type = Reader[2].ToString();
                    quickReport.Version = Convert.ToDecimal(Reader[3].ToString());
                    quickReport.IsValid = Reader[4].ToString();
                    list.Add(quickReport);
                }
            }
            catch (Exception e)
            {
                Err = "��ȡ���п�ݱ���ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return list;
        }

        /// <summary>
        /// ����ID��ȡ��ݱ���
        /// </summary>
        /// <param name="id">��ݱ����ID��</param>
        /// <returns>��ݱ���</returns>
        public Objects.QuickReportObject QueryReportByID(string id)
        {
            Objects.QuickReportObject quickReport;
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryReportByID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QueryReportByIDʧ�ܡ�";
                return null;
            }
            sql = string.Format(sql, id);
            try
            {
                ExecQuery(sql);
                quickReport = new Objects.QuickReportObject();
                while (Reader.Read())
                {
                    quickReport.ID = Reader[0].ToString();
                    quickReport.Name = Reader[1].ToString();
                    quickReport.Type = Reader[2].ToString();
                    quickReport.Version = Convert.ToDecimal(Reader[3].ToString());
                    quickReport.Content = Encoding.Default.GetString((byte[])Reader[4]);
                    quickReport.IsValid = Reader[5].ToString();
                }
            }
            catch (Exception e)
            {
                Err = "����ID��ȡ��ݱ���ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return quickReport;
        }

        /// <summary>
        /// ���ݲ���Ա�����뱨��ID��ȡ���á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportID">����ID��</param>
        /// <returns>���á�</returns>
        public string QuerySettingByOperCodeAndReportID(string operCode,string reportID)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySettingByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QuerySettingByOperCodeAndReportIDʧ�ܡ�";
                return null;
            }
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
        /// ���ݲ���Ա�����뱨��ID��ȡ�����е����á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportID">����ID��</param>
        /// <returns>���á�</returns>
        public string QuerySharedSettingByOperCodeAndReportID(string operCode, string reportID)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QuerySharedSettingByOperCodeAndReportIDʧ�ܡ�";
                return null;
            }
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
        /// ���ݱ���ID��ȡ�����е����á�
        /// </summary>
        /// <param name="reportID">����ID��</param>
        /// <returns>���á�</returns>
        public string QuerySharedSettingByReportID(string reportID)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingByReportID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QuerySharedSettingByReportIDʧ�ܡ�";
                return null;
            }
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
        /// ��ȡ��ݱ������š�
        /// </summary>
        /// <returns></returns>
        public string QueryQuickReportSeqID()
        {
            string seq = "";
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryQuickReportSeqID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QueryQuickReportSeqIDʧ�ܡ�";
                return null;
            }
            try
            {
                ExecQuery(sql);
                while (Reader.Read())
                {
                    seq = Reader[0].ToString();
                }
            }
            catch (Exception e)
            {
                Err = "��ȡ��ݱ�������ʧ�ܡ�" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return seq;
        }

        /// <summary>
        /// �����ݱ���
        /// </summary>
        /// <param name="quickReport">��ݱ���ʵ�塣</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int InsertQuickReport(Objects.QuickReportObject quickReport)
        {
            int i = InsertQuickReportBaseInfo(quickReport);
            if (i < 0)
                return i;
            byte[] content = Encoding.Default.GetBytes(quickReport.Content);
            return UpdateQuickReportContentByID(quickReport.ID, content);
        }

        /// <summary>
        /// �������á�
        /// </summary>
        /// <param name="operCode">����Ա���롣</param>
        /// <param name="reportID">����ID��</param>
        /// <param name="content">���ݡ�</param>
        /// <returns></returns>
        public int InsertSetting(string operCode,string reportID,string content)
        {
            int i = InsertSettingBaseInfo(operCode,reportID);
            if (i < 0)
                return i;
            return UpdateSettingByOperCodeAndReportID(operCode, reportID, content);
        }

        /// <summary>
        /// ���¿�ݱ���
        /// </summary>
        /// <param name="quickReport">��ݱ���ʵ�塣</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int UpdateQuickReportByID(Objects.QuickReportObject quickReport, string id)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateQuickReportByID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.UpdateQuickReportByIDʧ�ܡ�";
                return -1;
            }
            sql = string.Format(sql,quickReport.ID,quickReport.Name,quickReport.Type,quickReport.Version,quickReport.IsValid, id);
            try
            {
                byte[] content = Encoding.Default.GetBytes(quickReport.Content);
                return InputBlob(sql, content);
            }
            catch (Exception e)
            {
                Err = "�����ݱ���ʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
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
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateSettingByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.UpdateSettingByOperCodeAndReportIDʧ�ܡ�";
                return -1;
            }
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
            finally
            {
                Reader.Close();
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
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateSharedSettingFlagByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.UpdateSharedSettingFlagByOperCodeAndReportIDʧ�ܡ�";
                return -1;
            }
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
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ��ȡ���б������
        /// </summary>
        /// <returns>���б������</returns>
        public ArrayList QueryAllReportTypes()
        {
            ArrayList list;
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryAllReportTypes", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QueryAllReportTypesʧ�ܡ�";
                return null;
            }
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
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryTableExistQUICKREPORT_REPORTS", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QueryTableExistQUICKREPORT_REPORTSʧ�ܡ�";
                return -1;
            }
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
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryTableExistQUICKREPORT_SETTINGS", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QueryTableExistQUICKREPORT_SETTINGSʧ�ܡ�";
                return -1;
            }
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
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySettingExist", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QuerySettingExistʧ�ܡ�";
                return -1;
            }
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
        public string QuerySharedSettingExist(string operCode, string reportId)
        {
            string sql = "";
            string name = null;
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingExist", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QuerySharedSettingExistʧ�ܡ�";
                return null;
            }
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
        public string QuerySharedSettingExist( string reportId)
        {
            string sql = "";
            string name = null;
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingExistByReportID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QuerySharedSettingExistByReportIDʧ�ܡ�";
                return null;
            }
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
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.CreateTableQUICKREPORT_REPORTS", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.CreateTableQUICKREPORT_REPORTSʧ�ܡ�";
                return -1;
            }
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
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ������QUICKREPORT_SETTINGS��
        /// </summary>
        /// <returns>С�ڵ���0��ʧ�ܡ�</returns>
        public int CreateTableQUICKREPORT_SETTINGS()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.CreateTableQUICKREPORT_SETTINGS", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.CreateTableQUICKREPORT_SETTINGSʧ�ܡ�";
                return -1;
            }
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
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ��ѯ�Ƿ�������У�SEQ_QR_QUICKREPORTS_ID��
        /// </summary>
        /// <returns>С�ڵ���0���򲻴��ڡ�</returns>
        public int QuerySeqExistSEQ_QR_QUICKREPORTS_ID()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySeqExistSEQ_QR_QUICKREPORTS_ID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.QuerySeqExistSEQ_QR_QUICKREPORTS_IDʧ�ܡ�";
                return -1;
            }
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "��ѯ�Ƿ�������У�SEQ_QR_QUICKREPORTS_IDʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// �������У�SEQ_QR_QUICKREPORTS_ID��
        /// </summary>
        /// <returns>С�ڵ���0��ʧ�ܡ�</returns>
        public int CreateSeqSEQ_QR_QUICKREPORTS_ID()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.CreateSeqSEQ_QR_QUICKREPORTS_ID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.CreateSeqSEQ_QR_QUICKREPORTS_IDʧ�ܡ�";
                return -1;
            }
            try
            {
                sql = sql.Substring(0, sql.LastIndexOf(';'));
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "�������У�SEQ_QR_QUICKREPORTS_IDʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ����IDɾ����ݱ���
        /// </summary>
        /// <param name="quickReport">��ݱ���ID��</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        public int DeleteQuickReportByID(string id)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.DeleteQuickReportByID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.DeleteQuickReportByIDʧ�ܡ�";
                return -1;
            }
            sql = string.Format(sql, id);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "ɾ����ݱ���ʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// �����ݱ���Ļ�����Ϣ��
        /// </summary>
        /// <param name="quickReport">��ݱ���</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        private int InsertQuickReportBaseInfo(Objects.QuickReportObject quickReport)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.InsertQuickReportBaseInfo", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.InsertQuickReportBaseInfoʧ�ܡ�";
                return -1;
            }
            sql = string.Format(sql, quickReport.ID, quickReport.Name, quickReport.Type,quickReport.Version, quickReport.IsValid);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "�����ݱ���ʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
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
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.InsertSettingBaseInfo", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.InsertSettingBaseInfoʧ�ܡ�";
                return -1;
            }
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
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// ����ID���¿�ݱ����Content��
        /// </summary>
        /// <param name="id">��ݱ���ID��</param>
        /// <param name="content">��ݱ���Content��</param>
        /// <returns>-1ʧ�ܣ�1�ɹ���</returns>
        private int UpdateQuickReportContentByID(string id,byte[] content)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateQuickReportContentByID", ref sql) == -1)
            {
                Err = "���SQL��䣺QuickReportCore.UpdateQuickReportContentByIDʧ�ܡ�";
                return -1;
            }
            sql = string.Format(sql, id);
            try
            {
                return InputBlob(sql, content);
            }
            catch (Exception e)
            {
                Err = "�����ݱ���ʧ�ܡ�" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

    }
}
