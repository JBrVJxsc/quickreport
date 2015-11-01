using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.PublicInterfaces;

namespace QuickReport
{
    public class TestIDatasAsker : IDatasAsker
    {

        #region IDatasAsker ≥…‘±

        public void GetDatas(string[] datas)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public event DoneHandle Done;

        #endregion
    }
}
