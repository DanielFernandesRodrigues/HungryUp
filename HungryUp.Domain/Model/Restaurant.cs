
namespace HungryUp.Domain.Model
{
    public class Restaurant
    {
        public long RestaurantId { get; set; }
        public string Name { get; set; }

        protected Restaurant() { }

        public Restaurant(string name)
        {
            this.Name = name;
        }
    }
}
