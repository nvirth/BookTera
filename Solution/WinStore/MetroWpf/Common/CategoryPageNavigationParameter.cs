using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroWpf.Common
{
	public enum CategoryPageNavigationParameterEnum : byte
	{
		None = 0,
		CategoryFu = 1,
		SearchText = 2,
	}

	public class CategoryPageNavigationParameter
	{
		public CategoryPageNavigationParameterEnum Type { get; set; }
		public string Value { get; set; }
	}
}
