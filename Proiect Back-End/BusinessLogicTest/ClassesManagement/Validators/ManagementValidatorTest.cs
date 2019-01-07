using BusinessLogic.ClassesManagement.Validators;
using DataAccess.ClassesManagement.Abstractions;
using Entities.ClassesManagement;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq.Expressions;

namespace BusinessLogicTest.ClassesManagement.Validators
{

    [TestClass]
    public class ManagementValidatorTest
    {
        private Mock<IRepository> _repositoryMock;
        private ManagementValidator _validator;
        private Guid guid;

        [TestInitialize]
        public void TestInitialize()
        {
            guid = new Guid("b1241703-8841-4c90-a5be-cad13804af15");
            _repositoryMock = new Mock<IRepository>();
            _validator = new ManagementValidator(_repositoryMock.Object);
            _repositoryMock.Setup(p =>
                p.GetLastByFilter(It.IsAny<Expression<Func<Course, bool>>>()))
                .Returns(new Course
                {
                    Id = guid
                });
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repositoryMock = null;
            _validator = null;
            guid = Guid.Empty;
        }

        [TestMethod]
        public void When_ClassIdIsEmpty_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.ClassId, Guid.Empty);
        }

        [TestMethod]
        public void When_ClassIdIsValid_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.ClassId, guid);
        }

        [TestMethod]
        public void When_UserIdIsEmpty_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.UserId, Guid.Empty);
        }

        [TestMethod]
        public void When_UserIdIsValid_Then_ShouldNotHaveValidationError()
        {

            _validator.ShouldNotHaveValidationErrorFor(p => p.UserId, guid);
        }

        [TestMethod]
        public void When_UserPositionIsValid_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.UserPosition, "Student");
        }

        [TestMethod]
        public void When_UserPositionIsInvalid_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.UserPosition, "InvalidUserPosition");
        }

        [TestMethod]
        public void When_UserPositionIsEmpty_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.UserPosition, "");
        }

        [TestMethod]
        public void When_UserPositionIsNull_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.UserPosition, (string)null);
        }
    }
}
