// <copyright file="ConditionValidation.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace ModelValidationTests
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Models;
    using NUnit.Framework;

    /// <summary>Test class for <see cref="Condition"/> validation.</summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class ConditionValidation
    {
        private ConditionTestData conditionTestData;
        private List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>Determines whether the given condition is valid or not.</summary>
        /// <param name="condition">The condition.</param>
        /// <returns><b>true</b> if the given condition is valid; otherwise, <b>false</b>.</returns>
        public bool IsValidCondition(Condition condition)
        {
            var context = new ValidationContext(condition, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(condition, context, results, true);
            this.results.AddRange(results);
            return validationResult;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.conditionTestData = new ConditionTestData();
        }

        /// <summary>Creates a valid <see cref="Condition"/> object to be used for testing.</summary>
        [TearDown]
        public void TearDown()
        {
            this.results = new List<ValidationResult>();
        }

        /// <summary>Test for valid condition.</summary>
        [Test]
        public void ValidCondition()
        {
            Assert.IsTrue(this.IsValidCondition(this.conditionTestData.GetValidCondition()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid condition (condition with no data).</summary>
        [Test]
        public void InvalidCondition_EmptyCondition()
        {
            Assert.IsFalse(this.IsValidCondition(this.conditionTestData.GetEmptyCondition()));
            Assert.That(this.results.Count, Is.EqualTo(2));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithNullName));
            Assert.That(this.results[1].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithNullDescription));
        }

        /// <summary>Test for invalid condition (condition with null name).</summary>
        [Test]
        public void InvalidCondition_Name_Null()
        {
            Assert.IsFalse(this.IsValidCondition(this.conditionTestData.GetConditionWithNullName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithNullName));
        }

        /// <summary>Test for invalid condition (condition with empty name).</summary>
        [Test]
        public void InvalidCondition_Name_Empty()
        {
            Assert.IsFalse(this.IsValidCondition(this.conditionTestData.GetConditionWithEmptyName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithNullName));
        }

        /// <summary>Test for invalid condition (condition with name too long).</summary>
        [Test]
        public void InvalidCondition_Name_TooLong()
        {
            Assert.IsFalse(this.IsValidCondition(this.conditionTestData.GetConditionWithNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithNameTooLong));
        }

        /// <summary>Test for invalid condition (condition with null description).</summary>
        [Test]
        public void InvalidCondition_Description_Null()
        {
            Assert.IsFalse(this.IsValidCondition(this.conditionTestData.GetConditionWithNullDescription()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithNullDescription));
        }

        /// <summary>Test for invalid condition (condition with empty description).</summary>
        [Test]
        public void InvalidCondition_Description_Empty()
        {
            Assert.IsFalse(this.IsValidCondition(this.conditionTestData.GetConditionWithEmptyDescription()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithNullDescription));
        }

        /// <summary>Test for invalid condition (condition with description too long).</summary>
        [Test]
        public void InvalidCondition_Description_TooLong()
        {
            Assert.IsFalse(this.IsValidCondition(this.conditionTestData.GetConditionWithDescriptionTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogConditionWithDescriptionTooLong));
        }
    }
}
