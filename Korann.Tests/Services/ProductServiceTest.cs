using System;

using Korann.DAL.Contracts;
using Korann.DAL.DTO;
using Korann.Infrastructure;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Korann.Tests.Services
{
    [TestClass]
    public class ProductServiceTest : ServiceTestBase
    {
        private IProductService _service;
        private Mock<IProductRepository> _productRepositoryMock;

        private string _product1Id;
        private string _product2Id;

        private Product _product1;
        private Product _product2;

        [TestInitialize]
        public void Init()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            
            _product1Id = Guid.NewGuid().ToString();
            _product2Id = Guid.NewGuid().ToString();

            _product1 = new Product { Name = "product1", Id = _product1Id };
            _product2 = new Product { Name = "product2", Id = _product2Id };

            _productRepositoryMock.Setup(repository => repository.GetAll()).Returns(new[] { _product1, _product2 });
            _productRepositoryMock.Setup(repository => repository.GetOne(_product1Id)).Returns(_product1);

            _service = new ProductService(ApiClientMock.Object);
        }

        [TestMethod]
        public void GetAllTest()
        {
            _service.GetAll();
            _productRepositoryMock.Verify(repository => repository.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void GetProductTest()
        {
            _service.GetEntity(_product1Id);
            _productRepositoryMock.Verify(repository => repository.GetOne(It.Is<string>(s => s == _product1Id)), Times.Exactly(1));
        }
    }
}