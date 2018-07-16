using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTestDetails()
        {
            int index = 5;
            //preparation
            ContactData contact = new ContactData("Сгей", "Сергеев");
            contact.Address2 = null;
            contact.Bmonth = "May";
            contact.Amonth = "June";
           
            app.Contacts.IsContactPresent(index, app.Contacts.byDetails, contact);

            //action
            contact.Firstname = "Сергей";
            app.Contacts.ModifyViaDetails(index, contact);

            //verification
            Assert.IsTrue(app.Contacts.IsContactValidValue(index, "firstname", contact.Firstname));
        }

        [Test]
        public void ContactModificationTestDetailsBottom()
        {
            int index = 1;
            ContactData contact = new ContactData("Сергей", "Сергеев");
            contact.Address2 = "Ьщсква";
            contact.Bmonth = "May";
            contact.Amonth = "June";

            app.Contacts.IsContactPresent(index, app.Contacts.byDetails, contact);

            app.Contacts.ModifyViaDetails(index, contact, 2);
            Assert.IsTrue(app.Contacts.IsContactValidValue(index, "firstname", contact.Firstname));
        }

        [Test]
        public void ContactModificationTestEdit()
        {
            int index = 3;
            ContactData contact = new ContactData("Сгей", "Сергеев");
            contact.Address2 = "Санкт-Петербург";
            app.Contacts.IsContactPresent(index, app.Contacts.byEdit, contact);

            contact.Firstname = "Сергей";
            app.Contacts.ModifyViaEdit(index, contact);

            Assert.IsTrue(app.Contacts.IsContactValidValue(index, "firstname", contact.Firstname));
        }

        [Test]
        public void ContactModificationTestEditBottom()
        {
            int index = 1;
            ContactData contact = new ContactData("Иван", "Сергеев");
            contact.Address2 = "Владивосток";
            app.Contacts.IsContactPresent(index, app.Contacts.byEdit, contact);
            contact.Address2 = "Москва";

            app.Contacts.ModifyViaEdit(index, contact, 2);

            Assert.IsTrue(app.Contacts.IsContactValidValue(index, "address2", contact.Address2));
        }
    }
}
