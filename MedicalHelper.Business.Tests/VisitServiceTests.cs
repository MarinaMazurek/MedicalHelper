using AutoMapper;
using MediatR;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.DataBase.Entities;
using Moq;

namespace MedicalHelper.Business.Tests
{
    public class VisitServiceTests
    {
        public readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        public readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        public readonly Mock<IMediator> _mediatorMock = new Mock<IMediator>();

        [Fact]
        public async void GetAllVisitsAsync_CorrectData_ReturnAllVisits()
        {
            //arrange
            Guid userId = Guid.NewGuid();
            List<Visit> visitsInDb = new List<Visit>()
            {
                new Visit { Name = "test visit" }
            };
            List<VisitDto> visitsDtos = new List<VisitDto>()
            {
                new VisitDto { Name = "test visit" },
                new VisitDto { Name = "test visit 2" }
            };

            _unitOfWorkMock.Setup(x => x.Visits.GetAllVisitsByUserIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(visitsInDb);
            _mapperMock.Setup(x => x.Map<List<VisitDto>>(It.IsAny<List<Visit>>()))
                .Returns(visitsDtos);

            //action
            var visitService = GetService();
            var result = await visitService.GetAllVisitsAsync(userId);

            //asserts
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Any());
            Assert.Equal("test visit", result.First().Name);
            Assert.Equal("test visit 2", result.Last().Name);
        }

        [Fact]
        public async void GetAllVisitsAsync_CorrectDataAndEmptyListFromDb_ReturnEmptyList()
        {
            //arrange
            Guid userId = Guid.NewGuid();
            List<Visit> visitsInDb = new List<Visit>();

            _unitOfWorkMock.Setup(x => x.Visits.GetAllVisitsByUserIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(visitsInDb);

            //action
            var visitService = GetService();
            var result = await visitService.GetAllVisitsAsync(userId);

            //asserts
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.True(result.Count == 0);
        }

        private VisitService GetService()
        {
            var visitService = new VisitService(
                _unitOfWorkMock.Object,
                _mapperMock.Object,
                _mediatorMock.Object);

            return visitService;
        }
    }
}
