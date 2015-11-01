using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ConditionInputTypeSetting;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// �ṩ�뼯����ؾ�̬�����ľ�̬�ࡣ
    /// </summary>
    internal static class ListManager
    {
        /// <summary>
        /// ��List����ת��ΪSortedList���ϡ�
        /// </summary>
        /// <param name="baseObjectList">����ʵ�弯�ϡ�</param>
        /// <returns>SortedList���ϡ�</returns>
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
        /// ��List����ת��ΪSortedList���ϡ�
        /// </summary>
        /// <param name="baseObjectList">����ʵ�弯�ϡ�</param>
        /// <returns>SortedList���ϡ�</returns>
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
        /// ��List����ת��ΪSortedList���ϡ�
        /// </summary>
        /// <param name="baseObjectList">����ʵ�弯�ϡ�</param>
        /// <returns>SortedList���ϡ�</returns>
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
        /// ������Listת��ΪBaseObjectList��
        /// </summary>
        /// <param name="columnList">������List��</param>
        /// <returns>BaseObjectList��</returns>
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
        /// ����Listת��ΪBaseObjectList��
        /// </summary>
        /// <param name="columnList">����List��</param>
        /// <returns>BaseObjectList��</returns>
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
        /// CheckControlElementListת��ΪBaseObjectList��
        /// </summary>
        /// <param name="columnList">CheckControlElementList��</param>
        /// <returns>BaseObjectList��</returns>
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
