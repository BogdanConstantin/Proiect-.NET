using BusinessLogic.ClassesManagement.Validators;
using DataAccess.ClassesManagement.Abstractions;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.ClassesManagement;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicTest.ClassesManagement.Validators
{

    [TestClass]
    public class ManagementValidatorTest
    {
        private Mock<IRepository> _repositoryMock;
        private ManagementValidator _validator;
        //private Mock<BaseValidator> _managementMock;
        private Mock<ValidationContext<ManagementDto>> validationContext;
        private Mock<ValidationResult> result;

        [TestInitialize]
        public void TestInitialize()
        {
           // _managementMock = new Mock<BaseValidator>();
            validationContext = new Mock<ValidationContext<ManagementDto>>();
            result = new Mock<ValidationResult>();
            _repositoryMock = new Mock<IRepository>();
            _validator = new ManagementValidator(_repositoryMock.Object);
        }

        [TestMethod]
        public void When_ClassIdIsEmpty_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.ClassId, Guid.Empty);
        }

        [TestMethod]
        public void When_ClassIdIsValid_Then_ShouldNotHaveValidationError()
        {           
            _validator.ShouldNotHaveValidationErrorFor(p => p.ClassId, Guid.NewGuid());
        }

        [TestMethod]
        public void When_UserIdIsEmpty_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.UserId, Guid.Empty);
        }

        [TestMethod]
        public void When_UserIdIsValid_Then_ShouldNotHaveValidationError()
        {
            var guid = new Guid("52523f49-870d-4371-96fa-a7015e888ae6");
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
            _validator.ShouldHaveValidationErrorFor(p => p.UserPosition, "Invalid");
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
