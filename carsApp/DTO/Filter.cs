namespace carsApp.Models
{
    public class FilterItem
    {
        public bool isChosen { get; set; }
        public string name { get; set; }
    }
    public class Filter
    {
        public string name { get; set; }
        ICollection<FilterItem> items {  get; set;}
    }
}
