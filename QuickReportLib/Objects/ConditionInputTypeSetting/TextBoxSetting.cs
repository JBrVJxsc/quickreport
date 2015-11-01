using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.ConditionInputType;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// �ı�����������ʵ�塣
    /// </summary>
    public class TextBoxSetting : BaseInputTypeSetting
    {
        private string defaultValue = string.Empty;
        private bool onlyNumber = false;
        private bool leftZero = false;
        private int leftZeroPlace = 10;
        private bool userSelector = false;
        private string selectorSQL = string.Empty;
        private string outPutColumn = string.Empty;
        private bool hideOutPutColumn = true;
        private string selectorTitle = "��ѡ��һ����¼";
        private string selectorNullMessage = "δ���ҵ���Ч��¼��";

        /// <summary>
        /// Ĭ��ֵ��
        /// </summary>
        public string DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;
            }
        }

        /// <summary>
        /// �Ƿ�����Ϊ���֡�
        /// </summary>
        public bool OnlyNumber
        {
            get
            {
                return onlyNumber;
            }
            set
            {
                onlyNumber = value;
            }
        }

        /// <summary>
        /// �Ƿ����㡣
        /// </summary>
        public bool LeftZero
        {
            get
            {
                return leftZero;
            }
            set
            {
                leftZero = value;
            }
        }

        /// <summary>
        /// ����λ����
        /// </summary>
        public int LeftZeroPlace
        {
            get
            {
                return leftZeroPlace;
            }
            set
            {
                leftZeroPlace = value;
            }
        }

        /// <summary>
        /// �Ƿ�ʹ��ѡ���
        /// </summary>
        public bool UserSelector
        {
            get
            {
                return userSelector;
            }
            set
            {
                userSelector = value;
            }
        }

        /// <summary>
        /// ѡ����SQL��
        /// </summary>
        public string SelectorSQL
        {
            get
            {
                return selectorSQL;
            }
            set
            {
                selectorSQL = value;
            }
        }

        /// <summary>
        /// �����С�
        /// </summary>
        public string OutPutColumn
        {
            get
            {
                return outPutColumn;
            }
            set
            {
                outPutColumn = value;
            }
        }

        /// <summary>
        /// �Ƿ���������С�
        /// </summary>
        public bool HideOutPutColumn
        {
            get
            {
                return hideOutPutColumn;
            }
            set
            {
                hideOutPutColumn = value;
            }
        }

        /// <summary>
        /// ѡ�����⡣
        /// </summary>
        public string SelectorTitle
        {
            get
            {
                return selectorTitle;
            }
            set
            {
                selectorTitle = value;
            }
        }

        /// <summary>
        /// ��δ�ҵ�ֵʱ��ʾ����Ϣ��
        /// </summary>
        public string SelectorNullMessage
        {
            get
            {
                return selectorNullMessage;
            }
            set
            {
                selectorNullMessage = value;
            }
        }
    }
}
