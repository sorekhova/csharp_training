using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTestDetails()
        {
            ContactData contact = new ContactData("Сгей", "Сергеев");
            contact.Address2 = "Санкт-Петербург";
            contact.Bmonth = "May";
            contact.Amonth = "June";

            app.Contacts.ModifyViaDetails(1, contact);
        }

        [Test]
        public void ContactModificationTestDetailsBottom()
        {
            ContactData contact = new ContactData("Сергей", "Сергеев");
            contact.Address2 = "Ьщсква";
            contact.Bmonth = "May";
            contact.Amonth = "June";

            app.Contacts.ModifyViaDetails(1, contact, 2);
        }

        [Test]
        public void ContactModificationTestEdit()
        {
            ContactData contact = new ContactData("Сгей", "Сергеев");
            contact.Address2 = "Санкт-Петербург";
 
            app.Contacts.ModifyViaEdit(1, contact);
        }

        [Test]
        public void ContactModificationTestEditBottom()
        {
            ContactData contact = new ContactData("Иван", "Сергеев");
            contact.Address2 = "Владивосток";
 
            app.Contacts.ModifyViaEdit(1, contact, 2);
        }
    }
}
