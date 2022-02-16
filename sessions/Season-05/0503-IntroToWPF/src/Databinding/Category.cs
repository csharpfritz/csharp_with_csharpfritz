using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Databinding
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Product> Products { get; private set; } =
				new ObservableCollection<Product>();

	}
}