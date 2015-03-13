
using DTOSample.Code.Data;
using DTOSample.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DTOSample.Code
{
	 [DataObject(true)]
	 public class ClientDatasource
	 {		  
		  [DataObjectMethod(DataObjectMethodType.Select, false)]
		  public List<ClientDTO> SelectClients()
		  {
				WebsiteDBContext ctx = new WebsiteDBContext();
				var result = (from client in ctx.Clients
								  select new ClientDTO()
								  {
										Id = client.Id,
										ClientName = client.ClientName,
										Address = (from addr in ctx.Addresses
													  where addr.Client.Id == client.Id
													  select addr.Street + "," + addr.City + "," + addr.ZipCode + "," + addr.State).FirstOrDefault(),
										CountryName = (from cty in ctx.Countries
															where cty.ID == client.Country.ID
															select cty.CountryName).FirstOrDefault()
								  }).ToList();

				//Since result is a list of simple DTO objects, this list could be cached

				return result;
		  }
		  [DataObjectMethod(DataObjectMethodType.Select, false)]
		  public List<ClientDTO> SelectSpecificClients(string condition)
		  {
				return null;
		  }

		  bool IsValid(ClientDTO client)
		  {
				if (String.IsNullOrEmpty(client.CountryName))
					 return false;
				if (String.IsNullOrEmpty(client.Address))
					 return false;
				if (String.IsNullOrEmpty(client.Address))
					 return false;

				return true;
		  }

		  protected virtual bool IsValidNew(ClientDTO item) { return IsValid(item); }
		  protected virtual bool IsValidUpdate(ClientDTO item) { return IsValid(item); }
		  protected virtual bool IsValidDelete(ClientDTO item) { return true; }

		  [DataObjectMethod(DataObjectMethodType.Insert, false)]
		  public void Insert(ClientDTO item)
		  {
				// Validate your input here !!!!
				if (!IsValidNew(item))
					 throw new Exception("Invalid data to insert");
				//insert your item in the dataStore
				WebsiteDBContext ctx = new WebsiteDBContext();

				// We need to do some conversion now

				Country country = (from c in ctx.Countries
										 where c.CountryName == item.CountryName
										 select c).FirstOrDefault();
				if (country == null)
				{
					 country = new Country
					 {
						  CountryName = item.CountryName
					 };
					 ctx.Countries.Add(country);
				}
				string[] addr = item.Address.Split(new[] { ',' });
				Address address = new Address();
				if (addr.Length > 0) address.Street = addr[0];
				if (addr.Length > 1) address.City = addr[1];
				if (addr.Length > 2) address.ZipCode = addr[2];
				if (addr.Length > 3) address.State = addr[3];

				ctx.Addresses.Add(address);
				Client client = new Client()
				{
					 ClientName = item.ClientName,
					 Country = country,
					 Addresses = new List<Address>(new[] { address })
				};
				ctx.Clients.Add(client);
				ctx.SaveChanges();
		  }

		  [DataObjectMethod(DataObjectMethodType.Update, false)]
		  public void Update(ClientDTO item)
		  {
				// Validate your input here !!!!
				if (!IsValidUpdate(item))
					 throw new Exception("Invalid data to update");
				// update your item in the dataStore
				WebsiteDBContext ctx = new WebsiteDBContext();
				Client client = (from c in ctx.Clients
										  where c.Id == item.Id
										  select c).FirstOrDefault();
				if (client != null)
				{
					 client.ClientName = item.ClientName;

					 // other update logic which is turns out that this is a bit of a crappy example :-o
					 // 1. locate address record and update
					 // 2. locate country entity and update 
					 ctx.SaveChanges();
				}
				else
				{
					 throw new Exception("Customer to update cannot be found ");
				}
		  }

		  [DataObjectMethod(DataObjectMethodType.Delete, false)]
		  public void Delete(ClientDTO item)
		  {
				// Validate your input here !!!!
				if (!IsValidDelete(item))
					 throw new Exception("Invalid data to delete");
				// delete your item in the dataStore
				WebsiteDBContext ctx = new WebsiteDBContext();
				Client client = (from c in ctx.Clients
										  where c.Id == item.Id
										  select c).FirstOrDefault();
				if (client != null)
				{					 

					 ctx.Clients.Remove(client);
					 ctx.SaveChanges();
				}
		  }
	 }
}