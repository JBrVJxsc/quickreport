using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using QuickReportLib.Enums;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// 提供与反射相关的方法的静态类。
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
        /// 根据类型所实现的接口，以及类型的类型，来获得本Dll下所有符合条件的Type。
        /// </summary>
        /// <param name="interfaceType">接口类型。</param>
        /// <param name="type">类型的类型。</param>
        /// <returns>Type集合。</returns>
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
        /// 根据类型所实现的接口，以及类型的类型，来获得本Dll下所有符合条件的Type（除了抽象类）。
        /// </summary>
        /// <param name="interfaceType">接口类型。</param>
        /// <param name="type">类型的类型。</param>
        /// <returns>Type集合。</returns>
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
        /// 根据类型所实现的父类，以及类型的类型，来获得本Dll下所有符合条件的Type。
        /// </summary>
        /// <param name="interfaceType">父类类型。</param>
        /// <param name="type">类型的类型。</param>
        /// <returns>Type集合。</returns>
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
        /// 根据Dll名称，以及类型所实现的接口，来获得所有符合条件的Type。
        /// </summary>
        /// <param name="dllName">Dll名称。</param>
        /// <param name="interfaceType">接口类型。</param>
        /// <param name="type">类型的类型。</param>
        /// <returns>Type集合。</returns>
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
        /// 根据Dll名称，以及类型所实现的接口，来获得所有符合条件的Type（除抽象类外）。
        /// </summary>
        /// <param name="dllName">Dll名称。</param>
        /// <param name="interfaceType">接口类型。</param>
        /// <param name="type">类型的类型。</param>
        /// <returns>Type集合。</returns>
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
        /// 根据类型所实现的父类，以及类型的类型，来获得本Dll下所有符合条件的Type。
        /// </summary>
        /// <param name="dllName">Dll名称。</param>
        /// <param name="interfaceType">父类类型。</param>
        /// <param name="type">类型的类型。</param>
        /// <returns>Type集合。</returns>
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
        /// 根据Dll名称与类名，获得类实例。
        /// </summary>
        /// <param name="dllName">Dll名称。</param>
        /// <param name="className">类名。</param>
        /// <returns>类的实例。</returns>
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
        /// 根据本Dll下的类名，获得类实例。
        /// </summary>
        /// <param name="className">类名。</param>
        /// <returns>类的实例。</returns>
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
        /// 根据本Dll下的类名，获得类实例。
        /// </summary>
        /// <param name="className">类名。</param>
        /// <returns>类的实例。</returns>
        public static object CreateInstanceByType(Type type)
        {
            object obj = Activator.CreateInstance(type);
            return obj;
        }

        /// <summary>
        /// 根据接口类型，获得本Dll下所有实现该接口的类实例。
        /// </summary>
        /// <param name="interfaceType">接口类型。</param>
        /// <returns>类的实例。</returns>
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
        /// 根据接口类型，获得本Dll下所有实现该接口的类实例（除了抽象类）。
        /// </summary>
        /// <param name="interfaceType">接口类型。</param>
        /// <returns>类的实例。</returns>
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
        /// 根据接口名，获得本Dll下所有实现该接口的类实例。
        /// </summary>
        /// <param name="baseClassType">父类类型。</param>
        /// <returns>类的实例。</returns>
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
