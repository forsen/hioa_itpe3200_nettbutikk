﻿using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class CustomerDALStub : DAL.ICustomerDAL
    {
        public List<Customer> getAll()
        {
            var cust = new Customer()
            {
                id = 1,
                firstname = "Gunnar",
                lastname = "Hansen",
                address = "Golia",
                email = "klin@kokkos.no",
                postalarea = "Gollie",
                postalcode = "1232",
                phonenumber = "94499449",
                password = "tullball123"

            };
            List<Customer> custList = new List<Customer>();
            custList.Add(cust);
            return custList;
        }

        public List<Customer> getResult(string searchString)
        {
            var cust = new Customer()
            {
                id = 1,
                firstname = "Gunnar",
                lastname = "Hansen",
                address = "Golia",
                email = "klin@kokkos.no",
                postalarea = "Gollie",
                postalcode = "1232",
                phonenumber = "94499449",
                password = "tullball123"

            };
            List<Customer> custList = new List<Customer>();
            custList.Add(cust);
            return custList;
        }

        public bool add(Customer inCustomer, byte[] hashedPassword)
        {
            return true;
        }

        public Customer findCustomer(String email)
        {
            var cust = new Customer()
            {
                id = 1,
                firstname = "Gunnar",
                lastname = "Hansen",
                address = "Golia",
                email = "klin@kokkos.no",
                postalarea = "Gollie",
                postalcode = "1232",
                phonenumber = "94499449",
                password = "tullball123"

            };

            return cust;
        }

        public Customer findUser(String email)
        {
            var db = new DatabaseContext();
            Customers userFound = db.Customers.FirstOrDefault(u => u.Email == email);
             Customer c = new Customer();
                c.id = userFound.Id;
                c.email = userFound.Email;
                c.hashpassword = userFound.Password;
                return c;
        }

        public bool validate(String email, byte[] hashedPassword)
        {
            var db = new DatabaseContext();
            Customers userFound = db.Customers.FirstOrDefault(u => u.Email == email);

            if (userFound.Admin == true)
            {
                if (email.Equals(userFound.Email) && hashedPassword.Equals(userFound.Password))
                {
                    return true;
                }
            }
            return false;        
        }

        public bool update(int id, Customer updateUser)
        {
            return false;
        }

        public bool updatePw(int id, byte[] newPassword)
        {
            return false;

        }

        public bool checkEmail(string email, int? id)
        {

            return false;
        }

        public Customer getCustomer(int id)
        {
            return new Customer();
        }

        public bool makeAdmin(int id, int adminid)
        {
            return false;
        }

        public bool revokeAdmin(int id, int adminid)
        {
            return false;
        }
    }
}
