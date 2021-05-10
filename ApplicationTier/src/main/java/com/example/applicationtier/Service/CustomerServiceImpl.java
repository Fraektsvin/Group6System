package com.example.applicationtier.Service;

import com.example.applicationtier.DAO.Customer.CustomerDAO;
import com.example.applicationtier.Models.Customer;
import com.example.applicationtier.Models.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class CustomerServiceImpl implements CustomerService {

    @Autowired
    private CustomerDAO customerDAO;

    @Override
    public void registerCustomer(Customer newCustomer) {
            customerDAO.addCustomer(newCustomer);
    }

    @Override
    public User validateUser(String username, String password) {
        User user = customerDAO.validateUser(username, password);
        if(!(user == null)){
            return user;
        }
       else{
           // Todo throw the corresponding response
           return null;
        }
    }

    @Override
    public void deleteCustomer(String username) {
        //firebaseService.deleteUser(username);
    }

    @Override
    public void updateCustomer(Customer customer) {
        //firebaseService.updateUserDetails(customer);
    }
}
