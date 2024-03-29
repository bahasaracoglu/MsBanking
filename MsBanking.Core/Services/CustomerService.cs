﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MsBanking.Common.Entity;
using MsBanking.Core.Domain;

namespace MsBanking.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> customerCollection;

        public CustomerService(IOptions<DatabaseOption> options)
        {
            var dbOptions = options.Value;
            var client = new MongoClient(dbOptions.ConnectionString);
            var database = client.GetDatabase(dbOptions.DatabaseName);
            customerCollection = database.GetCollection<Customer>(dbOptions.CustomerCollectionName);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customerEntity = await customerCollection.FindAsync(x => x.Id == id);

            return customerEntity.FirstOrDefault();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customerEntities = await customerCollection.FindAsync(c => true);
            return customerEntities.ToList();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            //    customer.createddate = datetime.now;
            //    customer.updateddate = datetime.now;
            //    customer.ısactive = true;
            await customerCollection.InsertOneAsync(customer);

            return customer;
        }
    }
}
