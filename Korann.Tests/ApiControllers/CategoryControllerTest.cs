using System;

using Korann.Controllers.API;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Korann.Tests.ApiControllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        private readonly Mock<ICategoryService> _categoryServiceMock = new Mock<ICategoryService>();
        private readonly string _id = Guid.NewGuid().ToString();
        private CategoriesController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _categoryServiceMock
                .Setup(service => service.GetAll())
                .Returns(() => new[] { new CategoryModel { Id = _id } });

            _categoryServiceMock
                .Setup(service => service.GetEntity(_id))
                .Returns(() => new CategoryModel { Id = _id, Name = "name" });

            _controller = new CategoriesController(_categoryServiceMock.Object);
        }

        [TestMethod]
        public void GetAllTest()
        {
            _controller.GetAll();
            _categoryServiceMock.Verify(service => service.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void GetCategoryTest()
        {
            _controller.Get(_id);
            _categoryServiceMock.Verify(service => service.GetEntity(It.Is<string>(s => s == _id)), Times.Exactly(1));
        }
    }
}