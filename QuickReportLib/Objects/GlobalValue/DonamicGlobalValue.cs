using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 动态全局变量。
    /// </summary>
    internal class DonamicGlobalValue : BaseGlobalValue
    {
        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.Donamic;
            }
        }

        public override SQLCodeType SQLCodeType
        {
            get
            {
                return SQLCodeType.Dynamic;
            }
        }

        public override List<BaseObject> Value
        {
            get
            {
                List<BaseObject> baseObjectList = new List<BaseObject>();
                BaseObject rowNum = new BaseObject();
                rowNum.ID = Constants.Constants.DONAMIC_ROWNUM_GLOBALVALUE_ID_AND_NAME;
                rowNum.Name = Constants.Constants.DONAMIC_ROWNUM_GLOBALVALUE_ID_AND_NAME;
                rowNum.SortID = 0;
                BaseObject columnNum = new BaseObject();
                columnNum.ID = Constants.Constants.DONAMIC_COLUMNNUM_GLOBALVALUE_ID_AND_NAME;
                columnNum.Name = Constants.Constants.DONAMIC_COLUMNNUM_GLOBALVALUE_ID_AND_NAME;
                columnNum.SortID = 1;
                BaseObject timeUsed = new BaseObject();
                timeUsed.ID = Constants.Constants.DONAMIC_TIMEUSED_GLOBALVALUE_ID_AND_NAME;
                timeUsed.Name = Constants.Constants.DONAMIC_TIMEUSED_GLOBALVALUE_ID_AND_NAME;
                timeUsed.SortID = 2;
                baseObjectList.Add(rowNum);
                baseObjectList.Add(columnNum);
                baseObjectList.Add(timeUsed);
                return baseObjectList;
            }
            set
            {
                base.Value = value;
            }
        }
    }
}
