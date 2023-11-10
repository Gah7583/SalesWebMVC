using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} size must be between {2} and {1}")]
        public string Name { get; set; }
        public ICollection<Seller>? Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(string name)
        {
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
