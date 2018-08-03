using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.Out.Write(args[0]);
            //System.Console.Out.Write(args[1]);
            string typeofdata = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            string[] monthes = { "-", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                if (typeofdata == "groups")
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                else if (typeofdata == "contacts")
                {
                    
                    contacts.Add(new ContactData()
                        {
                            Firstname = TestBase.GenerateRandomString(5),
                            Lastname = TestBase.GenerateRandomString(5),
                            Nickname = TestBase.GenerateRandomString(3),
                            Title = TestBase.GenerateRandomString(8),
                            Company = TestBase.GenerateRandomString(10),
                            Address = TestBase.GenerateRandomString(25),
                            Home = TestBase.GenerateRandomInt(10),
                            Mobile = TestBase.GenerateRandomInt(10),
                            Work = TestBase.GenerateRandomInt(10),
                            Email = TestBase.GenerateRandomString(10),
                            Email2 = TestBase.GenerateRandomString(10),
                            Email3 = TestBase.GenerateRandomString(10),
                            Bday = TestBase.GenerateRandomDay(),
                            Bmonth = monthes[Convert.ToInt32(TestBase.GenerateRandomMonth())],
                            Byear = TestBase.GenerateRandomYear(),
                            Middlename = TestBase.GenerateRandomString(10),
                            Aday = TestBase.GenerateRandomDay(),
                            Amonth = monthes[Convert.ToInt32(TestBase.GenerateRandomMonth())],
                            Ayear = TestBase.GenerateRandomYear(),
                            Address2 = TestBase.GenerateRandomString(30),
                            Phone2 = TestBase.GenerateRandomInt(10),
                            Notes = TestBase.GenerateRandomString(30),
                            AllViewNames = "allviewnames"

                        });
                }
                else
                {
                    System.Console.Out.Write("Unrecognized type of data " + typeofdata);
                }
            
            }
            if (format == "excel")
            {
                writeGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    if (typeofdata == "groups")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else
                    {
                        writeContactsToXmlFile(contacts, writer);
                    }
                }
                else if (format == "json")
                {
                    writeGroupsToJsonlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();
            }


         }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Thread.Sleep(1000);
            Excel.Workbook wb =  app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToJsonlFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }

}
