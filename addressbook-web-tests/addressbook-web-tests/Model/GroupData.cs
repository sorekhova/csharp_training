﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
      
        public GroupData()
        {
 
        }
        public GroupData(string name)
        {
            Name = name;
        }

        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public override string ToString()
        {
            return "name = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(this, other))
            { return true; }

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            return Id.CompareTo(other.Id);
        }


        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).OrderBy(x => x.Name).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts 
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }

        public bool ContactEnteredToGroup(string contactId, string groupId)
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                if((from c in db.Contacts
                            from gcr in db.GCR.Where(p => p.GroupId == groupId && p.ContactId == contactId && c.Id == contactId && c.Deprecated == "0000-00-00 00:00:00")
                            select c).Distinct().ToList().Count == 0)
                {return false; }
                else { return true; } 
               
            }
            
        }

 
    }


}
