using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using QuickReportLib.Enums;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// �ṩ�뷴����صķ����ľ�̬�ࡣ
    /// </summary>
    internal static class ReflectionManager
    {
        private static Assembly assembly;
        private static Type[] types;

        static ReflectionManager()
        {
            string dllName = string.Empty;
            string nameSpace = typeof(ReflectionManager).Namespace;
            dllName = nameSpace.Split('.')[0] + ".dll";
            assembly = Assembly.LoadFrom(dllName);
            types = assembly.GetTypes();
        }

        /// <summary>
        /// ����������ʵ�ֵĽӿڣ��Լ����͵����ͣ�����ñ�Dll�����з���������Type��
        /// </summary>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <param name="type">���͵����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypesByInterface(Type interfaceType, TypeOfType type)
        {
            List<Type> typeList = new List<Type>();
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsInterface)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Class:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsClass)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Enum:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsEnum)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
            }
            return typeList;
        }

        /// <summary>
        /// ����������ʵ�ֵĽӿڣ��Լ����͵����ͣ�����ñ�Dll�����з���������Type�����˳����ࣩ��
        /// </summary>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <param name="type">���͵����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypesByInterfaceWithOutAbstract(Type interfaceType, TypeOfType type)
        {
            List<Type> typeList = new List<Type>();
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsInterface&&!types[j].IsAbstract)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Class:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsClass && !types[j].IsAbstract)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Enum:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsEnum && !types[j].IsAbstract)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
            }
            return typeList;
        }

        /// <summary>
        /// ����������ʵ�ֵĸ��࣬�Լ����͵����ͣ�����ñ�Dll�����з���������Type��
        /// </summary>
        /// <param name="interfaceType">�������͡�</param>
        /// <param name="type">���͵����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypesByBaseClass(Type baseClassType, TypeOfType type)
        {
            List<Type> typeList = new List<Type>();
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].IsSubclassOf(baseClassType) && types[j].IsInterface)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Class:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].IsSubclassOf(baseClassType) && types[j].IsClass)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Enum:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].IsSubclassOf(baseClassType) && types[j].IsEnum)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
            }
            return typeList;
        }

        /// <summary>
        /// ����Dll���ƣ��Լ�������ʵ�ֵĽӿڣ���������з���������Type��
        /// </summary>
        /// <param name="dllName">Dll���ơ�</param>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <param name="type">���͵����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypesByInterface(string dllName, Type interfaceType, TypeOfType type)
        {
            Assembly assembly;
            assembly = Assembly.LoadFrom(dllName);
            Type[] types = assembly.GetTypes();
            List<Type> typeList = new List<Type>();
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsInterface)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Class:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsClass)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Enum:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsEnum)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
            }
            return typeList;
        }

        /// <summary>
        /// ����Dll���ƣ��Լ�������ʵ�ֵĽӿڣ���������з���������Type�����������⣩��
        /// </summary>
        /// <param name="dllName">Dll���ơ�</param>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <param name="type">���͵����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypesByInterfaceWithOutAbstract(string dllName, Type interfaceType, TypeOfType type)
        {
            Assembly assembly;
            assembly = Assembly.LoadFrom(dllName);
            Type[] types = assembly.GetTypes();
            List<Type> typeList = new List<Type>();
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsInterface&&!types[j].IsAbstract)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Class:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsClass && !types[j].IsAbstract)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Enum:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsEnum && !types[j].IsAbstract)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
            }
            return typeList;
        }

        /// <summary>
        /// ����������ʵ�ֵĸ��࣬�Լ����͵����ͣ�����ñ�Dll�����з���������Type��
        /// </summary>
        /// <param name="dllName">Dll���ơ�</param>
        /// <param name="interfaceType">�������͡�</param>
        /// <param name="type">���͵����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypesByBaseClass(string dllName, Type baseClassType, TypeOfType type)
        {
            Assembly assembly;
            assembly = Assembly.LoadFrom(dllName);
            Type[] types = assembly.GetTypes();
            List<Type> typeList = new List<Type>();
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].IsSubclassOf(baseClassType) && types[j].IsInterface)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Class:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].IsSubclassOf(baseClassType) && types[j].IsClass)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
                case TypeOfType.Enum:
                    {
                        for (int j = 0; j < types.Length; j++)
                        {
                            if (types[j].IsSubclassOf(baseClassType) && types[j].IsEnum)
                            {
                                typeList.Add(types[j]);
                            }
                        }
                        break;
                    }
            }
            return typeList;
        }

        /// <summary>
        /// ����Dll�����������������ʵ����
        /// </summary>
        /// <param name="dllName">Dll���ơ�</param>
        /// <param name="className">������</param>
        /// <returns>���ʵ����</returns>
        public static object CreateInstanceByClassName(string dllName, string className)
        {
            Assembly assembly;
            assembly = Assembly.LoadFrom(dllName);
            Type type = assembly.GetType(className);
            if (type == null)
            {
                return null;
            }
            else
            {
                object obj = Activator.CreateInstance(type);
                return obj;
            }
        }

        /// <summary>
        /// ���ݱ�Dll�µ������������ʵ����
        /// </summary>
        /// <param name="className">������</param>
        /// <returns>���ʵ����</returns>
        public static object CreateInstanceByClassName(string className)
        {
            Type type = assembly.GetType(className);
            if (type == null)
            {
                return null;
            }
            else
            {
                object obj = Activator.CreateInstance(type);
                return obj;
            }
        }

        /// <summary>
        /// ���ݱ�Dll�µ������������ʵ����
        /// </summary>
        /// <param name="className">������</param>
        /// <returns>���ʵ����</returns>
        public static object CreateInstanceByType(Type type)
        {
            object obj = Activator.CreateInstance(type);
            return obj;
        }

        /// <summary>
        /// ���ݽӿ����ͣ���ñ�Dll������ʵ�ָýӿڵ���ʵ����
        /// </summary>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <returns>���ʵ����</returns>
        public static List<object> CreateInstancesByInterface(Type interfaceType)
        {
            List<Type> typeList = GetTypesByInterface(interfaceType, TypeOfType.Class);
            List<object> objectList = new List<object>();
            foreach (Type type in typeList)
            {
                object obj = Activator.CreateInstance(type);
                objectList.Add(obj);
            }
            return objectList;
        }

        /// <summary>
        /// ���ݽӿ����ͣ���ñ�Dll������ʵ�ָýӿڵ���ʵ�������˳����ࣩ��
        /// </summary>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <returns>���ʵ����</returns>
        public static List<object> CreateInstancesByInterfaceWithOutAbstract(Type interfaceType)
        {
            List<Type> typeList = GetTypesByInterfaceWithOutAbstract(interfaceType, TypeOfType.Class);
            List<object> objectList = new List<object>();
            foreach (Type type in typeList)
            {
                object obj = Activator.CreateInstance(type);
                objectList.Add(obj);
            }
            return objectList;
        }

        /// <summary>
        /// ���ݽӿ�������ñ�Dll������ʵ�ָýӿڵ���ʵ����
        /// </summary>
        /// <param name="baseClassType">�������͡�</param>
        /// <returns>���ʵ����</returns>
        public static List<object> CreateInstancesByBaseClass(Type baseClassType)
        {
            List<Type> typeList = GetTypesByBaseClass(baseClassType, TypeOfType.Class);
            List<object> objectList = new List<object>();
            foreach (Type type in typeList)
            {
                object obj = Activator.CreateInstance(type);
                objectList.Add(obj);
            }
            return objectList;
        }
    }
}
