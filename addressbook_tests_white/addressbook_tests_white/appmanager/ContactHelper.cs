using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;


namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
       
        public static string CONTACTWINTITLE = "Contact Editor";

        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");
            TableRows tableRows = table.Rows;
            
            foreach (TableRow row in tableRows)
            {
                TableCells cells = row.Cells;
 
                list.Add(new ContactData(cells[0].Value.ToString(), cells[1].Value.ToString()));
            }        
 
            return list;
        }

        internal void Remove(int index)
        {
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");
            table.Rows[index].Click();
            manager.MainWindow.Get<Button>("uxDeleteAddressButton").Click();
            Window msgbox = manager.MainWindow.ModalWindow("Question");
            msgbox.Get<Button>(SearchCriteria.ByText("Yes")).Click();
            
        }

        public int GetContactCount()
        {
           return manager.MainWindow.Get<Table>("uxAddressGrid").Rows.Count;
        }

        public void Create(ContactData contact)
        {
            Window dialogue = OpenContactDialogue();
               
            TextBox textBox = (TextBox) dialogue.Get<TextBox>("ueFirstNameAddressTextBox");
            textBox.Enter(contact.Firstname);
            textBox = (TextBox)dialogue.Get<TextBox>("ueLastNameAddressTextBox");
            textBox.Enter(contact.Lastname);

            CloseContactsDialogue(dialogue);
        }

        private Window OpenContactDialogue()
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            return manager.MainWindow.ModalWindow(CONTACTWINTITLE);
        }

        private void CloseContactsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxSaveAddressButton").Click();
        }
        
    }
}
