using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickReportLib.Constants
{
    /// <summary>
    /// �ṩȫ�ֳ���֧�ֵľ�̬�ࡣ
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// ȡ�����ڼ������Ϣ��
        /// </summary>
        internal const int WM_NCACTIVATE = 0x086;

        /// <summary>
        /// �����Աȵ��ַ�����
        /// </summary>
        internal const string COMPARE_STRING = "~!@#$%^&*()_+=-{}|\\][:\"';<>?/.,";

        /// <summary>
        /// ����ʱչʾ����ɫ��
        /// </summary>
        internal static Color ACTIVE_COLOR = Color.LightBlue;

        /// <summary>
        /// ���ڵ�ı�����Ϊȫ�ֱ���ʱ��ID��Name��
        /// </summary>
        internal const string TREE_CODE_GLOBALVALUE_ID_AND_NAME = "�ڵ����";

        /// <summary>
        /// ���ڵ��������Ϊȫ�ֱ���ʱ��ID��Name��
        /// </summary>
        internal const string TREE_NAME_GLOBALVALUE_ID_AND_NAME = "�ڵ�����";

        /// <summary>
        /// ����������Ϊȫ�ֱ���ʱ��ID��Name��
        /// </summary>
        internal const string DONAMIC_ROWNUM_GLOBALVALUE_ID_AND_NAME = "����";

        /// <summary>
        /// ����������Ϊȫ�ֱ���ʱ��ID��Name��
        /// </summary>
        internal const string DONAMIC_COLUMNNUM_GLOBALVALUE_ID_AND_NAME = "����";

        /// <summary>
        /// �����ѯ��ʱ��Ϊȫ�ֱ���ʱ��ID��Name��
        /// </summary>
        internal const string DONAMIC_TIMEUSED_GLOBALVALUE_ID_AND_NAME = "��ʱ";

        /// <summary>
        /// ��ͷ������Ĭ���п�
        /// </summary>
        internal const float HEADER_SETTING_COLUMN_WIDTH = 60;

        /// <summary>
        /// ��ͷ������Ĭ���иߡ�
        /// </summary>
        internal const float HEADER_SETTING_ROW_HEIGHT = 20;
    }
}
