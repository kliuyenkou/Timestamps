using System;
using System.Runtime.Remoting.Messaging;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Timestamps.BLL.Models;
using Timestamps.BLL.Services;
using Timestamps.DAL.Interfaces;

namespace Timestamps.Tests.Services
{
    [TestClass]
    public class ProjectNominationServiceTests
    {
        private ProjectNominationService _service;

        [TestInitialize]
        public void TestInitialize()
        {

            var mockProjectNominationRepository = new Mock<IProjectNominationRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.SetupGet(u => u.ProjectNominations).Returns(mockProjectNominationRepository.Object);
            _service = new ProjectNominationService(mockUnitOfWork.Object);
        }

        [TestMethod]
        public void GetProjectsUserTakePart_ProjectUserNotNominated_ShouldNotBeReturned()
        {

            //var result = _service.GetProjectsUserTakePart("user1");

            //result.Should().NotBeEmpty();
        }

    }
}
