﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class CustomerBLLTest
    {
        [TestMethod]
        public void List_All_Customers()
        {
            // Arrange
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            List<Customer> expected = new List<Customer>();
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

            expected.Add(cust);

            // Act
            var actrow = (ViewResult)bll.ListAll();
            var result = (List<Customer>)actrow.Model;

                     
            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(expected.Count, result.Count);
        }

        [TestMethod]
        public void Hashed_password_Not_Null()
        {
            //Arrange
            var bll = new CustomerBLL();
            String password = "yo";

            //Act
            var result = bll.makeHash(password);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Hashed_password_Not_empty()
        {
            //Arrange
            var bll = new CustomerBLL();
            var array = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("yo"));
            String password = "yo";

            //Act
            var result = bll.makeHash(password);

            //Assert
            Assert.AreNotEqual(array, result);
        }
        [TestMethod]
        public void hashed_Password_is_correct()
        {
            //Arrange
            var bll = new CustomerBLL();
            var hp = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("yo"));
            string p = "yo";

            //Act
            var result = bll.makeHash(p);

            //Assert
            Assert.AreSame(hp, result);
            

        }

        [TestMethod]
        public void find_user()
        {
            //Arrange 
            var bll = new CustomerBLL(new CustomerDALStub());
            string email = "Hei";
           
            
            //Act 
            var result = bll.findUser(email);

            //Assert
            Assert.IsNotNull(result.id);


        }
     


        [TestMethod]
        public void validate_login()
        {
            //Arrange
            var bll = new MainController(new CustomerBLL(new CustomerDALStub()));
            String email =  "hei";
            String p = "yo";
            byte[] password = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("yo"));

            //Act
            var actrow = (ViewResult)bll.logIn(email, p);
            var result = actrow.Model;
            
            
            //Assert
            Assert.IsNotNull(result);

        }

       

    }
}
