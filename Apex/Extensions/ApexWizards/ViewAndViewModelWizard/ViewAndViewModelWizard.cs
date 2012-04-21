using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;

namespace ApexWizards.ViewAndViewModelWizard
{
    /// <summary>
    /// The ViewAndViewModelWizard is the IWizard implementation
    /// that provides a Wizard for a View and ViewModel item.
    /// </summary>
    public class ViewAndViewModelWizard : IWizard
    {
        /// <summary>
        /// Runs custom wizard logic before opening an item in the template.
        /// </summary>
        /// <param name="projectItem">The project item that will be opened.</param>
        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when a project has finished generating.
        /// </summary>
        /// <param name="project">The project that finished generating.</param>
        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when a project item has finished generating.
        /// </summary>
        /// <param name="projectItem">The project item that finished generating.</param>
        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when the wizard has completed all tasks.
        /// </summary>
        public void RunFinished()
        {
        }

        /// <summary>
        /// Runs custom wizard logic at the beginning of a template wizard run.
        /// </summary>
        /// <param name="automationObject">The automation object being used by the template wizard.</param>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        /// <param name="runKind">A <see cref="T:Microsoft.VisualStudio.TemplateWizard.WizardRunKind"/> indicating the type of wizard run.</param>
        /// <param name="customParams">The custom parameters with which to perform parameter replacement in the project.</param>
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                //  Create the wizard view.
                ViewAndViewModelWizardView view = new ViewAndViewModelWizardView();

                view.ViewModel.BaseName = replacementsDictionary["$rootname$"];

                //  Set the view model name.
                replacementsDictionary.Add("$BaseName$", view.ViewModel.BaseName);
                replacementsDictionary.Add("$ViewModelName$", view.ViewModel.ViewModelName);
                replacementsDictionary.Add("$ViewName$", view.ViewModel.ViewName);
                replacementsDictionary.Add("$ViewCreatesViewModel$", view.ViewModel.ViewCreatesViewModel ? "1" : "0");

                //  Show the view.
                view.ShowDialog();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Indicates whether the specified project item should be added to the project.
        /// </summary>
        /// <param name="filePath">The path to the project item.</param>
        /// <returns>
        /// true if the project item should be added to the project; otherwise, false.
        /// </returns>
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
