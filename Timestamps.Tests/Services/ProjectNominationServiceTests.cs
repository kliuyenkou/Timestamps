using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Timestamps.Tests.Services
{
    [TestClass]
    public class ProjectNominationServiceTests
    {
        //private ProjectService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            //var mockProjectNominationRepository = new Mock<IProjectNominationRepository>();
            //var mockUnitOfWork = new Mock<IUnitOfWork>();
            //mockUnitOfWork.SetupGet(u => u.ProjectNominations).Returns(mockProjectNominationRepository.Object);
            //_service = new ProjectService(mockUnitOfWork.Object);
        }

        [TestMethod]
        public void GetProjectsUserTakePart_ProjectUserNotNominated_ShouldNotBeReturned()
        {
            //var result = _service.GetProjectsUserTakePart("user1");

            //result.Should().NotBeEmpty();
        }
    }
}