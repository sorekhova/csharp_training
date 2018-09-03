using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string ViewStatus { get; set; }

        public string Description { get; set; }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(this, other))
            { return true; }
            if (Name == other.Name )
            { return true; }
            else
            { return false; }

        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            return (Name).CompareTo(other.Name);
        }
    }
}

