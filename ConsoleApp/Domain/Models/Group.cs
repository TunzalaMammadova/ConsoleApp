using System;
namespace Domain.Models
{
	public class Group : BaseEntity
	{
		public string Name { get; set; }
		public int? Capacity { get; set; }
	}
}

