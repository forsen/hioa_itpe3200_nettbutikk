using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Nettbutikk.Models
{
    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'DbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Nettbutikk.Models.DbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContext' 
        // connection string in the application configuration file.
        public DatabaseContext()
            : base("name=Nettbutikk")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Products> Products { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Postalareas> Postalareas { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<Countries> Countries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class Products
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String LongDescription { get; set; }
        public int Price { get; set; }
        public double Volum { get; set; }
        public int ProducersId { get; set; }
        public virtual Producers Producers { get; set; }
        public int SubCategoriesId { get; set; }
        public virtual SubCategories SubCategories { get; set; }
        public int CountriesId { get; set; }
        public virtual Countries Countries {get; set;}
        public virtual List<OrderLines> OrderLines { get; set; }
    }

    public class Producers
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual List<Products> Products { get; set; }
    }

    public class Categories
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<SubCategories> SubCategories { get; set; }
    }

    public class OrderLines //noen som har et bedre ord for ordrelinje?! 
    {
        [Key]
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }
    }

    public class Orders
    {
       
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderLines> OrderLines { get; set; }
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }


    }


    public class Customers 
    {
        public int Id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Phonenumber { get; set; }
        public String Address { get; set; }
        public int PostalareasId { get; set; }
        public Postalareas Postalareas { get; set; }
        public byte[] Password { get; set; }
        public virtual List<Orders> Orders { get; set; }
    }

    public class Postalareas
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostalareasId { get; set; }
        public String Postalarea { get; set; }
    }

    public class SubCategories
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
        public List<Products> Products { get; set; }
    }

    public class Countries
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Products> Products { get; set; }
    }
 

}