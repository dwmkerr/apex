using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apex.MVVM;

namespace Apex.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class GivenApexBroker
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private PersonViewModel personViewModel;

        [TestInitialize()]
        public void Given()
        {
            
        }

        [TestMethod]
        public void ExecutionContextIsTest()
        {
            Assert.IsTrue(ApexBroker.CurrentExecutionContext == ExecutionContext.Test, "ApexBroker is not corrently determining the execution context as 'Test'.");
        }
    }
}