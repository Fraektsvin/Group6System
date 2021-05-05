using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository
{
    public class UserRepository:IRepository<User>
    {
        private readonly CloudContext _context;

        public UserRepository()
        {
            _context = new CloudContext();
        }
        
        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.UsersTable.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            try
            {
                var newAddedUser = await _context.UsersTable.AddAsync(user);
                await _context.SaveChangesAsync();
                return newAddedUser.Entity;
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Task RemoveAsync(int predicate)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(string  username)
        {
            User userToRemove = await _context.UsersTable.FirstOrDefaultAsync(u => u.Username.Equals(username));
            if (userToRemove != null)
            {
                _context.UsersTable.Remove(userToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            try
            {
                User userToUpdate = await _context.UsersTable.FirstAsync(u => u.Username == user.Username);
                _context.Update(userToUpdate);
                await _context.SaveChangesAsync();
                return userToUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"User not found!");
            }
        }
    }
}