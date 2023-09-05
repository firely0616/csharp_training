using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHalper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHalper(ApplicationManager manager) : base(manager)
        {
            
        }


        public void Add(GroupData group)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
            aux.Send(group.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }
        public void OpenGroupsDialogue() 
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
            aux.WinWait(GROUPWINTITLE);
        }
        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for(int i = 0; i< int.Parse(count); i++)
            {
               string item =  aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i, "");
                list.Add(new GroupData() {Name = item});
            }
            return list;
        }
    }
}