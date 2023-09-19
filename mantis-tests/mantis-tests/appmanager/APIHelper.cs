using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<ProjectData> GetProjects()
        {
            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();           
            Mantis.ProjectData [] projectsMantis = client.mc_projects_get_user_accessible(account.Name,account.Password);
            foreach (Mantis.ProjectData pr in projectsMantis)
            {
                projects.Add(new ProjectData(pr.name)
                {
                    Id = pr.id,
                    Description = pr.description
                });
            }
            return projects;
        }
        public void CreateProject() 
        {
            AccountData account = new AccountData("administrator", "root");
            Mantis.ProjectData projectMantis = new Mantis.ProjectData();
            projectMantis.name = "test" + TestBase.GenerateRandomString(3);
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_add(account.Name, account.Password, projectMantis);
        }
    }
}
