using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(this, other))
            { return true; }
            return this.Name==other.Name;
        }
  

        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            return this.Name.CompareTo(other.Name);
        }
    }
}
