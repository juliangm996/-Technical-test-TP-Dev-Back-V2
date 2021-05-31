using Dev_Back.Api.Controllers;
using Dev_Back.Api.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Back.Test.UnitTesting
{
    [TestClass]
    public class RestockControllerTest
    {

        [TestMethod]
        public void RestockWhile()
        {
            var stock = new StockDao
            {
                ItemCount = new List<int>
                {
                    10,20,30,40,15
                },
                Target = 80
            };

            var controller = new RestockController();


            var response = controller.RestockWhile(stock);
            var result = response.Value;
            Assert.AreEqual(20, result);
        }

        [TestMethod]
       
        public void RestockForEach()
        {
            var stock = new StockDao
            {
                ItemCount = new List<int>
                {
                    10,20,30,40,15
                },
                Target = 80
            };

            var controller = new RestockController();


            var response = controller.RestockForEach(stock);
            var result = response.Value;
            Assert.AreEqual(20, result);
        }

        [TestMethod]
       
        public void RestockFor()
        {
            var stock = new StockDao
            {
                ItemCount = new List<int>
                {
                    10,20,30,40,15
                },
                Target = 80
            };

            var controller = new RestockController();


            var response = controller.RestockFor(stock);
            var result = response.Value;
            Assert.AreEqual(20, result);
        }

        [TestMethod]
       
        public void RestockDo()
        {
            var stock = new StockDao
            {
                ItemCount = new List<int>
                {
                    10,20,30,40,15
                },
                Target = 80
            };

            var controller = new RestockController();


            var response = controller.RestockDo(stock);
            var result = response.Value;
            Assert.AreEqual(20, result);
        }

    }
}
