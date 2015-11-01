using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections;
using System.Data;

namespace QuickReportCore.Managers
{
    internal class Functions
    {
        private const Int32 AW_HOR_POSITIVE = 0x00000001;
        private const Int32 AW_HOR_NEGATIVE = 0x00000002;
        private const Int32 AW_VER_POSITIVE = 0x00000004;
        private const Int32 AW_VER_NEGATIVE = 0x00000008;
        private const Int32 AW_CENTER = 0x00000010;
        private const Int32 AW_HIDE = 0x00010000;
        private const Int32 AW_ACTIVATE = 0x00020000;
        private const Int32 AW_SLIDE = 0x00040000;
        private const Int32 AW_BLEND = 0x00080000;

        public static ToolTip toolTip;
        static Functions()
        {
            toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ForeColor = Color.Blue;
            toolTip.ToolTipTitle = "提示";
            toolTip.ShowAlways = true;
        }

        static void InitToolTip()
        {
            toolTip.Dispose();
            toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ForeColor = Color.Blue;
            toolTip.ToolTipTitle = "提示";
            toolTip.ShowAlways = true;
        }

        public static void ShowToolTip(Control c, string message)
        {
            InitToolTip();
            toolTip.Show(message, c, 5000);
        }

        public static void ShowToolTip(Control c, string message, bool focus)
        {
            InitToolTip();
            toolTip.Show(message, c, 5000);
            if (focus)
                c.Focus();
        }

        public static void ShowToolTip(Control c, string message, int during)
        {
            InitToolTip();
            toolTip.Show(message, c, during);
        }

        public static void ShowToolTip(Control c, string message, Point location)
        {
            InitToolTip();
            toolTip.Show(message, c, location, 5000);
        }

