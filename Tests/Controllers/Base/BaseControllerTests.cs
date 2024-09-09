using Arrendamiento.Controllers.Base;
using Core.Helpers;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Helpers;

namespace Tests.Controllers.Base
{
    public class BaseControllerTests
    {
        private readonly Mock<IServiceBase<BaseEntity>> _mockBaseEntity;
        private readonly BaseController<BaseEntity, IServiceBase<BaseEntity>> _controller;
        private readonly List<BaseEntity> _testDataList;

        public BaseControllerTests()
        {
            _mockBaseEntity = new Mock<IServiceBase<BaseEntity>>();

            _controller = new BaseController
                             <BaseEntity, IServiceBase<BaseEntity>>
                             (_mockBaseEntity.Object);

            _testDataList = TestDataInit.GetTestData<BaseEntity>("Controllers.Base");
        }

        [TearDown]
        public void TearDown()
        {
            _mockBaseEntity.Invocations.Clear();
        }

        [Test]
        public async Task Get_Should_Return_All_Ok()
        {
            _mockBaseEntity
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(_testDataList);

            ObjectResult? responseData = (await _controller.Get()) as ObjectResult;

            Assert.IsNotNull(responseData);
            Assert.True(responseData.StatusCode == 200);
            Assert.IsNotNull(responseData.Value);
        }

        [Test]
        public async Task Get_Should_Return_Error()
        {
            _mockBaseEntity
                .Setup(x => x.GetAllAsync())
                .Throws(new Exception());

            ObjectResult? responseData = (await _controller.Get()) as ObjectResult;

            Assert.IsNotNull(responseData);
            Assert.True(responseData.StatusCode == 500);
            Assert.IsNotNull(responseData.Value);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task Get_ById_Should_Return_All_Ok(int id)
        {
            _mockBaseEntity
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(_testDataList.Find(x => x.Id == id));

            ObjectResult? responseData = (await _controller.Get(id)) as ObjectResult;

            Assert.IsNotNull(responseData);
            Assert.True(responseData.StatusCode == 200);
            Assert.IsNotNull(responseData.Value);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task Get_By_Id_Should_Return_Error(int id)
        {
            _mockBaseEntity
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Throws(new Exception());

            ObjectResult? responseData = (await _controller.Get(id)) as ObjectResult;

            Assert.IsNotNull(responseData);
            Assert.True(responseData.StatusCode == 500);
            Assert.IsNotNull(responseData.Value);
        }
    }
}
