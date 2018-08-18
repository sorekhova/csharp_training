using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public bool Equals(GroupData other)
        {
            return this.Name.Equals(other.Name);
        }
  

        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
