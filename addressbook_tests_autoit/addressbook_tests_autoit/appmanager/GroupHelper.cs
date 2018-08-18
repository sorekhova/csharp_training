using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            };

            CloseGroupsDialogue();

            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();

            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");

            CloseGroupsDialogue();
            return;
        }

        public void Remove(int groupNumber)
        {

            OpenGroupsDialogue();

            aux.ControlTreeView(
                        GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                        "Select", "#0|#" + groupNumber, "");
            aux.Sleep(500);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");

            aux.WinWait(DELETEGROUPWINTITLE, "", 500);
            aux.WinWaitActive(DELETEGROUPWINTITLE, "", 500);

            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");

            CloseGroupsDialogue();
            return;
        }

        private void CloseGroupsDialogue()
        {
     //       aux.WinWait(GROUPWINTITLE, "", 500);
     //       aux.WinWaitActive(GROUPWINTITLE, "", 500);
                      aux.ControlClick(GROUPWINTITLE, "&Close", "WindowsForms10.BUTTON.app.0.2c908d54");
//            aux.ControlClick(GROUPWINTITLE, "&Close", "");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWaitActive(GROUPWINTITLE, "", 500);
 //           aux.WinWait(GROUPWINTITLE, "",500);
        }
    }
}