using System;
namespace Bangazon.Models
{
	public class Order
	{
		public int ID { get; set; }
		public int CustomerID { get; set; }
		public int PaymentType { get; set; }
		public bool OrderOpen { get; set; }
		public DateTime OrderDate { get; set; }
	}
}

