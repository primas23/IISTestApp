using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using IISTA.Common;

namespace IISTA.AssemblySearch
{
    /// <summary>
    /// Generates Information for the Controllers classes and cashes it
    /// </summary>
    public sealed class ClassInfoCaching
    {
        private static IDictionary<string, Type> _classesInfo = null;

        private ClassInfoCaching()
        {
            string path = Directory.GetCurrentDirectory() + "\\" + Constants.ControllerAssemblyName;
            Assembly assembly = Assembly.LoadFile(path);

            _classesInfo = PopulateClassesInfo(assembly);
        }

        /// <summary>
        /// Gets the classes information.
        /// </summary>
        /// <value>
        /// The classes information.
        /// </value>
        /// <exception cref="Exception">The singelton does not work</exception>
        public IDictionary<string, Type> ClassesInfo
        {
            get
            {
                if (_classesInfo == null)
                {
                    throw new Exception("The singelton does not work");
                }

                return _classesInfo;
            }
        }

        /// <summary>
        /// Gets the instance of the ClassInfoCaching class.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ClassInfoCaching Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly ClassInfoCaching instance = new ClassInfoCaching();
        }

        /// <summary>
        /// Populates the classes information.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The populated classes info.</returns>
        private static Dictionary<string, Type> PopulateClassesInfo(Assembly assembly)
        {
            Dictionary<string, Type> result = new Dictionary<string, Type>();

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass)
                {
                    string nameOfClass = CutClassFullName(type.Name);

                    result[nameOfClass] = type;
                }
            }

            return result;
        }


        /// <summary>
        /// Cut unnecessary part of controller name
        /// </summary>
        /// <param name="fullName">The fullName</param>
        /// <returns>The name of controller </returns>
        private static string CutClassFullName(string fullName)
        {
            string cuttedClassName = fullName
                    .ToLower()
                    .Replace("pageview", string.Empty);

            return cuttedClassName;
        }
    }
}
