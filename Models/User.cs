using System;
namespace Bangazon.Models
{
	public class User
	{
		public int ID { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public bool IsSeller { get; set; }
	}
}

