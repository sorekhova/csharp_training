﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests 
{
    
 
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        //[TestFixtureSetUp]
        //public void setUpConfig()
        //{
        //    app.Ftp.BackupFile("");
        //    app.Ftp.Upload("",null);
        //}

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("");
        }
    }
}
