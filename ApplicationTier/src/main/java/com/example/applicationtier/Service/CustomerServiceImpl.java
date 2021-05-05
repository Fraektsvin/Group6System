package com.example.applicationtier.Service;

import com.example.applicationtier.DAO.Customer.CustomerDAO;
import com.example.applicationtier.Models.Customer;
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
    public Customer validateUser(String username, String password) {
        /*Customer customer = firebaseService.getUserDetails(username);
        if(customer.getPassword().equals(password))
        {
            return customer;
        }
        else if(!customer.getPassword().equals(password))
        {
            try {
                throw new Exception("Password did not matched");
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        else
        {
            try{
                throw new Exception("Username not found");
            } catch (Exception e) {
                e.printStackTrace();
            }
        }*/
        return null;
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
