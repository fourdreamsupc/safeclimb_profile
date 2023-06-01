﻿namespace Go2Climb.API.Customers.Services;

public class RegisterCustomerRequest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int PhoneNumber { get; set; }

    public string Photo {get; set;}
}