using System;
using System.Linq.Expressions;
using BusinessLogic.Questions.Validations;
using DataAccess.Questions.Abstractions;
using Entities.Questions;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTest.Questions.Validators
{
    [TestClass]
    public class AnswerValidatorTest
    {

        private Mock<IRepository> _repositoryMock;
        private AnswerValidator _validator;
        private Guid guid;

        [TestInitialize]
        public void TestInitialize()
        {
            guid = new Guid("b1241703-8841-4c90-a5be-cad13804af15");
            _repositoryMock = new Mock<IRepository>();
            _validator = new AnswerValidator(_repositoryMock.Object);
            _repositoryMock.Setup(p =>
                    p.GetLastByFilter(It.IsAny<Expression<Func<Question, bool>>>()))
                .Returns(new Question
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
        public void When_AnswerStringIsLongerThan100_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.AnswerString, "This is a very long textThis is a very long textThis is a very long textThis is a very long textThis is a very long textThis is a very long text");
        }

        [TestMethod]
        public void When_AnswerStringIsValid_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.AnswerString, "This is a valid question?");
        }

        [TestMethod]
        public void When_AnswerStringIsNull_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.AnswerString, (string)null);
        }

        [TestMethod]
        public void When_QuestionIdIsEmpty_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.QuestionId, Guid.Empty);
        }

        [TestMethod]
        public void When_QuestionIdIsEmpty_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.QuestionId, guid);
        }
    }
}
