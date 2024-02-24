using System;
namespace Bangazon.Models
{
	public class Product
	{
		public int ID { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public int CategoryID { get; set; }
		public DateTime TimePosted { get; set; }
		public int SellerID { get; set; }
	}
}

