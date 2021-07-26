using System;
using System.Collections.Generic;

#nullable disable

namespace notes.Domains
{
    public partial class Task
    {
        public Task()
        {
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string Tasktext { get; set; }
        public bool Removed { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
