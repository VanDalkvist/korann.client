using System;

using Korann.DAL.Contracts;
using Korann.DAL.DTO;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Korann.Tests.Services
{
    [TestClass]
    public class CategoryServiceTest : ServiceTestBase
    {
        private ICategoryService _categoryService;
        private Mock<ICategoryRepository> _categoryRepositoryMock;

        private string _category1Id;
        private string _category2Id;

        private Category _category1;
        private Category _category2;

        [TestInitialize]
        public void Init()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();

            _category1Id = Guid.NewGuid().ToString();
            _category2Id = Guid.NewGuid().ToString();

            _category1 = new Category { Name = "category1", Id = _category1Id };
            _category2 = new Category { Name = "category2", Id = _category2Id };

            _categoryRepositoryMock.Setup(repository => repository.GetAll()).Returns(new[] { _category1, _category2 });
            _categoryRepositoryMock.Setup(repository => repository.GetOne(_category1Id)).Returns(_category1);

            _categoryService = new CategoryService(_categoryRepositoryMock.Object);
        }

        [TestMethod]
        public void GetAllTest()
        {
            _categoryService.GetAll();
            _categoryRepositoryMock.Verify(repository => repository.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void GetCategoryTest()
        {
            _categoryService.GetEntity(_category1Id);
            _categoryRepositoryMock.Verify(repository => repository.GetOne(It.Is<string>(s => s == _category1Id)), Times.Exactly(1));
        }
    }
}