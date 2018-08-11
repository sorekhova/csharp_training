using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        
        private string bday = "-";
        private string bmonth = "-";
        private string aday = "-";
        private string amonth = "-";
        private string new_group = "[none]";
        private string allphones;
        private string allmails;
        private string allviewnames;
  
        public ContactData()
        {
 
        }
        public ContactData(string firstname="",  string lastname="")
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
 
        [Column(Name ="firstname")]
        public string Firstname { get; set; }
 

        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }
  
        public string Nickname { get; set; }
  
        public string Photo { get; set; }
  
        public string Title { get; set; }
  
        public string Company { get; set; }
 
        public string Address { get; set; }
  
        public string Home { get; set; }
  
        public string Mobile { get; set; }
  
        public string Work { get; set; }
 
        public string Fax { get; set; }
  
        public string Email { get; set; }

        public string Email2 { get; set; }
 
        public string Email3 { get; set; }

        public string Homepage { get; set; }
 
        public string Bday
        {
            get
            {
                return bday;
            }

            set
            {
                bday = value;
            }
        }

        public string Bmonth
        {
            get
            {
                return bmonth;
            }

            set
            {
                bmonth = value;
            }
        }

        public string Byear { get; set; }
  
        public string Aday
        {
            get
            {
                return aday;
            }

            set
            {
                aday = value;
            }
        }

        public string Amonth
        {
            get
            {
                return amonth;
            }

            set
            {
                amonth = value;
            }
        }

        public string Ayear { get; set; }
  
        public string New_group
        {
            get
            {
                return new_group;
            }

            set
            {
                new_group = value;
            }
        }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }
 
        public string Notes { get; set; }
 
        public override string ToString()
        {
            return "name = " + Firstname;
        }

        public string AllPhones
        {
            get
            {
                if (allphones != null)
                {
                    return allphones;
                }
                else
                {
                    return (Cleanup(Home)+Cleanup(Mobile)+Cleanup(Work) + Cleanup(Phone2)).Trim();
                };
                
            }
            set
            {
                allphones = value;
            }
        }

        public string AllMails
        {
            get
            {
                if (allmails != null)
                {
                    return allmails;
                }
                else
                {
                    return (PrepareEmail(Email) + PrepareEmail(Email2) + PrepareEmail(Email3)).Trim();
                };

            }
            set
            {
                allmails = value;
            }
        }

        public string AllViewNames
        {
            get
            {
                if (allviewnames != null)
                {
                    return allviewnames;
                }
                else
                {
                    string homestr = "";

                    homestr = (Homepage == "")? ("") : ("Homepage:" + Homepage.Replace("https://", ""));
   
                    string str = Firstname + Middlename + Lastname + Nickname + 
                        Title + Company + Address + 
                        FillPhoneField(Home,"H:") +
                        FillPhoneField(Mobile, "M:") +
                        FillPhoneField(Work, "W:") +
                        FillPhoneField(Fax, "F:") +
                        Email + Email2 + Email3 +
                        homestr + 
                        FillDataField(Bday, Bmonth, Byear, "Birthday") +
                        FillDataField(Aday, Amonth, Ayear, "Anniversary") +
                        Address2 +
                        FillPhoneField(Phone2, "P:") + Notes;
  
                    return str.Replace(" ","").ToUpper();
                };

            }
            set
            {
                allviewnames = value;
            }
        }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        private string FillDataField(string daystr, string monthstr, string yearstr, string str)
        {
           
                daystr = daystr == "0" ? ("") : (daystr + ".");
                monthstr = monthstr == "-" ? ("") : (monthstr);
                yearstr = yearstr == "" ? ("") : (yearstr + "(" + Convert.ToString(DateTime.Today.Year - Int32.Parse(yearstr)) + ")");

                return (daystr + monthstr + yearstr)==""? ("") : (str + daystr + monthstr + yearstr);
           
        }

        private string FillPhoneField(string phone, string str)
        {
            return (phone) == "" ? ("") : (str + phone);
        }

        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            { return ""; }

            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
       //     return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        private string PrepareEmail(string email)
        {
            if (email == null || email == "")
            { return ""; }

            return email + "\r\n";
            //     return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(this, other))
            { return true; }
            if (Firstname == other.Firstname && Lastname == other.Lastname)
            { return true; }
            else
            { return false; }
  
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            return (Firstname+Lastname).CompareTo(other.Firstname+other.Lastname);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated== "0000-00-00 00:00:00") select c).OrderBy(x => x.Lastname).ToList();
            }
        }
    }
}
