using System;
namespace Repository.Data
{
	public static class AppDbContext<T>
	{
		public static List<T> Datas;

		static AppDbContext()
		{
			Datas = new List<T>();
		}
	}
}

