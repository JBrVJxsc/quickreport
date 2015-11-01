using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ConditionInputTypeSetting;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// 提供与集合相关静态方法的静态类。
    /// </summary>
    internal static class ListManager
    {
        /// <summary>
        /// 将List集合转化为SortedList集合。
        /// </summary>
        /// <param name="baseObjectList">基础实体集合。</param>
        /// <returns>SortedList集合。</returns>
        internal static SortedList ListToSortedList(List<BaseObject> baseObjectList)
        {
            SortedList sortedList = new SortedList();
            foreach (BaseObject baseObject in baseObjectList)
            {
                sortedList.Add(baseObject, null);
            }
            return sortedList;
        }

        /// <summary>
        /// 将List集合转化为SortedList集合。
        /// </summary>
        /// <param name="baseObjectList">基础实体集合。</param>
        /// <returns>SortedList集合。</returns>
        internal static SortedList ListToSortedList(List<Column> columnList)
        {
            SortedList sortedList = new SortedList();
            foreach (Column column in columnList)
            {
                sortedList.Add(column, null);
            }
            return sortedList;
        }

        /// <summary>
        /// 将List集合转化为SortedList集合。
        /// </summary>
        /// <param name="baseObjectList">基础实体集合。</param>
        /// <returns>SortedList集合。</returns>
        internal static SortedList ListToSortedList(List<Condition> conditionList)
        {
            SortedList sortedList = new SortedList();
            foreach (Condition condition in conditionList)
            {
                sortedList.Add(condition, null);
            }
            return sortedList;
        }

        /// <summary>
        /// 报表列List转换为BaseObjectList。
        /// </summary>
        /// <param name="columnList">报表列List。</param>
        /// <returns>BaseObjectList。</returns>
        internal static List<BaseObject> ColumnListToBaseObjectList(List<Column> columnList)
        {
            List<BaseObject> baseObjectList = new List<BaseObject>();
            for (int i = 0; i < columnList.Count; i++)
            {
                baseObjectList.Add(columnList[i]);
            }
            return baseObjectList;
        }

        /// <summary>
        /// 条件List转换为BaseObjectList。
        /// </summary>
        /// <param name="columnList">条件List。</param>
        /// <returns>BaseObjectList。</returns>
        internal static List<BaseObject> ConditionListToBaseObjectList(List<Condition> conditionList)
        {
            List<BaseObject> baseObjectList = new List<BaseObject>();
            for (int i = 0; i < conditionList.Count; i++)
            {
                baseObjectList.Add(conditionList[i]);
            }
            return baseObjectList;
        }

        /// <summary>
        /// CheckControlElementList转换为BaseObjectList。
        /// </summary>
        /// <param name="columnList">CheckControlElementList。</param>
        /// <returns>BaseObjectList。</returns>
        internal static List<BaseObject> CheckControlElementListToBaseObjectList(List<CheckControlElement> checkControlElementList)
        {
            List<BaseObject> baseObjectList = new List<BaseObject>();
            for (int i = 0; i < checkControlElementList.Count; i++)
            {
                baseObjectList.Add(checkControlElementList[i]);
            }
            return baseObjectList;
        }
    }
}
