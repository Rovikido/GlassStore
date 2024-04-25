using GlassStore.Server.Controllers;
using GlassStore.Server.Domain.Models.Glass;
using GlassStore.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassStore.NUnitTests
{
    public class GlassesControllerTests
    {
        private Mock<iBaseRepository<Glasses>> mockRepository;
        private GlassesController glassesController;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<iBaseRepository<Glasses>>();
            glassesController = new GlassesController(mockRepository.Object);
        }

        [Test]
        public async Task Get_ReturnsAllGlasses()
        {
            // Arrange
            var glassesList = new List<Glasses>
            {
                new Glasses { Id = "653927fb47981feeebf70d97", Brand = "Ray-Ban" },
                new Glasses { Id = "653927fb47981feeebf70d98", Brand = "Persol" },
                new Glasses { Id = "653927fb47981feeebf70d99", Brand = "Zenni Optical" }
            };
            mockRepository.Setup(repo => repo.GetAllAsync())
                .Returns(Task.FromResult(glassesList.AsEnumerable()));

            // Act
            var result = (await glassesController.Get()).data.ToList();

            // Assert
            Assert.AreEqual(glassesList[0], result[0]);
            Assert.AreEqual(glassesList.Count, result.Count());
        }
    }
}