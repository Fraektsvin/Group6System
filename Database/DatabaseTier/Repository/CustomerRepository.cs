﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository
{
    public class CustomerRepository:IRepository<Customer>
    {
        private readonly CloudContext _context;

        public CustomerRepository()
        {
            _context = new CloudContext(); 
        }
        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _context.CustomersTable.ToListAsync();
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            try
            {
                var newAddedCustomer = await _context.CustomersTable.AddAsync(customer);
                await _context.SaveChangesAsync();
                return newAddedCustomer.Entity;
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task RemoveAsync(int cprnumber)
        {
            Customer customerToRemove = await _context.CustomersTable.FirstOrDefaultAsync(c => c.CprNumber == cprnumber);
            if (customerToRemove != null)
            {
                _context.CustomersTable.Remove(customerToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            try
            {
                Customer customerToUpdate = await _context.CustomersTable.FirstAsync(c=> c.CprNumber == customer.CprNumber);
                _context.Update(customerToUpdate);
                await _context.SaveChangesAsync();
                return customerToUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"User not found!");
            }
        }

        public Task<Customer> GetAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}