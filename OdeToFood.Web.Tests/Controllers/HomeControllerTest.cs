using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OdeToFood.Web.Models;
using OdeToFood.Web.Services;
using OdeToFood.Web;
using OdeToFood.Web.Controllers;

namespace OdeToFood.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestInitialize]
        public void Setup()
        {

            var mockRepo = new Mock<IRestaurantData>();

            //arrange  
            var company = new Restaurant { Id = 1, Name = "Fredo", Cuisine = CuisineType.Italian };

            
            mockRepo.Setup(x => x.Get(1)).Returns(company);
        }
       
        [TestMethod]
        public void Index()
        {

            List<Restaurant> restaurants;
            var mockRepo = new Mock<IRestaurantData>();
            //arrange  
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Pastalio", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Spices", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 3, Name = "FrenBread", Cuisine = CuisineType.French}
            };
            mockRepo.Setup(x => x.GetAll()).Returns(restaurants);
            // Arrange
            HomeController controller = new HomeController(mockRepo.Object);

            ViewResult result = controller.Index() as ViewResult;
            
            // Assertresult.Model
            var totalCount = ((List<Restaurant>)result.Model).Count;


            Assert.AreEqual(3, totalCount);
        }

        [TestMethod]
        public void About()
        {
            var mockRepo = new Mock<IRestaurantData>();

            //arrange  

            List<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Pastalio", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Spices", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 3, Name = "FrenBread", Cuisine = CuisineType.French}
            };

            mockRepo.Setup(x => x.Get(1)).Returns(restaurants[0]);
            // Arrange
            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            var mockRepo = new Mock<IRestaurantData>();

            //arrange  
            var company = new Restaurant { Id = 1, Name = "Fredo", Cuisine = CuisineType.Italian };


            mockRepo.Setup(x => x.Get(1)).Returns(company);

            // Arrange
            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
