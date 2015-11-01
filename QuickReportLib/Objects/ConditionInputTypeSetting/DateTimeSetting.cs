using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.ConditionInputType;
using QuickReportLib.Managers;
using QuickReportLib.Objects.SystemValue;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    ///  DateTime��¼����������ʵ�塣
    /// </summary>
    public class DateTimeSetting : BaseInputTypeSetting
    {
        public DateTimeSetting()
        {
            if (systemValueType == string.Empty)
            {
                systemValueType=SQLManager.GetSQLCode(typeof(PCDateTime).Name, SQLCodeType.System);
            }
        }

        private string systemValueType = string.Empty;
        private string addOrSub = "+";
        private int day = 0;
        private int hour = 0;
        private int min = 0;
        private int sec = 0;
        private bool useFixedValue = false;
        private DateTime fixedValue = DateTime.Now;
        private string customFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// ϵͳ�������͡�
        /// </summary>
        public string SystemValueType
        {
            get
            {
                return systemValueType;
            }
            set
            {
                systemValueType = value;
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string AddOrSub
        {
            get
            {
                return addOrSub;
            }
            set
            {
                addOrSub = value;
            }
        }

        /// <summary>
        /// �졣
        /// </summary>
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }

        /// <summary>
        /// Сʱ��
        /// </summary>
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
            }
        }

        /// <summary>
        /// �֡�
        /// </summary>
        public int Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }

        /// <summary>
        /// �롣
        /// </summary>
        public int Sec
        {
            get
            {
                return sec;
            }
            set
            {
                sec = value;
            }
        }

        /// <summary>
        /// �Ƿ�ʹ�ù̶�ֵ��
        /// </summary>
        public bool UseFixedValue
        {
            get
            {
                return useFixedValue;
            }
            set
            {
                useFixedValue = value;
            }
        }

        /// <summary>
        /// �̶�ֵ��
        /// </summary>
        public DateTime FixedValue
        {
            get
            {
                return fixedValue;
            }
            set
            {
                fixedValue = value;
            }
        }

        /// <summary>
        /// �ؼ��ĸ�ʽ��
        /// </summary>
        public string CustomFormat
        {
            get
            {
                return customFormat;
            }
            set
            {
                customFormat = value;
            }
        }
    }
}
