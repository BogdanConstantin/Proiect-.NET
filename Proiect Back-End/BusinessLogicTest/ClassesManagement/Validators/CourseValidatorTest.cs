﻿using BusinessLogic.ClassesManagement.Validators;
using DataAccess.ClassesManagement.Abstractions;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    [TestClass]
    public class CourseValidatorTest
    {
        private Mock<IRepository> _repositoryMock;

        private CourseValidator _validator;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<IRepository>();
            _validator = new CourseValidator();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repositoryMock = null;
            _validator = null;
        }

        [TestMethod]
        public void When_SemesterIsGreaterThan2_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Semester, 8);
        }

        [TestMethod]
        public void When_SemesterIsNotNull_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Semester, 1);
        }

        [TestMethod]
        public void When_YearIs4_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Year, 4);
        }

        [TestMethod]
        public void When_YearIsNotNull_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Year, 1);
        }

        [TestMethod]
        public void When_CourseTitleIsNull_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.CourseTitle, (string)null);
        }

        [TestMethod]
        public void When_CourseTitleIsEmpty_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.CourseTitle, "");
        }

        [TestMethod]
        public void When_CourseTitleIsNotNull_Then_ShouldNotHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.CourseTitle, "Title");
        }

        [TestMethod]
        public void When_CourseTitleIsTooLong_Then_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.CourseTitle, "1111111111111111111111111111111111111");
        }
    }
}

