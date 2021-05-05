using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Data;
using BlazorClient.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazorClient.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly ICustomerService customerService;

        private Customer cachedCustomer;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, ICustomerService customerService)
        {
            this.jsRuntime = jsRuntime;
            this.customerService = customerService;
        }
       
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedCustomer == null)
            {
                string asJson = await jsRuntime.InvokeAsync<string>
                    ("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(asJson))
                {
                    Customer tmp = JsonSerializer.Deserialize<Customer>(asJson);
                    await ValidateLoginAsync(tmp.User.Username, tmp.User.Password); 
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedCustomer);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        
        public async Task ValidateLoginAsync(string username, string password) 
        {
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try 
            { 
                Customer user = await customerService.ValidateUserAsync(username, password);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedCustomer = user;
            } 
            catch (Exception e)
            {
                throw e;
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
        
        public void Logout() 
        {
            cachedCustomer = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        private ClaimsIdentity SetupClaimsForUser(Customer user)
        {
            List<Claim> claims = new List<Claim>();
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
       }
     }
}


