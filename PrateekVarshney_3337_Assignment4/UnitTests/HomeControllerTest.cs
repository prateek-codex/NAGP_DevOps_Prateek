using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrateekVarshney_3337_Assignment4.Controllers;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrateekVarshney_3337_Assignment4.Models;

namespace UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController homeController;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeControllerTest()
        {
            homeController = new HomeController();
        }

        [TestMethod]
        public void DetailsTest()
        {
            // Arrange

            // Act
            var actualResult = this.homeController.Details(0);

            // Assert
            Assert.IsNotNull(actualResult);
        }


        [TestMethod]
        public void GetProductListTest()
        {
            // Arrange

            // Act
            var actualResult = this.homeController.GetProductList();

            // Assert
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void CreateTest()
        {
            // Arrange

            // Act
            var actualResult = this.homeController.Create();

            // Assert
            Assert.IsNotNull(actualResult);
        }


        [TestMethod]
        public void CreateParameterizedTest()
        {
            // Arrange
            var product = new Product(){Cost = 5000, Discount = 20, Id = 1, Name = "Book"};

            // Act
            var actualResult = this.homeController.Create(product);

            // Assert
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void EditTest()
        {
            // Arrange

            // Act
            var actualResult = this.homeController.Edit(0);

            // Assert
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange

            // Act
            var actualResult = this.homeController.Delete(0);

            // Assert
            Assert.IsNotNull(actualResult);
        }

    }
}

