using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutoFixture;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SquareMetersValue.Api.Controllers;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.Models;
using SquareMetersValue.Domain.Queries;
using SquareMetersValue.Domain.ViewModel;
using Xunit;

namespace SquareMetersValue.Api.Tests.Controllers
{
    public class PropertyStatisticControllerTest
    {
        private readonly Fixture _fixture = new Fixture();


        [Fact]
        public async Task Get_PassingGuidEmpty_ReturnBadRequest()
        {

            //Arrange
            using var autoMock = AutoMock.GetLoose();

            var controller = autoMock.Create<PropertyStatisticController>();
            //Act
            var result = await controller.Get(Guid.Empty) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        //[Fact]
        //public async Task Get_MediatorReturnFailNotFound_ReturnBadRequest()
        //{
        //    //Arrange
        //    var query = _fixture.Create<CalculateSquareMeterAverageByCityQuery>();

        //    using var autoMock = AutoMock.GetLoose();

        //    var mediatorResult = Result.Failure<RealStateStatisticDataViewModel, Error>(
        //            Error.NotFound(nameof(query.CityId), query.CityId)
        //        );

        //    autoMock.Mock<IMediator>()
        //        .Setup(a => a.Send(query, It.IsAny<CancellationToken>()))
        //        .Returns( Task.FromResult(mediatorResult));

        //    var controller = autoMock.Create<PropertyStatisticController>();

        //    //Act
        //    var result = await controller.Get(Guid.NewGuid()) as BadRequestObjectResult;

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.NotNull(result.Value);
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}


        //[Fact]
        //public async Task Get_MediatorReturnSuccess_ReturnOKWithResult()
        //{
        //    //Arrange
        //    var query = _fixture.Create<CalculateSquareMeterAverageByCityQuery>();
        //    var realStateResult = _fixture.Create<RealStateStatisticDataViewModel>();

        //    using var autoMock = AutoMock.GetLoose();

        //    var mediatorResult = Result.Success<RealStateStatisticDataViewModel, Error>(
        //            realStateResult
        //        );

        //    autoMock.Mock<IMediator>()
        //        .Setup(a => a.Send(query, It.IsAny<CancellationToken>()))
        //        .Returns(Task.FromResult(mediatorResult));

        //    var controller = autoMock.Create<PropertyStatisticController>();

        //    //Act
        //    var result = await controller.Get(Guid.NewGuid()) as OkObjectResult;

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.NotNull(result.Value);
        //    Assert.IsAssignableFrom<RealStateStatisticDataViewModel>(result.Value);
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}
    }
}
