using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Apex.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class GivenPersonViewModel
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
            personViewModel = new PersonViewModel();
        }

        [TestMethod]
        public void GetNotifyingPropertiesReturnsAllNotifyingProperties()
        {
            var notifyingProperties = personViewModel.GetNotifyingProperties().ToList();

            //  Assert we have the properties we'd expect.
            Assert.IsTrue(notifyingProperties.Count == 2, "Incorrect number of notifying properties..");
            Assert.IsTrue(notifyingProperties.Count(np => np.Name == "FirstName") > 0, "FirstName property is missing.");
            Assert.IsTrue(notifyingProperties.Count(np => np.Name == "SecondName") > 0, "SecondName property is missing.");
        }

        [TestMethod]
        public void NotifyPropertyChangedWorks()
        {
            //  Create a handler.
            bool called = false;
            string propertyName = null;
            personViewModel.PropertyChanged += (sender, args) => 
            {
                //  Ignore has changes.
                if (args.PropertyName == "HasChanges")
                    return;
                
                propertyName = args.PropertyName;
                called = true; 
            }; 

            //  Change a value.
            personViewModel.FirstName = "Homer";

            //  Assert it's changed.
            Assert.IsTrue(personViewModel.FirstName == "Homer", "Failed to save property.");

            //  Assert notify property changed is called.
            Assert.IsTrue(called == true, "Notify property changed was not called.");

            //  Assert the property name was passed.
            Assert.IsTrue(propertyName == "FirstName", "Property name was not passed correctly.");
        }

        [TestMethod]
        public void HasChangesIsSetCorrectly()
        {
            //  By default has changes should be false.
            Assert.IsTrue(personViewModel.HasChanges == false, "HasChanges is not initially set to false.");

            //  Change a value.
            personViewModel.FirstName = "Homer";

            //  Assert has changes is updated changed.
            Assert.IsTrue(personViewModel.HasChanges == true, "Has changes is not set when a property changes.");

            //  Reset the flag.
            personViewModel.ResetHasChangesFlag();

            //  Has changes should be false.
            Assert.IsTrue(personViewModel.HasChanges == false, "HasChanges is not set to false after ResetHasChangesFlag.");

            //  Set a property that isn't a change.
            personViewModel.FirstName = "Homer";

            //  Has changes should be false.
            Assert.IsTrue(personViewModel.HasChanges == false, "HasChanges is set to true after a change to an equivalent value.");
        }

        [TestMethod]
        public void CanSaveInitialState()
        {
            //  Set properties.
            personViewModel.FirstName = "Homer";
            personViewModel.SecondName = "Simpson";

            //  We should have changes.
            Assert.IsTrue(personViewModel.HasChanges, "Changes are not setting the HasChanges flag.");

            //  Set the initial state.
            personViewModel.SaveInitialState();

            //  We should have no changes.
            Assert.IsTrue(personViewModel.HasChanges == false, "SaveInitialState is not resetting the HasChanges flag.");
        }

        [TestMethod]
        public void CanRestoreInitialState()
        {
            //  Set properties.
            personViewModel.FirstName = "Homer";
            personViewModel.SecondName = "Simpson";

            //  We should have changes.
            Assert.IsTrue(personViewModel.HasChanges, "Changes are not setting the HasChanges flag.");

            //  Set the initial state.
            personViewModel.SaveInitialState();

            //  We should have no changes.
            Assert.IsTrue(personViewModel.HasChanges == false, "SaveInitialState is not resetting the HasChanges flag.");

            //  Make chanes.
            personViewModel.FirstName = "Ralph";
            personViewModel.SecondName = "Wiggum";

            //  We should have changes.
            Assert.IsTrue(personViewModel.HasChanges, "Changes are not setting the HasChanges flag.");

            //  Restore the initial state.
            personViewModel.RestoreInitialState();
            
            //  We should have no changes.
            Assert.IsTrue(personViewModel.HasChanges == false, "RestoreInitialState is not resetting the HasChanges flag.");

            //  Ensure we're back at the initial state.
            Assert.IsTrue(personViewModel.FirstName == "Homer", "Restore initial state hasn't restored a property.");
            Assert.IsTrue(personViewModel.SecondName == "Simpson", "Restore initial state hasn't restored a property.");
        }
    }
}