using BusinessLogic.Questions.Validations;
using DataAccess.ClassesManagement.Abstractions;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTest.Questions.Validators
{
    [TestClass]
    public class QuestionValidatorTest
    {
        private Mock<IRepository> _repositoryMock;
        private QuestionValidator _validator;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<IRepository>();
            _validator = new QuestionValidator();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repositoryMock = null;
            _validator = null;
        }

        [TestMethod]
        public void When_QuestionStringIsLongerThan100_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.QuestionString, "This is a very long textThis is a very long textThis is a very long textThis is a very long textThis is a very long textThis is a very long text");
        }

        [TestMethod]
        public void When_QuestionStringIsValid_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.QuestionString, "This is a valid question?");
        }

        [TestMethod]
        public void When_QuestionStringIsNull_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.QuestionString, (string)null);
        }
    }
}