        public static void ShowToolTip(Control c, string message, int during, Point location)
        {
            InitToolTip();
            toolTip.Show(message, c, location, during);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool AnimateWindow(
         IntPtr hwnd,
         int dwTime,
         int dwFlags
         );

        /// <summary>
        /// 动画效果：让窗口淡入。
        /// </summary>
        /// <param name="handle">窗体的指针。</param>
        /// <param name="duringTime">持续时间。</param>
        public static void AnimateWindowBlendIn(IntPtr handle, int duringTime)
        {
            AnimateWindow(handle, duringTime, AW_BLEND | AW_ACTIVATE);
        }

        /// <summary>
        /// 动画效果：让窗口淡出。
        /// </summary>
        /// <param name="handle">窗体的指针。</param>
        /// <param name="duringTime">持续时间。</param>
        public static void AnimateWindowBlendOut(IntPtr handle, int duringTime)
        {
            AnimateWindow(handle, duringTime, AW_SLIDE | AW_HIDE | AW_BLEND);
        }

        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// 获得当前活动窗口的句柄。
        /// </summary>
        /// <returns>当前活动窗口的句柄。</returns>
        public static IntPtr GetActivityWindow()
        {
            return GetForegroundWindow();
        }

        const int WM_NCACTIVATE = 0x86;
        const int WA_ACTIVE = 0x1;
        const int WA_UNACTIVE = 0x0;
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        /// <summary>
        /// 使某窗体处于非激活状态。
        /// </summary>
        /// <param name="handle">窗体的句柄。</param>
        /// <returns>是否成功。</returns>
        public static int SetWindowUnActivate(IntPtr handle)
        {
            return SendMessage(handle, WM_NCACTIVATE, WA_UNACTIVE, 0);
        }

        /// <summary>
        /// 使某窗体获得激活状态。
        /// </summary>
        /// <param name="handle">窗体的句柄。</param>
        /// <returns>是否成功。</returns>
        public static int SetWindowActivate(IntPtr handle)
        {
            return SendMessage(handle, WM_NCACTIVATE, WA_ACTIVE, 0);
        }

        static Managers.QuickReportManager qr = new QuickReportManager();
        /// <summary>
        /// 解析Sql。
        /// </summary>
        /// <returns>解析出来的列与条件。</returns>
        public static ArrayList ParseSql(string s)
        {
            if (s.Trim() == string.Empty)
                return null;
            s = TranslateTextWithSystemValue(s);
            s = "Select * From ( \n " + s + " \n )  Where 1<>1";
            DataSet ds = new DataSet();
            int i = qr.ExecQuery(s, ref ds);
            if (i < 0)
                return null;
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
                return null;
            DataTable dt = ds.Tables[0];

            List<QuickReportCore.Objects.Column> columnList = new List<QuickReportCore.Objects.Column>();
            List<QuickReportCore.Objects.Condition> conditionList = new List<QuickReportCore.Objects.Condition>();

            Hashtable htTestor = new Hashtable();
            for (int index = 0; index < dt.Columns.Count; index++)
            {
                if (htTestor.Contains(dt.Columns[index].ColumnName))
                    return null;
                htTestor.Add(dt.Columns[index].ColumnName, dt.Columns[index].ColumnName);
                QuickReportCore.Objects.Column column = new QuickReportCore.Objects.Column();
                QuickReportCore.Objects.Condition condition = new QuickReportCore.Objects.Condition();
                column.ID = condition.ID = column.Name = condition.Name = dt.Columns[index].ColumnName;
                column.SortId = condition.SortId = index;
                if (dt.Columns[index].DataType == typeof(System.Decimal) || dt.Columns[index].DataType == typeof(System.Int32))
                {
                    column.IsNumber = true;
                }
                Objects.ConditionType ct = Objects.ConditionType.DataTypeCompareToConditionType[dt.Columns[index].DataType] as Objects.ConditionType;
                if (ct != null)
                    condition.ConditionType = ct;
                columnList.Add(column);
                conditionList.Add(condition);
            }
            ArrayList list = new ArrayList();
            list.Add(columnList);
            list.Add(conditionList);
            return list;
        }

        /// <summary>
        /// 获取SQL查询出的结果集中每列的数据类型。
        /// </summary>
        /// <param name="sql">SQL。</param>
        /// <returns>条件类型的集合。</returns>
        static Objects.ConditionType[] GetDataType(string sql)
        {
            return null;
        }

        /// <summary>
        /// 根据系统变量的ID获得系统变量的值。
        /// </summary>
        /// <param name="systemValueID">系统变量的ID。</param>
        /// <returns>系统变量的值。</returns>
        public static string ConvertToSystemValue(string systemValueID)
        {
            return ((PublicInterfaces.ISystemValue)Forms.frmToolBoxSystemValue.htSystemValueList[systemValueID]).Value;
        }

        /// <summary>
        /// 将使用了系统变量的Text中的系统变量进行替换后并返回。
        /// </summary>
        /// <param name="text">原Text。</param>
        /// <returns>替换后的Text。</returns>
        public static string TranslateTextWithSystemValue(string text)
        {
            if (!text.Contains("["))//如果text中不含有变量，则返回text。
                return text;
            foreach (DictionaryEntry de in Forms.frmToolBoxSystemValue.htSystemValueList)
            {
                text = text.Replace(Managers.Functions.GetSQLCode(de.Key.ToString(), SQLCodeType.System) , ((PublicInterfaces.ISystemValue)de.Value).Value);
            }
            return text;
        }

        /// <summary>
        /// 根据XmlNode以及属性名获得属性值。
        /// </summary>
        /// <param name="node">XmlNode。</param>
        /// <param name="attrName">属性名。</param>
        /// <param name="valueWhenNull">当Node为Null时，返回的值。</param>
        /// <returns>属性值</returns>
        public static string GetNodeAttrValue(System.Xml.XmlNode node,string attrName,string valueWhenNull)
        {
            if (node.Attributes[attrName] == null)
                return valueWhenNull;
            else
                return node.Attributes[attrName].Value;
        }


        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        /// <summary>
        /// 让鼠标执行一次单击操作。
        /// </summary>
        public static void MouseClick()
        {
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        /// <summary>
        /// 根据字符串获得该字符串在SQL中的表示方式。
        /// </summary>
        /// <param name="code">字符串。</param>
        /// <param name="type">Code的的类型。</param>
        /// <returns>其在SQL中的表示方式。</returns>
        public static string GetSQLCode(string code,SQLCodeType type)
        {
            return "[" + type.ToString() + "-" + code + "]";
        }

        public enum SQLCodeType
        { 
            /// <summary>
            /// 树。
            /// </summary>
            Tree,
            /// <summary>
            /// 列。
            /// </summary>
            Column,
            /// <summary>
            /// 条件。
            /// </summary>
            Condition,
            /// <summary>
            /// 系统。
            /// </summary>
            System,
            /// <summary>
            /// 动态。例如行数、列数等在查询之后才有的值。
            /// </summary>
            Dynamic
        }

        [DllImport("user32")]
        public static extern IntPtr GetSystemMenu(IntPtr hwnd, int bRevert);
        [DllImport("user32")]
        public static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        public const int MF_BYPOSITION = 0x400;

        public static int RemoveCloseMenu(IntPtr hwnd)
        {
            return RemoveMenu(GetSystemMenu(hwnd, 0), 6, MF_BYPOSITION);
        }

        /// <summary>
        /// 根据Dll名称，以及类型所实现的接口，来获得所有符合条件的所有Type。
        /// </summary>
        /// <param name="dllName">Dll名称。</param>
        /// <param name="interfaceType">接口类型。</param>
        /// <returns>Type集合。</returns>
        public static List<Type> GetTypes(string dllName, Type interfaceType)
        {
            try
            {
                System.Reflection.Assembly assembly;
                List<Type> listType = new List<Type>();
                assembly = System.Reflection.Assembly.LoadFrom(dllName);
                Type[] types = assembly.GetTypes();
                for (int j = 0; j < types.Length; j++)
                {
                    if (types[j].GetInterface(interfaceType.Name) != null)
                        listType.Add(types[j]);
                }
                return listType;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据Dll名称，以及类型所实现的接口，来获得所有符合条件的所有Type。
        /// </summary>
        /// <param name="dllName">Dll名称。</param>
        /// <param name="interfaceType">接口类型。</param>
        /// <param name="type">类型的类型。</param>
        /// <returns>Type集合。</returns>
        public static List<Type> GetTypes(string dllName, Type interfaceType,TypeOfType type)
        {
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        try
                        {
                            System.Reflection.Assembly assembly;
                            List<Type> listType = new List<Type>();
                            assembly = System.Reflection.Assembly.LoadFrom(dllName);
                            Type[] types = assembly.GetTypes();
                            for (int j = 0; j < types.Length; j++)
                            {
                                if (types[j].GetInterface(interfaceType.Name) != null&&types[j].IsInterface)
                                    listType.Add(types[j]);
                            }
                            return listType;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                case TypeOfType.Class:
                    {
                        try
                        {
                            System.Reflection.Assembly assembly;
                            List<Type> listType = new List<Type>();
                            assembly = System.Reflection.Assembly.LoadFrom(dllName);
                            Type[] types = assembly.GetTypes();
                            for (int j = 0; j < types.Length; j++)
                            {
                                if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsClass)
                                    listType.Add(types[j]);
                            }
                            return listType;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                case TypeOfType.Enum:
                    {
                        try
                        {
                            System.Reflection.Assembly assembly;
                            List<Type> listType = new List<Type>();
                            assembly = System.Reflection.Assembly.LoadFrom(dllName);
                            Type[] types = assembly.GetTypes();
                            for (int j = 0; j < types.Length; j++)
                            {
                                if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsEnum)
                                    listType.Add(types[j]);
                            }
                            return listType;
                        }
                        catch
                        {
                            return null;
                        }
                    }
            }
            return null;
        }

        /// <summary>
        /// 类型的类型。
        /// </summary>
        public enum TypeOfType
        { 
            /// <summary>
            /// 接口。
            /// </summary>
            Interface,
            /// <summary>
            /// 类。
            /// </summary>
            Class,
            /// <summary>
            /// 枚举。
            /// </summary>
            Enum
        }

        /// <summary>
        /// 根据Dll名称与类名，获得类实例。
        /// </summary>
        /// <param name="dllName">Dll名称。</param>
        /// <param name="className">类名。</param>
        /// <returns>类的实例。</returns>
        public static object CreateInstance(string dllName, string className)
        {
            try
            {
                System.Reflection.Assembly assembly;
                assembly = System.Reflection.Assembly.LoadFrom(dllName.Trim());
                Type type = assembly.GetType(className.Trim());
                if (type == null)
                    return null;
                else
                    return System.Activator.CreateInstance(type);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得当前QuickReport的最新版本号。
        /// </summary>
        /// <returns>最新版本号。</returns>
        public static decimal GetLastestVersion()
        {
            decimal ver = 1.00m;
            try
            {
                List<Type> typeList = GetTypes("QuickReportCore.dll", typeof(Interfaces.IAmReport));
                for (int i = 0; i < typeList.Count; i++)
                {
                    decimal tempVer = (System.Activator.CreateInstance(typeList[i]) as Interfaces.IAmReport).Version;
                    if (tempVer > ver)
                        ver = tempVer;
                    else
                        continue;
                }
            }
            catch
            {
                return ver;
            }
            return ver;
        }

        /// <summary>
        /// 根据XML版本号，获得最适合的UcReport。
        /// </summary>
        /// <param name="version">版本号。</param>
        /// <returns>Interfaces.IAmReport。</returns>
        public static Interfaces.IAmReport GetPerfectReportControl(decimal version)
        {
            if(0<version&&version<2)
                return System.Activator.CreateInstance(typeof(QuickReportCore.Controls.Report.ucReportV100)) as Interfaces.IAmReport;
            return null;
        }
    }
}
