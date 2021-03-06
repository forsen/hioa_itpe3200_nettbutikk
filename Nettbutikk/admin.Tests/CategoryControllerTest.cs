﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Controllers;
using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;
using MvcContrib.TestHelper;
using PagedList.Mvc;
using PagedList;
using System.Diagnostics;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void category_list_categories()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() {id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(2, 2, null, null, null);
            var result = (PagedList<CategoryInfo>)action.Model;

            //Assert
            Assert.AreEqual(result.PageNumber, 2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IPagedList<CategoryInfo>));
            Assert.IsTrue(result[0].id < result[1].id);
        }
        [TestMethod]
        public void category_list_categories_sort_id_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(2, 2, "id_desc", null, "notnull");
            var result = (PagedList<CategoryInfo>) action.Model;
            
            //Assert
            Assert.AreEqual(result.PageNumber, 1);
            Assert.IsTrue(result[0].id > result[1].id);
        }
        [TestMethod]
        public void category_list_categories_sort_category()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(null, null, "Cat", null, null);
            var result = (IPagedList<CategoryInfo>)action.Model;

            //Assert
            Assert.IsTrue(string.Compare(result[0].name,result[1].name) < 0);
        }
        [TestMethod]
        public void category_list_categories_sort_category_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(null, null, "cat_desc", null, null);
            var result = (IPagedList<CategoryInfo>)action.Model;

 
            //Assert
            Assert.IsTrue(string.Compare(result[0].name, result[1].name) > 0);
        }
        [TestMethod]
        public void category_list_producers()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, null, null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2,result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(result[0].prodId < result[1].prodId);
        }
        [TestMethod]
        public void category_list_producers_sort_id_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, "id_desc", null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(result[0].prodId > result[1].prodId);
        }
        [TestMethod]
        public void category_list_producers_sort_name()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, "Name", null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(string.Compare(result[0].prodName, result[1].prodName)<0);
        }
        [TestMethod]
        public void category_list_producers_sort_name_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, "name_desc", null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(string.Compare(result[0].prodName, result[1].prodName) > 0);
        }
        [TestMethod]
        public void category_new_category_view()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true }; 

            //Act
            var action = (ViewResult)controller.newCategory();
           
            var result = (CategoryInfo)action.Model;

            //Assert
            Assert.AreEqual("", action.ViewName);
            Assert.IsNull(result); 
        }
        [TestMethod]
        public void category_new_category_httppost()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            CategoryInfo c = new CategoryInfo()
            {
                name="en kategori"
            };

            //Act
            var result = (JsonResult)controller.newCategory(c);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;
            //Assert

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void category_new_category_httppost_modelstate_invalid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            controller.ViewData.ModelState.AddModelError("kategori", "Ikke oppgitt kategori");
            CategoryInfo c = new CategoryInfo()
            {
                name = ""
            };

            //Act
            var result = (JsonResult)controller.newCategory(c);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;

            //Assert
            Assert.IsFalse(success);
            
        }

        [TestMethod]
        public void category_update_category_details()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            CategoryInfo expected = new CategoryInfo()
            {
                id = 2,
                name = "Brennevin"
            };

            //Act
            var action = (ViewResult)controller.updateCatergoryDetails(expected.id);
            var result = (CategoryInfo)action.Model; 

            //Assert
            Assert.AreEqual(expected.id, result.id);
            Assert.AreEqual(expected.name, result.name); 
        }

        [TestMethod]
        public void category_update_category_details_httppost_update_OK()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            CategoryInfo ci = new CategoryInfo()
            {
                id = 1,
                name = "Kaffe"
            };

            //Act
            var result = (JsonResult)controller.updateCatergoryDetails(ci);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void category_update_category_details_httppost_modelstate_invalid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            controller.ViewData.ModelState.AddModelError("name", "Mangler brukernavn");
            CategoryInfo ci = new CategoryInfo()
            {
                name = "kaffe"
            };

            //Act
            var result = (JsonResult)controller.updateCatergoryDetails(ci);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;
            //Assert
            Assert.IsFalse(success);
        }
        [TestMethod]
        public void category_new_subcategory_view()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.newSubCategory();
            var result = (SubCategoryDetail)action.Model;

            //Assert
            Assert.AreEqual("", action.ViewName);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void category_new_subcategory_view_httppost()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            SubCategoryDetail scd = new SubCategoryDetail()
            {
                name = "Preskanne",
                categoryId = 2
            };
            
            //Act
            var result = (JsonResult)controller.newSubCategory(scd);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void category_new_subcategory_view_httppost_modelstate_invalid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            controller.ViewData.ModelState.AddModelError("feil", "dette ble feil gitt"); 
            SubCategoryDetail scd = new SubCategoryDetail()
            {
                name = "Preskanne",
                categoryId = 2
            };

            //Act
            var result = (JsonResult)controller.newSubCategory(scd);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;

            //Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void category_list_subcategories()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListSubCategories(2, 2, null, null, null);
            var result = (PagedList<SubCategoryInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<SubCategoryInfo>));
            Assert.IsTrue(result[0].ID < result[1].ID);
        }
        [TestMethod]
        public void category_list_subcategories_sort_id_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListSubCategories(2, 2, "id_desc", null, null);
            var result = (PagedList<SubCategoryInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<SubCategoryInfo>));
            Assert.IsTrue(result[0].ID > result[1].ID);
        }
        [TestMethod]
        public void category_list_subcategories_sort_name()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListSubCategories(2, 2, "Name", null, null);
            var result = (PagedList<SubCategoryInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<SubCategoryInfo>));
            Assert.IsTrue(string.Compare(result[0].name, result[1].name) < 0);
        }
        [TestMethod]
        public void category_list_subcategories_sort_name_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListSubCategories(2, 2, "name_desc", null, null);
            var result = (PagedList<SubCategoryInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<SubCategoryInfo>));
            Assert.IsTrue(string.Compare(result[0].name, result[1].name) > 0);
        }
        [TestMethod]
        public void category_subcategories_details_view()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            SubCategory expected = new SubCategory()
            {
                ID = 4,
                name = "Mokka",
                catName = "Kaffe"
            }; 

            //Act
            var action = (ViewResult)controller.SubCatDetails(expected.ID);
            var result = (SubCategoryDetail)action.Model;

            //Assert
            Assert.AreEqual("", action.ViewName);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.categoryList);  
        }

        [TestMethod]
        public void category_subcategories_details_httppost()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            var scd = new SubCategoryDetail()
            {
                ID = 8,
                name = "Cappucino"
            };

            //Act
            var action = (JsonResult)controller.SubCatDetails(scd);
            var result = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void category_subcategories_details_httppost_modelstate_invalid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            controller.ViewData.ModelState.AddModelError("error", "feilmelding");
            var scd = new SubCategoryDetail()
            {
                ID = 8,
                name = "Cappucino"
            };

            //Act
            var action = (JsonResult)controller.SubCatDetails(scd);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsFalse(success);
        }
        [TestMethod]
        public void category_delete_category_httppost_no_child()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (JsonResult)controller.DeleteCategory(5);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success); 

        }
        [TestMethod]
        public void category_delete_category_httppost_child()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (JsonResult)controller.DeleteCategory(4);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsFalse(success); 
        }
        [TestMethod]
        public void category_delete_subcategory_httppost_no_child()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (JsonResult)controller.DeleteSubCategory(5);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success);

        }
        [TestMethod]
        public void category_delete_subcategory_httppost_child()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (JsonResult)controller.DeleteSubCategory(4);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void category_delete_producer_httppost_no_child()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (JsonResult)controller.DeleteProducer(5);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success);

        }
        [TestMethod]
        public void category_delete_producer_httppost_child()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (JsonResult)controller.DeleteProducer(4);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void category_add_producer_view()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.addProducer();
            var result = (ProducerInfo)action.Model;

            //Assert
            Assert.AreEqual("", action.ViewName);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void category_add_producer_httppost()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            var producer = new ProducerInfo()
            {
                prodId = 12,
                prodName = "Produsent"
            };
            //Act
            var result = (JsonResult)controller.addProducer(producer);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success); 
        }
        [TestMethod]
        public void category_add_producer_httppost_modelstate_invalid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            controller.ViewData.ModelState.AddModelError("error", "noe gikk galt!");
            var producer = new ProducerInfo()
            {
                prodId = 12,
                prodName = "Produsent"
            };
            //Act
            var result = (JsonResult)controller.addProducer(producer);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;

            //Assert
            Assert.IsFalse(success); 
        }
        [TestMethod]
        public void category_producer_details_view()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ProducerDetails(5);
            var result = (ProducerInfo)action.Model;

            //Assert
            Assert.AreEqual("", action.ViewName);
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.prodId);
        }

        [TestMethod]
        public void category_producer_details_httppost()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            ProducerInfo pi = new ProducerInfo()
            {
                prodId = 12,
                prodName = "En produsent"
            }; 

            //Act
            var action = (JsonResult)controller.ProducerDetails(pi.prodId, pi);
            var result = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsTrue(result); 
        }

        [TestMethod]
        public void category_producer_details_httppost_modelstate_invalid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            controller.ViewData.ModelState.AddModelError("error", "noe gikk galt");
            ProducerInfo pi = new ProducerInfo()
            {
                prodId = 12,
                prodName = "En produsent"
            };

            //Act
            var action = (JsonResult)controller.ProducerDetails(pi.prodId, pi);
            var result = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsFalse(result); 
        }

    }
}
