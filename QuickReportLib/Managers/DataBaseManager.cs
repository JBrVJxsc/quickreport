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
    /// 数据库操作类。
    /// </summary>
    internal class DataBaseManager : Database
    {
        internal static DataBaseManager GlobalDataBaseManager = new DataBaseManager();

        /// <summary>
        /// 获取所有报表的基本信息。
        /// </summary>
        /// <returns>报表集合。只包含基本信息，未包含Sql与Content。</returns>
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
                Err = "获取所有报表失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取报表。
        /// </summary>
        /// <param name="id">报表的ID。</param>
        /// <returns>报表。</returns>
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
                Err = "根据ID获取报表失败。" + e.Message;
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return report;
        }

        /// <summary>
        /// 根据操作员编码与报表ID获取设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportID">报表ID。</param>
        /// <returns>设置。</returns>
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
        /// 根据报表ID获取共享中的设置。
        /// </summary>
        /// <param name="reportID">报表ID。</param>
        /// <returns>设置。</returns>
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
        /// 插入报表。
        /// </summary>
        /// <param name="quickReport">报表实体。</param>
        /// <returns>-1失败；1成功。</returns>
        public int InsertQuickReport(Report report)
        {
            int i = InsertQuickReportBaseInfo(report);
            if (i < 0)
                return i;
            byte[] content = Encoding.Default.GetBytes(EncryptionManager.Encrypt(XmlManager.SerializeReport(report)));
            return UpdateQuickReportContentByID(report.ID, content);
        }

        /// <summary>
        /// 插入设置。
        /// </summary>
        /// <param name="operCode">操作员编码。</param>
        /// <param name="reportID">报表ID。</param>
        /// <param name="content">内容。</param>
        /// <returns>-1失败；1成功。</returns>
        public int InsertSetting(string operCode,string reportID,string content)
        {
            int i = InsertSettingBaseInfo(operCode,reportID);
            if (i < 0)
                return i;
            return UpdateSettingByOperCodeAndReportID(operCode, reportID, content);
        }

        /// <summary>
        /// 更新报表。
        /// </summary>
        /// <param name="quickReport">报表实体。</param>
        /// <returns>-1失败；1成功。</returns>
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
                Err = "插入报表失败。" + e.Message;
                return -1;
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
            string sql = global::QuickReportLib.Properties.Resources.SQL_UpdateSettingByOperCodeAndReportID;
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
            string sql = global::QuickReportLib.Properties.Resources.SQL_UpdateSharedSettingFlagByOperCodeAndReportID;
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
        }

        /// <summary>
        /// 获取所有报表类别。
        /// </summary>
        /// <returns>所有报表类别。</returns>
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
            string sql = global::QuickReportLib.Properties.Resources.SQL_QueryTableExistQUICKREPORT_REPORTS;
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
            string sql = global::QuickReportLib.Properties.Resources.SQL_QueryTableExistQUICKREPORT_SETTINGS;
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
            string sql = global::QuickReportLib.Properties.Resources.SQL_QuerySettingExist;
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
                Err = "创建表：QUICKREPORT_REPORTS失败。" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 创建表：QUICKREPORT_SETTINGS。
        /// </summary>
        /// <returns>小于等于0则失败。</returns>
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
                Err = "创建表：QUICKREPORT_SETTINGS失败。" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 按照ID删除报表。
        /// </summary>
        /// <param name="quickReport">报表ID。</param>
        /// <returns>-1失败；1成功。</returns>
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
                Err = "删除报表失败。" + e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 插入报表的基础信息。
        /// </summary>
        /// <param name="quickReport">报表。</param>
        /// <returns>-1失败；1成功。</returns>
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
                Err = "插入报表失败。" + e.Message;
                return -1;
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
            string sql = global::QuickReportLib.Properties.Resources.SQL_InsertSettingBaseInfo;
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
        }

        /// <summary>
        /// 根据ID更新报表的Content。
        /// </summary>
        /// <param name="id">报表ID。</param>
        /// <param name="content">报表Content。</param>
        /// <returns>-1失败；1成功。</returns>
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
                Err = "插入报表失败。" + e.Message;
                return -1;
            }
        }
    }
}
