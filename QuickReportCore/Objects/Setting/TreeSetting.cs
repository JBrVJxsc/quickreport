using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class TreeSetting
    {
        private string sql = string.Empty;
        /// <summary>
        /// SQL语句。
        /// </summary>
        public string SQL
        {
            get
            {
                return sql;
            }
            set 
            {
                sql = value;
            }
        }

        private string code = string.Empty;
        /// <summary>
        /// 编码。
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        private string name = string.Empty;
        /// <summary>
        /// 名称。
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string groupCode = string.Empty;
        /// <summary>
        /// 分组编码。
        /// </summary>
        public string GroupCode
        {
            get
            {
                return groupCode;
            }
            set
            {
                groupCode = value;
            }
        }

        private string groupName = string.Empty;
        /// <summary>
        /// 分组名称。
        /// </summary>
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        private string treeRootCode = string.Empty;
        /// <summary>
        /// 树的根编码。
        /// </summary>
        public string TreeRootCode
        {
            get
            {
                return treeRootCode;
            }
            set
            {
                treeRootCode = value;
            }
        }

        private string treeRootName = string.Empty;
        /// <summary>
        /// 树的根名称。
        /// </summary>
        public string TreeRootName
        {
            get
            {
                return treeRootName;
            }
            set
            {
                treeRootName = value;
            }
        }

        private bool treeMultiSelect = true;
        /// <summary>
        /// 是否多选。
        /// </summary>
        public bool TreeMultiSelect
        {
            get
            {
                return treeMultiSelect;
            }
            set
            {
                treeMultiSelect = value;
            }
        }      private bool treeExpanded = true;
        /// <summary>
        /// 是否默认展开。
        /// </summary>
        public bool TreeExpanded
        {
            get
            {
                return treeExpanded;
            }
            set
            {
                treeExpanded = value;
            }
        }


        private System.Drawing.Font groupFont;
        /// <summary>
        /// 分组字体。
        /// </summary>
        public System.Drawing.Font GroupFont
        {
            get
            {
                return groupFont;
            }
            set
            {
                groupFont = value;
            }
        }

        private System.Drawing.Font rootFont;
        /// <summary>
        /// 根字体。
        /// </summary>
        public System.Drawing.Font RootFont
        {
            get
            {
                return rootFont;
            }
            set
            {
                rootFont = value;
            }
        }

        private System.Drawing.Font nameFont;
        /// <summary>
        /// 节点字体。
        /// </summary>
        public System.Drawing.Font NameFont
        {
            get
            {
                return nameFont;
            }
            set
            {
                nameFont = value;
            }
        }

        private System.Drawing.Color groupColor;
        /// <summary>
        /// 分组颜色。
        /// </summary>
        public System.Drawing.Color GroupColor
        {
            get
            {
                return groupColor;
            }
            set
            {
                groupColor = value;
            }
        }

        private System.Drawing.Color rootColor;
        /// <summary>
        /// 根颜色。
        /// </summary>
        public System.Drawing.Color RootColor
        {
            get
            {
                return rootColor;
            }
            set
            {
                rootColor = value;
            }
        }

        private System.Drawing.Color nameColor;
        /// <summary>
        /// 节点颜色。
        /// </summary>
        public System.Drawing.Color NameColor
        {
            get
            {
                return nameColor;
            }
            set
            {
                nameColor = value;
            }
        }

        private int groupIcon=0;
        /// <summary>
        /// 分组图标。
        /// </summary>
        public int GroupIcon
        {
            get
            {
                return groupIcon;
            }
            set
            {
                groupIcon = value;
            }
        }

        private int rootIcon=0;
        /// <summary>
        /// 根图标。
        /// </summary>
        public int RootIcon
        {
            get
            {
                return rootIcon;
            }
            set
            {
                rootIcon = value;
            }
        }

        private int nameIcon = 0;
        /// <summary>
        /// 节点图标。
        /// </summary>
        public int NameIcon
        {
            get
            {
                return nameIcon;
            }
            set
            {
                nameIcon = value;
            }
        }

        private QuickReportCore.Forms.frmQuickReportEditor.QueryActionType actionType = QuickReportCore.Forms.frmQuickReportEditor.QueryActionType.单击激活查询;
        /// <summary>
        /// 动作类型。
        /// </summary>
        internal QuickReportCore.Forms.frmQuickReportEditor.QueryActionType ActionType
        {
            get
            {
                return actionType;
            }
            set
            {
                actionType = value;
            }
        }
    }
}
