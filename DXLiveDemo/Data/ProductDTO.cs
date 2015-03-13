using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel
;
namespace DXLiveDemo.Data
{
	 public class ProductDTO
	 {
		  public int ProductID { get; set; }
		  public int CategoryID { get; set; }
		  public string SeriesName { get; set; }
		  public string ProductName { get; set; }
		  public int Number { get; set; }
	 }

	 [DataObject(true)]
	 public class ProductsDatasource
	 {
		  const string defaultConnectionName = "NorthwindDBConnectionString";
		  
		  #region Generic Sql Reader code
		  static int SqlRead(string sql, SqlParameter[] sqlParams, Action<SqlDataReader> readAction)
		  {
				if (String.IsNullOrEmpty(sql))
					 throw new ArgumentNullException("sql");
				if (readAction == null)
					 throw new ArgumentNullException("readAction");
				return SqlExec(defaultConnectionName, sql, sqlParams, readAction);
		  }

		  static int SqlExec(string sql, SqlParameter[] sqlParams)
		  {
				if (String.IsNullOrEmpty(sql))
					 throw new ArgumentNullException("sql");
				return SqlExec(defaultConnectionName, sql, sqlParams, null);
		  }
		
		  static int SqlExec(string connectionStringName, string sql, SqlParameter[] sqlParams, Action<SqlDataReader> readAction)
		  {
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
				{
					 conn.Open();
					 using (SqlCommand cmd = new SqlCommand(sql, conn))
					 {
						  if (sqlParams != null)
								cmd.Parameters.AddRange(sqlParams);
						  if (readAction != null)
						  {
								using (SqlDataReader reader = cmd.ExecuteReader())
								{
									 while (reader.Read()) { readAction(reader); }
								}
						  }
						  else
						  {
								return cmd.ExecuteNonQuery();
						  }
					 }
					 return 0;
				}		  
		  }

		  #endregion

		  #region Select Method 
		  [DataObjectMethod(DataObjectMethodType.Select, false)]
		  public IEnumerable<ProductDTO> Select()
		  {
				List<ProductDTO> result = new List<ProductDTO>();

				SqlRead("SELECT [ProductID], [CategoryID], [UnitsInStock], [UnitsOnOrder], [ProductName] FROM [Products]", null,
					 reader =>
					 {
						  result.Add(new ProductDTO
						  {
								SeriesName = "Units In Stock",
								ProductID = Convert.ToInt32(reader["ProductID"]),
								CategoryID = Convert.ToInt32(reader["CategoryID"]),
								ProductName = (string)reader["ProductName"],
								Number = Convert.ToInt32(reader["UnitsInStock"])
						  });
						  result.Add(new ProductDTO
						  {
								SeriesName = "Units On Order",
								ProductID = Convert.ToInt32(reader["ProductID"]),
								CategoryID = Convert.ToInt32(reader["CategoryID"]),
								ProductName = (string)reader["ProductName"],
								Number = Convert.ToInt32(reader["UnitsOnOrder"])
						  });
					 });
				return result;
		  }

		  #endregion
		  
		  #region Code below for educational purposes only
		  
		  //protected virtual bool IsValidNew(ProductDTO item) { throw new NotImplementedException(); }
		  //protected virtual bool IsValidUpdate(ProductDTO item) { throw new NotImplementedException(); }
		  //protected virtual bool IsValidDelete(ProductDTO item) { throw new NotImplementedException(); }

		  //[DataObjectMethod(DataObjectMethodType.Insert, false)]
		  //public void Insert(ProductDTO item)
		  //{
		  //	 // Validate your input here !!!!
		  //	 if (!IsValidNew(item))
		  //		  throw new Exception("Invalid data to insert");
		  //	 //insert your item in the dataStore
		  //	 throw new NotImplementedException();
		  //}

		  //[DataObjectMethod(DataObjectMethodType.Update, false)]
		  //public void Update(ProductDTO item)
		  //{
		  //	 // Validate your input here !!!!
		  //	 if (!IsValidUpdate(item))
		  //		  throw new Exception("Invalid data to update");
		  //	 // update your item in the dataStore
		  //	 throw new NotImplementedException();
		  //}

		  //[DataObjectMethod(DataObjectMethodType.Delete, false)]
		  //public void Delete(ProductDTO item)
		  //{
		  //	 // Validate your input here !!!!
		  //	 if (!IsValidDelete(item))
		  //		  throw new Exception("Invalid data to delete");
		  //	 // delete your item in the dataStore
		  //	 throw new NotImplementedException();
		  //}

		  #endregion
	 }
}