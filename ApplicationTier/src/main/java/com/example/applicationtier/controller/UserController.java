package com.example.applicationtier.controller;

import com.example.applicationtier.Models.User;
import com.example.applicationtier.Service.CustomerService;
import com.example.applicationtier.Models.Customer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class UserController {

    @Autowired
    private CustomerService service;

  /*  @Autowired
    private TestClass service;*/

    @GetMapping("/users")
    public User validateLogin(@RequestParam String username, @RequestParam String password) {
        return service.validateUser(username, password);
    }

    @PostMapping("/createNewUser")
    public void  RegisterCustomer(@RequestBody Customer customer) {
        service.registerCustomer(customer);
    }

   @DeleteMapping("/deleteUser")
    public void deleteUser(@RequestHeader String name) {
        service.deleteCustomer(name);
    }

    @PutMapping("/updateUser")
    public void updateUser(@RequestBody Customer customer){
        service.updateCustomer(customer);
    }
}
