using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OdeToFood.Web.Models;
using OdeToFood.Web.Services;
using OdeToFood.Web.Controllers;

namespace OdeToFood.Web.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTest
    {
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

            RestaurantsController restaurantsController = new RestaurantsController(mockRepo.Object);
            ViewResult result = restaurantsController.Index() as ViewResult;

            // Assertresult.Model
            var totalCount = ((List<Restaurant>)result.Model).Count;
            Assert.AreEqual(3, totalCount);
        }

        [TestMethod]
        public void Details()
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
            mockRepo.Setup(x => x.Get(1)).Returns(restaurants[0]);
            RestaurantsController restaurantsController = new RestaurantsController(mockRepo.Object);
            ViewResult result = restaurantsController.Details(1) as ViewResult;

            // Assertresult.Model
            var id = ((Restaurant)result.Model).Id;
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void Edit()
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
            mockRepo.Setup(x => x.Get(1)).Returns(restaurants[0]);
            Restaurant r = restaurants[0];
            r.Name = "NewName";
            mockRepo.Setup(x => x.Update(r));
            RestaurantsController restaurantsController = new RestaurantsController(mockRepo.Object);
            var editResponse = restaurantsController.Edit(1);

            Assert.AreEqual("NewName", ((Restaurant)((ViewResultBase)editResponse).Model).Name);

        }

        [TestMethod]
        public void Create()
        {
            var mockRepo = new Mock<IRestaurantData>();
            Restaurant restaurant = new Restaurant { Id = 1, Name = "Pastalio", Cuisine = CuisineType.Italian };
            
            mockRepo.Setup(x => x.Add(restaurant));
            RestaurantsController restaurantsController = new RestaurantsController(mockRepo.Object);
            var result = (RedirectToRouteResult)restaurantsController.Create(restaurant);
           
            Assert.AreEqual("Details", result.RouteValues["action"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }
    }
}
