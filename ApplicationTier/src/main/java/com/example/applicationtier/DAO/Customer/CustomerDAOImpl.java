package com.example.applicationtier.DAO.Customer;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.Models.Customer;
import com.example.applicationtier.Models.Request;
import com.example.applicationtier.Models.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class CustomerDAOImpl implements CustomerDAO{
    @Autowired
    private Handler handler;

    @Override
    public void addCustomer(Customer customer) {
        Request obj = new Request("AddCustomer", customer);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        System.out.println(response.getObj());
    }

    @Override
    public User validateUser(String username, String password) {
        //check if the user exists
        User user = new User(username, password);
        System.out.println(user);
        Request login = new Request("CheckLogin", user);
        handler.setObj(login);

        Request response = handler.messageExchange(login);
        System.out.println(response);

        if(response.getObj() instanceof User) {
            return (User) response.getObj();
        }
        else {
                throw new RuntimeException((String) response.getObj());
            }
    }

    @Override
    public Customer getUser(String username) {
        Request obj = new Request("GetCustomer", username);
        handler.setObj(obj);

        Request newObj = handler.messageExchange(obj);
        return (Customer) newObj.getObj();
    }


}
