using System;

#nullable disable

namespace notes.Domains
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Notetext { get; set; }
        public int? Taskid { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Removed { get; set; }

        public virtual Task Task { get; set; }
    }
}
