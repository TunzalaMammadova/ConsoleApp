using System;
namespace Domain.Models
{
	public class Student : BaseEntity
	{
		public string FullName { get; set; }
		public string Address { get; set; }
		public int Id { get; set; }
		public string Phone { get; set; }
		public Group Group { get; set; }

	}
}

