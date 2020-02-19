using System;
using System.ComponentModel.DataAnnotations;

namespace Event_Hub.Models {
    public class Event {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        [Required (ErrorMessage = "*")]
        [DataType (DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string EventPlace { get; set; }
        public int Units { get; set; }
        public int CategoryId { get; set; }
    }
}