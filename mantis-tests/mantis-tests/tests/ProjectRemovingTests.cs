using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovingTests : TestBase
    {
        [Test]
        public void ProjectRemovingTest() 
        {
            List<ProjectData> projects = new List<ProjectData>();
            projects = app.api.GetProjects();
            if (projects.Count == 0)
            {
                app.api.CreateProject();
                projects = app.api.GetProjects();
            }
            app.Navigator.GoToControlPanel();
            app.Navigator.GoToProjectControlPanel();
            app.Project.Remove();          
            List<ProjectData> newProjects = app.api.GetProjects();
            Assert.AreEqual(projects.Count()-1, newProjects.Count());
        }
    }
}
