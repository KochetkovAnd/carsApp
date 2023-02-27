namespace carsApp.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public int Mileage { get; set; }
        public int YearOfManufacture { get; set; }
        public string SellerDescription { get; set; }
        public ICollection<Photo> Photos { get; set; }

    }
}
