using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryCreationTests : TestBase
    {
 
        [Test]
        public void EntryCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));

            AddNewEntry();

            EntryData entry = new EntryData("Иван", "Иванов");
            /*
            entry.Home = "+7(921)999-99-00";
            entry.Address2 = "Санкт-Петербург";
            entry.Bmonth = "May";
            entry.Amonth = "June";
            entry.New_group = "aaa";
            entry.Photo = "C:\\Users\\Public\\Pictures\\Sample Pictures\\Chrysanthemum.jpg";
            entry.Aday = "1";
            entry.Address = "Moscow";
            entry.Ayear = "2019";
            entry.Bday = "2";
            entry.Byear = "1900";
            entry.Company = "Emerson";
            entry.Email = "iivanov@mail.com";
            entry.Email2 = "iivanov@gmail.com";
            entry.Email3 = "iivanov@yandex.ru";
            entry.Fax = "+7(905)222-22-22";
            entry.Homepage = "https://docs.microsoft.com";
            entry.Middlename = "Иванович";
            entry.Mobile = "+7";
            entry.Nickname = "iii";
            */

            FillEntry(entry);
            SubmitCreation();
            LogOut();
        }

     }
}

