using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Api;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using PromoCodeFactory.Core.Abstraction.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Mappers;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.GRPC
{
    public class CustomerService : CustomersService.CustomersServiceBase
    {
	    private IRepository<Customer> _customerRepository;
	    private IRepository<Preference> _preferenceRepository;

	    public CustomerService(IRepository<Customer> customerRepository, IRepository<Preference> preferenceRepository)
	    {
		    _customerRepository = customerRepository;
		    _preferenceRepository = preferenceRepository;
	    }

	    public override async Task<GetAllCustomersResponse> GetAll(Empty request, ServerCallContext context)
	    {
		    var customers = await _customerRepository.GetAllAsync();
		    var response = new GetAllCustomersResponse();
		    var protoCustomers = from c in customers
			    select Mappers.CustomerMapper.MapFromCustomer(c);

			var customerResponse = new GetAllCustomersResponse();

			customerResponse.Customers.AddRange(protoCustomers);

			return customerResponse;

	    }

	    public override async Task<ProtoCustomer> GetCustomer(CustomerId request, ServerCallContext context)
	    {
			var isValidId = Guid.TryParse(request.CustomerId_, out Guid customerId);
			if (isValidId)
			{
				var customer = await _customerRepository.GetByIdAsync(customerId);
				if (customer != null)
				{
					return Mappers.CustomerMapper.MapFromCustomer(customer);
				}
			}
			return new ProtoCustomer();
	    }

		public override async Task<CustomerId> CreateCustomer(CreateCustomerRequest request, ServerCallContext context)
		{
			
			
				var preferences = from pref in request 
					
			
			

		}

		public override Task<CustomerId> EditCustomer(EditCustomerRequest request, ServerCallContext context)
	    {
		    return base.EditCustomer(request, context);
	    }

	    public override Task<CustomerId> DeleteCustomer(CustomerId request, ServerCallContext context)
	    {
		    return base.DeleteCustomer(request, context);
	    }
    }
}
