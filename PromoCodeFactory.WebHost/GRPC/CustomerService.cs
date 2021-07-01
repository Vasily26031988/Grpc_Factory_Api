using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using PromoCodeFactory.Core.Abstraction.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Mappers;
using PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Grpc
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

        public async override Task<GetAllCustomersResponse> GetAll(Empty request, ServerCallContext context)
        {
            var customers = await _customerRepository.GetAllAsync();
            var response = new GetAllCustomersResponse();
            var protoCustomers = from c in customers
                                 select CustomerMapper.MapFromCustomer(c);

            var customerResponse = new GetAllCustomersResponse();

            customerResponse.Customers.AddRange(protoCustomers);

            return customerResponse;
        }

        public async override Task<ProtoCustomer> GetCustomer(CustomerId request, ServerCallContext context)
        {
            var isValidId = Guid.TryParse(request.CustomerId_, out Guid customerId);
            if (isValidId)
            {
                var customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer != null)
                {
                    return CustomerMapper.MapFromCustomer(customer);
                }
            }
            return new ProtoCustomer();
        }

        public async override Task<CustomerId> CreateCustomer(CreateCustomerRequest request, ServerCallContext context)
        {
            
                var prefernces = from pref in request.PreferncesIds
                                 select Guid.Parse(pref.ToString());

                var preferences = await _preferenceRepository
                        .GetRangeByIdsAsync(prefernces.ToList());

                var cutomerRequest = new CreateOrEditCustomerRequest
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PreferenceIds = new System.Collections.Generic.List<Guid>()
                };

                cutomerRequest.PreferenceIds.AddRange(prefernces);

                Customer customer = CustomerMapper.MapFromModel(cutomerRequest, preferences);

                await _customerRepository.AddAsync(customer);

                return new CustomerId
                {
                    CustomerId_ = customer.Id.ToString()
                };
                
        }

        public async override Task<CustomerId> EditCustomer(EditCustomerRequest request, ServerCallContext context)
        {

            
                var customer = await _customerRepository.GetByIdAsync(Guid.Parse(request.Id));
                var prefernces = from pref in request.PreferncesIds
                                 select Guid.Parse(pref.ToString());

                var preferences = await _preferenceRepository
                        .GetRangeByIdsAsync(prefernces.ToList());

                var cutomerRequest = new CreateOrEditCustomerRequest
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PreferenceIds = new System.Collections.Generic.List<Guid>()
                };

                cutomerRequest.PreferenceIds.AddRange(prefernces);

                Customer newCustomer = CustomerMapper.MapFromModel(cutomerRequest, preferences, customer);

                await _customerRepository.AddAsync(newCustomer);

                return new CustomerId
                {
                    CustomerId_ = customer.Id.ToString()
                };
        
            
        }

        public async override Task<CustomerId> DeleteCustomer(CustomerId request, ServerCallContext context)
        {
            
                var id = Guid.Parse(request.CustomerId_);
                var customer = await _customerRepository.GetByIdAsync(id);
                await _customerRepository.DeleteAsync(customer);
                return new CustomerId
                {
                    CustomerId_ = customer.Id.ToString()
                };
            
            
        }
    }
}
