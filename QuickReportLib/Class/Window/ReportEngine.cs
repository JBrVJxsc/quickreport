using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.ReportLayoutStyles;
using QuickReportLib.ReportStyles;
using QuickReportLib.Interfaces.ReportUserControl;
using QuickReportLib.PublicInterfaces;

namespace QuickReportLib.Class.Window
{
    /// <summary>
    /// ±¨±íÒýÇæ¡£
    /// </summary>
    internal class ReportEngine
    {
        public ReportEngine(Report report)
        {
            this.report = report;
        }

        private Report report;
        private IDatasAsker[] iDatasAskersOfMainReport;
        private IDatasAsker[] iDatasAskersOfDetailReport;

        public Control ReportShowUserControl
        {
            get
            {
                return null;
            }
        }

        private void Init()
        {
            BaseReportLayoutStyle baseReportLayoutStyle = report.ReportLayoutStyle;
            BaseReportStyle baseReportStyle = report.ReportStyle;
        }

        public decimal Version
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Err
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void ShowSetting()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrePrint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Query()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void LoadReport(Report report)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
