using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairType
{
	internal class Setting
	{
		public void GetTestGetAllType()
		{
			DataContext context = new DataContext(ConfigurationManager.ConnectionStrings["TestServiceConnectionString"].ConnectionString);
			context.Log = Console.Out;

			var selResult = from r in context.GetTable<RepairClass>() where r.IsActive == true orderby r.SortOrder select r;
			Console.WriteLine(selResult.Count());

			foreach (var item in selResult)
			{
				Console.WriteLine(item.ClassId);
				Console.WriteLine(item.ClassName);
				Console.WriteLine(item.SortOrder);
			}
			
		}

		public void InsertTypeItem()
		{
			DataContext context = new DataContext(ConfigurationManager.ConnectionStrings["TestServiceConnectionString"].ConnectionString);
			context.Log = Console.Out;

			var insertResult = context.GetTable<RepairClass>();

			var insertQuery = new RepairClass { ClassName = "Test", SortOrder = "15", IsActive = true, CreateUser = "Doris", CreatedTime = DateTime.Now };
			insertResult.InsertOnSubmit(insertQuery);
			context.SubmitChanges();

			Console.WriteLine(insertQuery.ClassId);
		}

		public void UpdateTypeItem()
		{
			DataContext context = new DataContext(ConfigurationManager.ConnectionStrings["TestServiceConnectionString"].ConnectionString);
			context.Log = Console.Out;

			var updateItem = from u in context.GetTable<RepairClass>() where u.ClassId == 2 select u;

			var updateQuery = updateItem.First<RepairClass>();
			updateQuery.ClassName = "測試";
			updateQuery.SortOrder = "25";
			updateQuery.UpdateUser = "Doris";
			updateQuery.UpdatedTime = DateTime.Now;
			context.SubmitChanges();
		}

		public void DeleteTypeActive()
		{
			DataContext context = new DataContext(ConfigurationManager.ConnectionStrings["TestServiceConnectionString"].ConnectionString);
			context.Log = Console.Out;
			var deleteItem = context.GetTable<RepairClass>();

			var deleteQuery = from d in deleteItem
							  where d.ClassId == 3
							  select d;
			var delStatus = deleteQuery.First<RepairClass>();
			delStatus.IsActive = false;
			delStatus.UpdateUser = "Doris";
			delStatus.UpdatedTime = DateTime.Now;


			context.SubmitChanges();
		}

	}
	//public static readonly string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RepairType;Integrated Security=True";
}

