using System;

using Korann.Controllers.API;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Korann.Tests.ApiControllers
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IProductService> _productServiceMock;
        private readonly string _id = Guid.NewGuid().ToString();
        private ProductsController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _productServiceMock = new Mock<IProductService>();
            _productServiceMock
                .Setup(service => service.GetAll())
                .Returns(() => new[] { new ProductModel { Id = _id } });

            _productServiceMock
                .Setup(service => service.GetEntity(_id))
                .Returns(() => new ProductModel { Id = _id, Name = "name" });

            _controller = new ProductsController(_productServiceMock.Object);
        }

        [TestMethod]
        public void GetAllTest()
        {
            _controller.GetAll();
            _productServiceMock.Verify(service => service.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void GetProductTest()
        {
            _controller.Get(_id);
            _productServiceMock.Verify(service => service.GetEntity(It.Is<string>(s => s == _id)), Times.Exactly(1));
        }
    }
}