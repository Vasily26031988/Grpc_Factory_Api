using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Mappers
{
	public static class CustomerMapper
	{
		public static Customer MapFromModel(CreateOrEditCustomerRequest model, IEnumerable<Preference> preferences,
			Customer customer = null)
		{
			if (customer == null)
			{
				customer = new Customer();
				customer.Id = Guid.NewGuid();
			}

			customer.FirstName = model.FirstName;
			customer.LastName = model.LastName;
			customer.Email = model.Email;

			customer.Preferences = preferences.Select(x => new CustomerPreference()
			{
				CustomerId = customer.Id,
				Preference = x,
				PreferenceId = x.Id
			}).ToList();

			return customer;
		}

		public static ProtoCustomer MapFromCustomer(Customer customer)
		{
			return new ProtoCustomer
			{
				FirstName = customer.FirstName,
				SecondName = customer.LastName,
				Email = customer.Email
			};

		}
	}
}
