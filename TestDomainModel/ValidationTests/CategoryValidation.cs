// <copyright file="CategoryValidation.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace ModelValidationTests
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Models;
    using NUnit.Framework;

    /// <summary>Test class for <see cref="Category"/> validation.</summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class CategoryValidation
    {
        private CategoryTestData categoryTestData;
        private List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>Determines whether the given category is valid or not.</summary>
        /// <param name="category">The category.</param>
        /// <returns><b>true</b> if the given category is valid; otherwise, <b>false</b>.</returns>
        public bool IsValidCategory(Category category)
        {
            var context = new ValidationContext(category, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(category, context, results, true);
            this.results.AddRange(results);
            return validationResult;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.categoryTestData = new CategoryTestData();
        }

        [SetUp]
        public void SetUp()
        {
            this.results = new List<ValidationResult>();
        }

        /// <summary>Test for valid category.</summary>
        [Test]
        public void ValidCategory()
        {
            Assert.IsTrue(this.IsValidCategory(this.categoryTestData.GetValidCategory()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid category (category with no data).</summary>
        [Test]
        public void InvalidCategory_EmptyCategory()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetEmptyCategory()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNullName));
        }

        /// <summary>Test for invalid category (category with null name).</summary>
        [Test]
        public void InvalidCategory_Name_Null()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetCategoryWithNullName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNullName));
        }

        /// <summary>Test for invalid category (category with empty name).</summary>
        [Test]
        public void InvalidCategory_Name_Empty()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetCategoryWithEmptyName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNullName));
        }

        /// <summary>Test for invalid category (category with name too long).</summary>
        [Test]
        public void InvalidCategory_Name_TooLong()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetCategoryWithNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNameTooLong));
        }

        /// <summary>Test for invalid category (category with null parent category).</summary>
        [Test]
        public void ValidCategory_ParentCategory_Null()
        {
            Assert.IsTrue(this.IsValidCategory(this.categoryTestData.GetCategoryWithNullParent()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }
    }
}
