using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Interface.Controls;
using QuickReportLib.Managers;

namespace QuickReportLib
{
    public partial class QuickReportShow : ucBaseControl
    {
        public QuickReportShow()
        {
            InitializeComponent();
            XmlManager.InitXmlManager();
        }
    }
}
