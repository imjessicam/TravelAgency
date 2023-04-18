﻿using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models.Group_1;
using TravelAgency.Models.Group_2;

namespace TravelAgency.Repositories.Group_1
{
    public class CustomerRepository
    {
        // Create connection with DB
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Create constructor
        public CustomerRepository(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        // List of all customers

        public IReadOnlyList<Customer> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var customersList = context.Customers.ToList();

            return customersList;
        }

        // Post
        public Guid Create(Customer customer)
        {
            using var context = _factory.CreateDbContext();

            var externalId = Guid.NewGuid();
            customer.ExternalId = externalId;
            context.Customers.Add(customer);

            context.SaveChanges();

            // Add Customer as Crew Member to Crews Table

            var addedCustomer = context.Customers.FirstOrDefault(x => x.ExternalId == customer.ExternalId);

            if(addedCustomer != null)
            {
                context.Crews.Add(new Crew
                {
                    ExternalId = externalId,
                    LastName = addedCustomer.LastName,
                    FirstName = addedCustomer.FirstName,
                    CustomerId = addedCustomer.Id,
                });

                context.SaveChanges();
            }

            return externalId;
        }

        // Get
        public Customer Find(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var database = context.Customers;
            var foundItem = database.FirstOrDefault(x => x.ExternalId == externalId);

            return foundItem;
        }
               

        public IEnumerable<Customer> FindMany(IEnumerable<Guid> externalIds)
        {
            using var context = _factory.CreateDbContext();

            var database = context.Customers;
            var foundItems = database.Where(x => externalIds.Contains(x.ExternalId)).ToList();

            return foundItems;
        }

        // Put
        public Guid Update(Customer customer)
        {
            using var context = _factory.CreateDbContext();

            // find item
            var currentItem = Find(customer.ExternalId);

            // new data
            currentItem.LastName = customer.LastName;
            currentItem.FirstName = customer.FirstName;
            currentItem.Email = customer.Email;
            currentItem.Phone = customer.Phone;

            // update and save changes
            context.Update(currentItem);
            context.SaveChanges();

            return currentItem.ExternalId;
        }

        // Delete
        public void Delete(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            // find item
            var itemToDelete = Find(externalId);

            // remove item and save changes
            context.Remove(itemToDelete);
            context.SaveChanges();
        }

        public void DeleteMany(IEnumerable<Guid> externalIds)
        {
            using var context = _factory.CreateDbContext();

            // find items
            var itemsToDelete = FindMany(externalIds);

            // remove items and save changes
            context.RemoveRange(itemsToDelete);
            context.SaveChanges();
        }



        // Get All Crew from One Customer

        public IReadOnlyList<Crew> GetCrewMembers(Guid customerExternalId)
        {
            using var context = _factory.CreateDbContext();

            // find iteam
            var customer = context
                .Customers
                .Include(x => x.Crews)
                .FirstOrDefault(x => x.ExternalId == customerExternalId);

            return customer.Crews.ToList();
        }

    }
}
