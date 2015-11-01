using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickReportLib.Constants
{
    /// <summary>
    /// 提供全局常量支持的静态类。
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// 取消窗口激活的消息。
        /// </summary>
        internal const int WM_NCACTIVATE = 0x086;

        /// <summary>
        /// 用作对比的字符串。
        /// </summary>
        internal const string COMPARE_STRING = "~!@#$%^&*()_+=-{}|\\][:\"';<>?/.,";

        /// <summary>
        /// 激活时展示的颜色。
        /// </summary>
        internal static Color ACTIVE_COLOR = Color.LightBlue;

        /// <summary>
        /// 树节点的编码作为全局变量时的ID与Name。
        /// </summary>
        internal const string TREE_CODE_GLOBALVALUE_ID_AND_NAME = "节点编码";

        /// <summary>
        /// 树节点的名称作为全局变量时的ID与Name。
        /// </summary>
        internal const string TREE_NAME_GLOBALVALUE_ID_AND_NAME = "节点名称";

        /// <summary>
        /// 报表行数作为全局变量时的ID与Name。
        /// </summary>
        internal const string DONAMIC_ROWNUM_GLOBALVALUE_ID_AND_NAME = "行数";

        /// <summary>
        /// 报表列数作为全局变量时的ID与Name。
        /// </summary>
        internal const string DONAMIC_COLUMNNUM_GLOBALVALUE_ID_AND_NAME = "列数";

        /// <summary>
        /// 报表查询耗时作为全局变量时的ID与Name。
        /// </summary>
        internal const string DONAMIC_TIMEUSED_GLOBALVALUE_ID_AND_NAME = "耗时";

        /// <summary>
        /// 表头设置中默认列宽。
        /// </summary>
        internal const float HEADER_SETTING_COLUMN_WIDTH = 60;

        /// <summary>
        /// 表头设置中默认行高。
        /// </summary>
        internal const float HEADER_SETTING_ROW_HEIGHT = 20;
    }
}
