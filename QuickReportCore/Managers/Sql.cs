using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Managers
{
    internal class Sql
    {
        public static int GetSql(string sqlId, ref string sql)
        {
            if (sqls[sqlId] != null)
            {
                sql = sqls[sqlId].ToString();
                return 1;
            }
            return -1;
        }

        public static Hashtable sqls = new Hashtable();

        static Sql()
        {
            sqls.Add("QuickReportCore.QueryAllReports",
                @"select quickreport_reports.id,
       quickreport_reports.name,
       quickreport_reports.type,
       quickreport_reports.version,
       quickreport_reports.isvalid
  from quickreport_reports
 order by quickreport_reports.type");

            sqls.Add("QuickReportCore.QueryReportByID", @"select quickreport_reports.id,
       quickreport_reports.name,
       quickreport_reports.type,
       quickreport_reports.version,
       quickreport_reports.content,
       quickreport_reports.isvalid
  from quickreport_reports
 where quickreport_reports.id='{0}'");

            sqls.Add("QuickReportCore.QueryQuickReportSeqID", @"select SEQ_QR_QUICKREPORTS_ID.Nextval from dual");

            sqls.Add("QuickReportCore.InsertQuickReportBaseInfo", @"INSERT INTO quickreport_reports
  (quickreport_reports.id,
   quickreport_reports.name,
   quickreport_reports.type,
   quickreport_reports.version,
   quickreport_reports.isvalid)
VALUES
  ('{0}', '{1}', '{2}', '{3}', '{4}')");

            sqls.Add("QuickReportCore.QueryAllReportTypes", @"select distinct quickreport_reports.type
  from quickreport_reports
 order by quickreport_reports.type");

            sqls.Add("QuickReportCore.QueryTableExistQUICKREPORT_REPORTS", @"select table_name
  from user_all_tables
 where table_name = 'QUICKREPORT_REPORTS' ");

            sqls.Add("QuickReportCore.CreateTableQUICKREPORT_REPORTS", @"-- Create table
create table QUICKREPORT_REPORTS
(
  ID      VARCHAR2(12) not null,
  NAME    VARCHAR2(200) not null,
  TYPE    VARCHAR2(100) not null,
  VERSION NUMBER(8,2) not null,
  CONTENT BLOB,
  ISVALID VARCHAR2(1) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16
    minextents 1
    maxextents unlimited
  );
-- Add comments to the columns 
comment on column QUICKREPORT_REPORTS.ID
  is '编码';
comment on column QUICKREPORT_REPORTS.NAME
  is '名称';
comment on column QUICKREPORT_REPORTS.TYPE
  is '类别';
comment on column QUICKREPORT_REPORTS.VERSION
  is '版本号';
comment on column QUICKREPORT_REPORTS.CONTENT
  is '内容';
comment on column QUICKREPORT_REPORTS.ISVALID
  is '是否有效';
-- Create/Recreate primary, unique and foreign key constraints 
alter table QUICKREPORT_REPORTS
  add constraint PK_QUICKREPORT_REPORTS primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
");

            sqls.Add("QuickReportCore.QuerySeqExistSEQ_QR_QUICKREPORTS_ID", @"select sequence_name
  from user_sequences
 where sequence_name = 'SEQ_QR_QUICKREPORTS_ID'");

            sqls.Add("QuickReportCore.CreateSeqSEQ_QR_QUICKREPORTS_ID", @"-- Create sequence 
create sequence SEQ_QR_QUICKREPORTS_ID
minvalue 1
maxvalue 999999999999999999999999999
start with 1
increment by 1
nocache;");

            sqls.Add("QuickReportCore.DeleteQuickReportByID", @"delete from quickreport_reports where quickreport_reports.id = '{0}'");

            sqls.Add("QuickReportCore.UpdateQuickReportContentByID", @"update quickreport_reports
   set quickreport_reports.content = :c
 where quickreport_reports.id = '{0}'");

            sqls.Add("QuickReportCore.UpdateQuickReportByID", @"update quickreport_reports
   set quickreport_reports.id      = '{0}',
       quickreport_reports.name    = '{1}',
       quickreport_reports.type    = '{2}',
       quickreport_reports.version ='{3}',
       quickreport_reports.content = :c,
       quickreport_reports.isvalid = '{4}'
 where quickreport_reports.id = '{5}'");

            sqls.Add("QuickReportCore.QueryTableExistQUICKREPORT_SETTINGS", @"select table_name
  from user_all_tables
 where table_name = 'QUICKREPORT_SETTINGS' ");

            sqls.Add("QuickReportCore.CreateTableQUICKREPORT_SETTINGS", @"-- Create table
create table QUICKREPORT_SETTINGS
(
  OPER_CODE VARCHAR2(12) not null,
  REPORT_ID VARCHAR2(12) not null,
  CONTENT   BLOB,
  SHARED    NVARCHAR2(1) default 0 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Add comments to the columns 
comment on column QUICKREPORT_SETTINGS.OPER_CODE
  is '员工编码';
comment on column QUICKREPORT_SETTINGS.REPORT_ID
  is '报表ID';
comment on column QUICKREPORT_SETTINGS.CONTENT
  is '内容';
comment on column QUICKREPORT_SETTINGS.SHARED
  is '是否共享';
-- Create/Recreate primary, unique and foreign key constraints 
alter table QUICKREPORT_SETTINGS
  add constraint PK_QUICKREPORT_SETTINGS primary key (OPER_CODE, REPORT_ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
");

            sqls.Add("QuickReportCore.QuerySettingExist", @"select *
  from quickreport_settings
 where quickreport_settings.oper_code = '{0}'
   and quickreport_settings.report_id = '{1}' ");

            sqls.Add("QuickReportCore.QuerySharedSettingExist", @"select com_employee.empl_name
  from quickreport_settings,com_employee
 where 
       quickreport_settings.oper_code=com_employee.empl_code(+)
   and quickreport_settings.oper_code = '{0}'
   and quickreport_settings.report_id = '{1}' 
   and quickreport_settings.shared='1'");

            sqls.Add("QuickReportCore.QuerySharedSettingExistByReportID", @"select com_employee.empl_name
  from quickreport_settings,com_employee
 where 
       quickreport_settings.oper_code=com_employee.empl_code(+)
   and quickreport_settings.report_id = '{0}' 
   and quickreport_settings.shared='1'");

            sqls.Add("QuickReportCore.UpdateSettingByOperCodeAndReportID", @"update quickreport_settings
   set quickreport_settings.content = :c
 where quickreport_settings.oper_code = '{0}'
   and quickreport_settings.report_id = '{1}'");

            sqls.Add("QuickReportCore.UpdateSharedSettingFlagByOperCodeAndReportID", @"update quickreport_settings
   set quickreport_settings.shared = '{2}'
 where quickreport_settings.oper_code = '{0}'
   and quickreport_settings.report_id = '{1}'");

            sqls.Add("QuickReportCore.InsertSettingBaseInfo", @"INSERT INTO quickreport_settings
  (quickreport_settings.oper_code, quickreport_settings.report_id)
VALUES
  ('{0}', '{1}')");

            sqls.Add("QuickReportCore.QuerySettingByOperCodeAndReportID", @"select quickreport_settings.content
  from quickreport_settings
 where quickreport_settings.oper_code = '{0}'
   and quickreport_settings.report_id = '{1}'");

            sqls.Add("QuickReportCore.QuerySharedSettingByOperCodeAndReportID", @"select quickreport_settings.content
  from quickreport_settings
 where quickreport_settings.oper_code = '{0}'
   and quickreport_settings.report_id = '{1}'
   and quickreport_settings.shared='1'");

            sqls.Add("QuickReportCore.QuerySharedSettingByReportID", @"select quickreport_settings.content
  from quickreport_settings
 where quickreport_settings.report_id = '{0}'
   and quickreport_settings.shared='1'");
        }
    }
}
