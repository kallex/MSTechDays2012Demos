
using System.Collections.Generic;
	
			public partial class Customer
	{
			public string Name { get; set; }
			}
			public partial class Order
	{
			public List<Orderline> Orderlines { get; set; }
			}
			public partial class Orderline
	{
			public decimal Price { get; set; }
			}
			
