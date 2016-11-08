using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Nettbutikk
{
    public class DBCustomer
    {
        public bool add(Customer inCustomer, byte[] hashedPassword)
        {
            var newCustomer = new Customers()
            {
                Firstname = inCustomer.firstname,
                Lastname = inCustomer.lastname,
                Address = inCustomer.address,
                PostalareasId = Convert.ToInt16(inCustomer.postalcode),
                Password = hashedPassword,
                Phonenumber = inCustomer.phonenumber,
                Email = inCustomer.email
            };

            var db = new DatabaseContext();
            try
            {
                var existPostalcode = db.Postalareas.Find(Convert.ToInt16(inCustomer.postalcode));

                if(existPostalcode == null )
                {
                    var newPostalarea = new Postalareas()
                    {
                        PostalareasId = Convert.ToInt16(inCustomer.postalcode),
                        Postalarea = inCustomer.postalarea
                    };
                    newCustomer.Postalareas = newPostalarea;
                }
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }
    
        public Customer findCustomer(String email)
        {
            var db = new DatabaseContext();
            Customers userFound =  db.Customers.FirstOrDefault(u => u.Email == email);
            Customer c = new Customer();
            c.id = userFound.Id;
            c.firstname = userFound.Firstname;
            c.lastname = userFound.Lastname;
            c.email = userFound.Email;
            c.phonenumber = userFound.Phonenumber;
            c.address = userFound.Address;
            c.postalcode = userFound.PostalareasId.ToString();
            c.postalarea = db.Postalareas.Find(userFound.PostalareasId).Postalarea;
            c.hashpassword = userFound.Password;
             return c;
        }

        public bool validate(String email, byte[] hashedPassword)
        {
            var db = new DatabaseContext();

            try
            {
                Customers validated = db.Customers.FirstOrDefault(u => u.Password == hashedPassword && u.Email == email);
                if (validated == null)
                    return false;
                else
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool update(int id, Customer updateUser)
        {
            var db = new DatabaseContext();
            try
            {
                Customers cust = db.Customers.FirstOrDefault(u => u.Id == id);
           
                cust.Firstname = updateUser.firstname;
                cust.Lastname = updateUser.lastname;
                cust.Address = updateUser.address;
                cust.PostalareasId = Convert.ToInt16(updateUser.postalcode);
                cust.Phonenumber = updateUser.phonenumber;
                cust.Email = updateUser.email;
            
                var existPostalcode = db.Postalareas.Find(Convert.ToInt16(updateUser.postalcode));

                if (existPostalcode == null)
                {
                    var newPostalarea = new Postalareas()
                    {
                        PostalareasId = Convert.ToInt16(updateUser.postalcode),
                        Postalarea = updateUser.postalarea
                    };
                    cust.Postalareas = newPostalarea;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
               
            }
        }

        public bool updatePw(int id, byte[] newPassword)
        {
            var db = new DatabaseContext();
            try
            {
                Customers cust = db.Customers.FirstOrDefault(u => u.Id == id);
                cust.Password = newPassword;
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
 
        }

        public bool checkEmail(string email, int? id)
        {
            var db = new DatabaseContext();
            Customers cust = db.Customers.FirstOrDefault(u => u.Email.Equals(email));

            if ((cust == null) || (cust != null && cust.Id == id))
                return true;
            else return false;  
        }
    }
}

