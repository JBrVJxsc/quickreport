using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// 表头设置界面的Fp发生改变的类别。
    /// </summary>
    internal enum HeaderSettingFpSpreadChangedType
    {
        /// <summary>
        /// 表首行数发生改变。
        /// </summary>
        TopRowCountChanged,
        /// <summary>
        /// 表尾行数发生改变。
        /// </summary>
        BottomRowCountChanged,
        /// <summary>
        /// 列数发生改变。
        /// </summary>
        ColumnCountChanged,
        /// <summary>
        /// 列宽发生改变。
        /// </summary>
        ColumnWidthChanged,
        /// <summary>
        /// 行高发生改变。
        /// </summary>
        RowHeightChanged,
        /// <summary>
        /// 合并。
        /// </summary>
        SpanChanged,
        /// <summary>
        /// 画斜线。
        /// </summary>
        BevelLineChanged,
        /// <summary>
        /// 对齐方式。
        /// </summary>
        AlignmentChanged,
        /// <summary>
        /// 边框。
        /// </summary>
        BorderChanged,
        /// <summary>
        /// 字体。
        /// </summary>
        FontChanged,
        /// <summary>
        /// 颜色。
        /// </summary>
        ColorChanged,
        /// <summary>
        /// 擦除Border。
        /// </summary>
        EraseChanged,
        /// <summary>
        /// 列合计。
        /// </summary>
        ReportColumnColumnTotalSumChanged,
        /// <summary>
        /// 行合计。
        /// </summary>
        ReportColumnRowTotalSumChanged,
        /// <summary>
        /// 过滤。
        /// </summary>
        ReportColumnFilterChanged,
        /// <summary>
        /// 排序。
        /// </summary>
        ReportColumnSortChanged,
        /// <summary>
        /// 小数位数。
        /// </summary>
        ReportColumnDecimalPlaceChanged,
        /// <summary>
        /// 值转换方式。
        /// </summary>
        ReportColumnValueTranslateTypeChanged,
        /// <summary>
        /// 合并同类。
        /// </summary>
        ReportColumnMergeChanged,
        /// <summary>
        /// 报表列颜色。
        /// </summary>
        ReportColumnColorChanged,
        /// <summary>
        /// 报表列字体。
        /// </summary>
        ReportColumnFontChanged,
        /// <summary>
        /// 报表列对齐方式。
        /// </summary>
        ReportColumnAlignmentChanged
    }
}
