using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CornSeedTesting.Models
{
    public class Events : IEquatable<Events>
    {
        public string EventDesc { get; set; }
        public DateTime EventDate { get; set; }
        public string Comments { get; set; }
        public override string ToString()
        {
            return EventDesc + " " + EventDate + " " + Comments;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Acres objAsPart = obj as Acres;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals([AllowNull] Events other)
        {
            throw new NotImplementedException();
        }
    }
}
