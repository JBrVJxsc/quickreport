using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace QuickReportCore.Managers
{
    /// <summary>
    /// 快捷报表的业务类。
    /// </summary>
    internal class QuickReportManager : Neusoft.NFC.Management.Database
    {
        /// <summary>
        /// 获取所有快捷报表的基本信息。
        /// </summary>
        /// <returns>快捷报表集合。只包含基本信息，未包含Sql与Content。</returns>
        public List<Objects.QuickReportObject> QueryAllQuickReports()
        {
            List<Objects.QuickReportObject> list;
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryAllReports", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QueryAllReports失败。";
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
                Err = "获取所有快捷报表失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取快捷报表。
        /// </summary>
        /// <param name="id">快捷报表的ID。</param>
        /// <returns>快捷报表。</returns>
        public Objects.QuickReportObject QueryReportByID(string id)
        {
            Objects.QuickReportObject quickReport;
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryReportByID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QueryReportByID失败。";
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
                Err = "根据ID获取快捷报表失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return quickReport;
        }

        /// <summary>
        /// 根据操作员编码与报表ID获取设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportID">报表ID。</param>
        /// <returns>设置。</returns>
        public string QuerySettingByOperCodeAndReportID(string operCode,string reportID)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySettingByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QuerySettingByOperCodeAndReportID失败。";
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
                Err = "获取设置失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return null;
        }     

        /// <summary>
        /// 根据操作员编码与报表ID获取共享中的设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportID">报表ID。</param>
        /// <returns>设置。</returns>
        public string QuerySharedSettingByOperCodeAndReportID(string operCode, string reportID)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QuerySharedSettingByOperCodeAndReportID失败。";
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
                Err = "获取共享设置失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return null;
        }

        /// <summary>
        /// 根据报表ID获取共享中的设置。
        /// </summary>
        /// <param name="reportID">报表ID。</param>
        /// <returns>设置。</returns>
        public string QuerySharedSettingByReportID(string reportID)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingByReportID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QuerySharedSettingByReportID失败。";
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
                Err = "获取共享设置失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return null;
        }

        /// <summary>
        /// 获取快捷报表的序号。
        /// </summary>
        /// <returns></returns>
        public string QueryQuickReportSeqID()
        {
            string seq = "";
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryQuickReportSeqID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QueryQuickReportSeqID失败。";
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
                Err = "获取快捷报表的序号失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return seq;
        }

        /// <summary>
        /// 插入快捷报表。
        /// </summary>
        /// <param name="quickReport">快捷报表实体。</param>
        /// <returns>-1失败；1成功。</returns>
        public int InsertQuickReport(Objects.QuickReportObject quickReport)
        {
            int i = InsertQuickReportBaseInfo(quickReport);
            if (i < 0)
                return i;
            byte[] content = Encoding.Default.GetBytes(quickReport.Content);
            return UpdateQuickReportContentByID(quickReport.ID, content);
        }

        /// <summary>
        /// 插入设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportID">报表ID。</param>
        /// <param name="content">内容。</param>
        /// <returns></returns>
        public int InsertSetting(string operCode,string reportID,string content)
        {
            int i = InsertSettingBaseInfo(operCode,reportID);
            if (i < 0)
                return i;
            return UpdateSettingByOperCodeAndReportID(operCode, reportID, content);
        }

        /// <summary>
        /// 更新快捷报表。
        /// </summary>
        /// <param name="quickReport">快捷报表实体。</param>
        /// <returns>-1失败；1成功。</returns>
        public int UpdateQuickReportByID(Objects.QuickReportObject quickReport, string id)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateQuickReportByID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.UpdateQuickReportByID失败。";
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
                Err = "插入快捷报表失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 更新设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportID">报表ID。</param>
        /// <param name="content">内容。</param>
        /// <returns>-1失败；1成功。</returns>
        public int UpdateSettingByOperCodeAndReportID(string operCode,string reportID,string content)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateSettingByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.UpdateSettingByOperCodeAndReportID失败。";
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
                Err = "插入设置失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 更新共享设置的标志位。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportID">报表ID。</param>
        /// <param name="flag">标志位。</param>
        /// <returns>-1失败；1成功。</returns>
        public int UpdateSharedSettingFlagByOperCodeAndReportID(string operCode, string reportID, string flag)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateSharedSettingFlagByOperCodeAndReportID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.UpdateSharedSettingFlagByOperCodeAndReportID失败。";
                return -1;
            }
            sql = string.Format(sql, operCode,reportID,flag);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "更新共享设置标志位失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 获取所有报表类别。
        /// </summary>
        /// <returns>所有报表类别。</returns>
        public ArrayList QueryAllReportTypes()
        {
            ArrayList list;
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryAllReportTypes", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QueryAllReportTypes失败。";
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
                Err = "获取所有报表类别失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return list;
        }

        /// <summary>
        /// 查询是否存在表：QUICKREPORT_REPORTS。
        /// </summary>
        /// <returns>小于等于0，则不存在。</returns>
        public int QueryTableExistQUICKREPORT_REPORTS()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryTableExistQUICKREPORT_REPORTS", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QueryTableExistQUICKREPORT_REPORTS失败。";
                return -1;
            }
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "查询是否存在表：QUICKREPORT_REPORTS失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 查询是否存在表：QUICKREPORT_SETTINGS。
        /// </summary>
        /// <returns>小于等于0，则不存在。</returns>
        public int QueryTableExistQUICKREPORT_SETTINGS()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QueryTableExistQUICKREPORT_SETTINGS", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QueryTableExistQUICKREPORT_SETTINGS失败。";
                return -1;
            }
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "查询是否存在表：QUICKREPORT_SETTINGS失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 根据操作员编码和报表ID查询是否存在设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportId">报表ID。</param>
        /// <returns>小于等于0，则不存在。</returns>
        public int QuerySettingExist(string operCode,string reportId)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySettingExist", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QuerySettingExist失败。";
                return -1;
            }
            sql = string.Format(sql, operCode, reportId);
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "查询是否存在设置失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 根据操作员编码和报表ID查询是否存在共享的设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportId">报表ID。</param>
        /// <returns>存在则返回操作员姓名，null则不存在。</returns>
        public string QuerySharedSettingExist(string operCode, string reportId)
        {
            string sql = "";
            string name = null;
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingExist", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QuerySharedSettingExist失败。";
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
                Err = "查询是否存在设置失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return name;
        }

        /// <summary>
        /// 根据报表ID查询是否存在共享的设置。
        /// </summary>
        /// <param name="reportId">报表ID。</param>
        /// <returns>存在则返回操作员姓名，null则不存在。</returns>
        public string QuerySharedSettingExist( string reportId)
        {
            string sql = "";
            string name = null;
            if (Managers.Sql.GetSql("QuickReportCore.QuerySharedSettingExistByReportID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QuerySharedSettingExistByReportID失败。";
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
                Err = "查询是否存在设置失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return name;
        }

        /// <summary>
        /// 创建表：QUICKREPORT_REPORTS。
        /// </summary>
        /// <returns>小于等于0则失败。</returns>
        public int CreateTableQUICKREPORT_REPORTS()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.CreateTableQUICKREPORT_REPORTS", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.CreateTableQUICKREPORT_REPORTS失败。";
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
                Err = "创建表：QUICKREPORT_REPORTS失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 创建表：QUICKREPORT_SETTINGS。
        /// </summary>
        /// <returns>小于等于0则失败。</returns>
        public int CreateTableQUICKREPORT_SETTINGS()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.CreateTableQUICKREPORT_SETTINGS", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.CreateTableQUICKREPORT_SETTINGS失败。";
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
                Err = "创建表：QUICKREPORT_SETTINGS失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 查询是否存在序列：SEQ_QR_QUICKREPORTS_ID。
        /// </summary>
        /// <returns>小于等于0，则不存在。</returns>
        public int QuerySeqExistSEQ_QR_QUICKREPORTS_ID()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.QuerySeqExistSEQ_QR_QUICKREPORTS_ID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.QuerySeqExistSEQ_QR_QUICKREPORTS_ID失败。";
                return -1;
            }
            try
            {
                return ExecQuery(sql);
            }
            catch (Exception e)
            {
                Err = "查询是否存在序列：SEQ_QR_QUICKREPORTS_ID失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 创建序列：SEQ_QR_QUICKREPORTS_ID。
        /// </summary>
        /// <returns>小于等于0则失败。</returns>
        public int CreateSeqSEQ_QR_QUICKREPORTS_ID()
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.CreateSeqSEQ_QR_QUICKREPORTS_ID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.CreateSeqSEQ_QR_QUICKREPORTS_ID失败。";
                return -1;
            }
            try
            {
                sql = sql.Substring(0, sql.LastIndexOf(';'));
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "创建序列：SEQ_QR_QUICKREPORTS_ID失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 按照ID删除快捷报表。
        /// </summary>
        /// <param name="quickReport">快捷报表ID。</param>
        /// <returns>-1失败；1成功。</returns>
        public int DeleteQuickReportByID(string id)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.DeleteQuickReportByID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.DeleteQuickReportByID失败。";
                return -1;
            }
            sql = string.Format(sql, id);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "删除快捷报表失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 插入快捷报表的基础信息。
        /// </summary>
        /// <param name="quickReport">快捷报表。</param>
        /// <returns>-1失败；1成功。</returns>
        private int InsertQuickReportBaseInfo(Objects.QuickReportObject quickReport)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.InsertQuickReportBaseInfo", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.InsertQuickReportBaseInfo失败。";
                return -1;
            }
            sql = string.Format(sql, quickReport.ID, quickReport.Name, quickReport.Type,quickReport.Version, quickReport.IsValid);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "插入快捷报表失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 插入设置的基础信息。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportId">报表ID。</param>
        /// <returns>-1失败；1成功。</returns>
        private int InsertSettingBaseInfo(string operCode, string reportId)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.InsertSettingBaseInfo", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.InsertSettingBaseInfo失败。";
                return -1;
            }
            sql = string.Format(sql, operCode, reportId);
            try
            {
                return ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                Err = "插入设置失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

        /// <summary>
        /// 根据ID更新快捷报表的Content。
        /// </summary>
        /// <param name="id">快捷报表ID。</param>
        /// <param name="content">快捷报表Content。</param>
        /// <returns>-1失败；1成功。</returns>
        private int UpdateQuickReportContentByID(string id,byte[] content)
        {
            string sql = "";
            if (Managers.Sql.GetSql("QuickReportCore.UpdateQuickReportContentByID", ref sql) == -1)
            {
                Err = "获得SQL语句：QuickReportCore.UpdateQuickReportContentByID失败。";
                return -1;
            }
            sql = string.Format(sql, id);
            try
            {
                return InputBlob(sql, content);
            }
            catch (Exception e)
            {
                Err = "插入快捷报表失败。" + e.Message;
                return -1;
            }
            finally
            {
                Reader.Close();
            }
        }

    }
}
