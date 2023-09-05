using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private AutoItX3 aux;
        public static string WINTITLE = "Free Address Book";
        public ApplicationManager() 
        {
            aux = new AutoItX3();
            aux.Run(@"d:\addressbook\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
            groupHelper = new GroupHalper(this);
        }

        private GroupHalper groupHelper;
        public void Stop()
        {
            aux.ControlClick(WINTITLE,"", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public GroupHalper Groups
        { 
            get 
            {
                return groupHelper;
            } 
        }
        public AutoItX3 Aux { get { return aux; } }
    }
}
