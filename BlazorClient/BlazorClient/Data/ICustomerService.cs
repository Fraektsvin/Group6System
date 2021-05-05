using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data
{
    public interface ICustomerService
    {
        Task<Customer> ValidateUserAsync(string username, string password);
        Task AddUserAsync(Customer customer);
    }
}