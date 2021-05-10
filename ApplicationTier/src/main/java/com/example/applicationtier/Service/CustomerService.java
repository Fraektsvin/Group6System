package com.example.applicationtier.Service;

import com.example.applicationtier.Models.Customer;
import com.example.applicationtier.Models.User;

public interface CustomerService {
    void registerCustomer(Customer newCustomer);
    User validateUser(String username, String password);
    void deleteCustomer(String username);
    void updateCustomer(Customer customer);
}
