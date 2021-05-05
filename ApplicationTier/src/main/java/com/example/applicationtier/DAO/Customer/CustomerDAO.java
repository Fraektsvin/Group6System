package com.example.applicationtier.DAO.Customer;


import com.example.applicationtier.Models.Customer;
import org.springframework.stereotype.Component;

@Component
public interface CustomerDAO {
    void addCustomer(Customer customer);
    Customer getUser(String username);
}
