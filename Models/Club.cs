namespace Event_Hub.Models {
    public class Club {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Cep { get; set; }
        public string City { get; set; }
        public int MaximumCapacity { get; set; }
    }
}