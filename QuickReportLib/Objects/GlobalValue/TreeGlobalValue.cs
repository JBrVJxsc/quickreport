using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 树全局变量。
    /// </summary>
    internal class TreeGlobalValue : BaseGlobalValue
    {
        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.Tree;
            }
        }

        public override SQLCodeType SQLCodeType
        {
            get
            {
                return SQLCodeType.Tree;
            }
        }

        public override List<BaseObject> Value
        {
            get
            {
                List<BaseObject> baseObjectList = new List<BaseObject>();
                BaseObject treeCode = new BaseObject();
                treeCode.ID = Constants.Constants.TREE_CODE_GLOBALVALUE_ID_AND_NAME;
                treeCode.Name = Constants.Constants.TREE_CODE_GLOBALVALUE_ID_AND_NAME;
                treeCode.SortID = 0;
                BaseObject treeName = new BaseObject();
                treeName.ID = Constants.Constants.TREE_NAME_GLOBALVALUE_ID_AND_NAME;
                treeName.Name = Constants.Constants.TREE_NAME_GLOBALVALUE_ID_AND_NAME;
                treeName.SortID = 1;
                baseObjectList.Add(treeCode);
                baseObjectList.Add(treeName);
                return baseObjectList;
            }
            set
            {
                base.Value = value;
            }
        }
    }
}
