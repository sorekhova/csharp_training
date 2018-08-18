using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux;
        private GroupHelper groupHelper;
        public ApplicationManager()
        {
            
            aux = new AutoItX3();

            aux.Run(@"c:\Temp\FreeAddressBookPortable\AddressBook.exe", @"c:\Temp\FreeAddressBookPortable\",aux.SW_SHOW);
 
            aux.WinWait(WINTITLE,"",500);
 //           aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE,"",500);

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.Sleep(1000);
                       aux.ControlClick(WINTITLE, "&Exit", "WindowsForms10.BUTTON.app.0.2c908d510");
         //   aux.ControlClick(WINTITLE, "&Exit", "");

        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
    }
}
