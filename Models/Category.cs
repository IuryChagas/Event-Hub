using System.Collections.Generic;

namespace Event_Hub.Models {
    public class Category {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public Category () {
            this.Events = new List<Event> ();
        }
    }
}