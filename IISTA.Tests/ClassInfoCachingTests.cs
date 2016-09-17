using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using IISTA.AssemblySearch;

namespace IISTA.Tests
{
    [TestClass]
    public class ClassInfoCachingTests
    {
        [TestMethod]
        public void ClassInfoChashingShouldReturnSameInstances()
        {
            ClassInfoCaching classInfoCaching = ClassInfoCaching.Instance;
            ClassInfoCaching classInfoCachingNewInstance = ClassInfoCaching.Instance;

            IDictionary<string, Type> result = classInfoCaching.ClassesInfo;
            IDictionary<string, Type> resultFormNewInstance = classInfoCachingNewInstance.ClassesInfo;

            Assert.AreSame(result, resultFormNewInstance);
        }
    }
}
