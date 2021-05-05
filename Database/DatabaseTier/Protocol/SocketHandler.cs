using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Repository;

namespace DatabaseTier.Protocol
{
    public class SocketHandler
    {
        private NetworkStream _stream;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Customer> _customerRepo;
        private TcpClient _client;
        
        public SocketHandler(TcpClient client)
        {
            _client = client;
            _userRepo = new UserRepository();
            _customerRepo = new CustomerRepository();
            _stream = _client.GetStream();
        }

        public async Task ExchangeMessages()
        {
             //read 
            byte[] readBuffer = new byte[8000];
            int bytesToRead = _stream.Read(readBuffer, 0, readBuffer.Length);
            string message = Encoding.UTF8.GetString(readBuffer, 0, bytesToRead);
            
            Request readRequest = JsonSerializer.Deserialize<Request>(message, 
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            Console.WriteLine(readRequest);
            Console.WriteLine(readRequest.Header + readRequest.Obj);
            
               //send  
            Request reply = await Operation(readRequest);
            
            string readMessage = JsonSerializer.Serialize(reply, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            byte[] sendToServer = Encoding.UTF8.GetBytes(readMessage);
            _stream.Write(sendToServer, 0, sendToServer.Length);
            
            _client.Close();
        }

        private async Task<Request> Operation(Request request)
        {
            Request wrongRequest = new Request("Wrong request", null);
            try
            {
                switch (request.Header)
                {
                    case "GetAllUsers":
                        return new Request("GetAllUsers", await _userRepo.GetAllAsync());
                    case "AddUser":
                        return new Request("AddUser", await _userRepo.AddAsync(ToObject<User>((JsonElement) request.Obj)));
                    case "UpdateUser" :
                        return new Request("UpdateUser", await _userRepo.UpdateAsync((User) request.Obj));
                   case "RemoveUserByUsername":
                       await _userRepo.RemoveAsync((int) request.Obj);
                       return new Request("RemoveUserById", "User successfully removed");
                   case "GetAllCustomers":
                       return new Request("GetAllCustomers", await _customerRepo.GetAllAsync());
                    case "AddCustomer":
                        return new Request("AddCustomer", await _customerRepo.AddAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    case "UpdateCustomer" :
                        return new Request("UpdateCustomer",
                            await _customerRepo.UpdateAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    case "RemoveCustomerByCprNumber":
                        await _customerRepo.RemoveAsync((int) request.Obj);
                        return new Request("RemoveCustomerByCprNumber", "User successfully removed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            return wrongRequest;
        }
        
        private static T ToObject<T>(JsonElement element)
        {
            var json = element.GetRawText(); 
            var result = JsonSerializer.Deserialize<T>(json);
            return result;

        }
      
    }
}