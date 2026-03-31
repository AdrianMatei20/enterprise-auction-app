// <copyright file="BidValidation.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace ModelValidationTests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Enums;
    using DomainModel.Models;
    using NUnit.Framework;

    /// <summary>Test class for <see cref="Bid"/> validation.</summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class BidValidation
    {
        private BidTestData bidTestData;
        private List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>Determines whether the given bid is valid or not.</summary>
        /// <param name="bid">The bid.</param>
        /// <returns><b>true</b> if the given bid is valid; otherwise, <b>false</b>.</returns>
        private bool IsValidBid(Bid bid)
        {
            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(bid, context, results, true);
            this.results.AddRange(results);
            return validationResult;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.bidTestData = new BidTestData();
        }

        [TearDown]
        public void TearDown()
        {
            this.results = new List<ValidationResult>();
        }

        /// <summary>Test for valid bid.</summary>
        [Test]
        public void ValidBid()
        {
            Assert.IsTrue(this.IsValidBid(this.bidTestData.GetValidBid()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid bid (bid with no data).</summary>
        [Test]
        public void InvalidBid_EmptyBid()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetEmptyBid()));
            Assert.That(this.results.Count, Is.EqualTo(2));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithNullProduct));
            Assert.That(this.results[1].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithNullBuyer));
        }

        /// <summary>Test for invalid bid (bid with null product).</summary>
        [Test]
        public void InvalidBid_NullProduct()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProduct()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithNullProduct));
        }

        /// <summary>Test for invalid bid (bid with null product name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Name_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Name_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product name too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Name_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product description).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Description_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductDescription()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product description).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Description_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductDescription()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product description too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Description_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductDescriptionTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product category).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Category_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductCategory()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product category name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Category_Name_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductCategoryName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product category name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Category_Name_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductCategoryName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product category name too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_Category_Name_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductCategoryNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with negative product starting price).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_StartingPrice_Negative()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNegativeProductStartingPrice()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product seller).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_NullSeller()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductSeller()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product seller first name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_FirstName_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product seller first name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_FirstName_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller first name too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_FirstName_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductSellerFirstNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller first name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_FirstName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoUppercaseInProductSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller first name that only has uppercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_FirstName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoLowercaseInProductSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller first name that contains symbols).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_FirstName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithSymbolInProductSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller first name that contains numbers).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNumberInProductSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product seller last name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_LastName_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product seller last name).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_LastName_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller last name too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_LastName_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductSellerLastNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller last name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_LastName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoUppercaseLetterInProductSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller last name that only has uppercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_LastName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoLowercaseLetterInProductSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller last name that contains symbols).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_LastName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithSymbolInProductSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller last name that contains numbers).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_LastName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNumberInProductSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product seller username).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_UserName_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductSellerUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product seller username).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_UserName_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductSellerUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller username too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_UserName_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductSellerUserNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for valid bid (bid with null product seller phone number).</summary>
        [Test]
        public void ValidBid_ValidProduct_ValidSeller_PhoneNumber_Null()
        {
            Assert.IsTrue(this.IsValidBid(this.bidTestData.GetBidWithNullProductSellerPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid bid (bid with empty product seller phone number).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_PhoneNumber_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductSellerPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller phone number too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_PhoneNumber_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductSellerPhoneNumberTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for valid bid (bid with invalid product seller phone number).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_PhoneNumber_Invalid()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithInvalidProductSellerPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product seller email address).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Email_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductSellerEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product seller email address).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Email_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductSellerEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller email address too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Email_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductSellerEmailTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with invalid product seller email address).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Email_Invalid()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithInvalidProductSellerEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null product seller password).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullProductSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with empty product seller password).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyProductSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller password too short).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_TooShort()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductSellerPasswordTooShort()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller password too long).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithProductSellerPasswordTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller password that doesn't contain uppercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_MissingUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoUppercaseLetterInProductSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller password that doesn't contain lowercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_MissingLowerCaseLetter()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoLowercaseLetterInProductSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller password that doesn't contain numbers).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_MissingNumber()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoNumberInProductSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product seller password that doesn't contain symbols).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_InvalidSeller_Password_MissingSymbol()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoSymbolInProductSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with product auction end date before auction start date).</summary>
        [Test]
        public void InvalidBid_InvalidProduct_EndDate_BeforeStartDate()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEndDateBeforeStartDate()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidProduct));
        }

        /// <summary>Test for invalid bid (bid with null buyer).</summary>
        [Test]
        public void InvalidBid_NullBuyer()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullBuyer()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithNullBuyer));
        }

        /// <summary>Test for invalid bid (bid with null buyer first name).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_FirstName_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullBuyerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with empty buyer first name).</summary>
        [Test]
        public void InvalidBid_InvalidBuyerFirstName_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyBuyerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer first name too long).</summary>
        [Test]
        public void InvalidBid_InvalidBuyerFirstName_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithBuyerFirstNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer first name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidBid_InvalidBuyerFirstName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoUppercaseLetterInBuyerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer first name that only has uppercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidBuyerFirstName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoLowercaseLetterInBuyerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer first name that contains symbols).</summary>
        [Test]
        public void InvalidBid_InvalidBuyerFirstName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithSymbolInBuyerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer first name that contains numbers).</summary>
        [Test]
        public void InvalidBid_InvalidBuyerFirstName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNumberInBuyerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with null buyer last name).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_LastName_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullBuyerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with empty buyer last name).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_LastName_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyBuyerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer last name too long).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_LastName_TooLong()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithBuyerLastNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer last name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_LastName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoUppercaseLetterInBuyerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer last name that only has uppercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_LastName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNoLowercaseLetterInBuyerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer last name that contains symbols).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_LastName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithSymbolInBuyerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer last name that contains numbers).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_LastName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNumberInBuyerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with null buyer username).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_UserName_Null()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithNullBuyerUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with empty buyer username).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_UserName_Empty()
        {
            Assert.IsFalse(this.IsValidBid(this.bidTestData.GetBidWithEmptyBuyerUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogBidWithInvalidBuyer));
        }

        /// <summary>Test for invalid bid (bid with buyer username too long).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_UserName_TooLong()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", new string('x', 31), "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for valid bid (bid with null buyer phone number).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_PhoneNumber_Null()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", null, "adrian.matei@FakeEmail.com", "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsTrue(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(0, results.Count);
        }

        /// <summary>Test for invalid bid (bid with empty buyer phone number).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_PhoneNumber_Empty()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", string.Empty, "adrian.matei@FakeEmail.com", "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer phone number too long).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_PhoneNumber_TooLong()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", new string('8', 16), "adrian.matei@FakeEmail.com", "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for valid bid (bid with invalid buyer phone number).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_PhoneNumber_Invalid()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "abc", "adrian.matei@FakeEmail.com", "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with null buyer email address).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Email_Null()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", null, "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with empty buyer email address).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Email_Empty()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", string.Empty, "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer email address too long).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Email_TooLong()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", new string('x', 51), "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with invalid buyer email address).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Email_Invalid()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.mateiFakeEmail.com", "P@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with null buyer password).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_Null()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", null),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with empty buyer password).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_Empty()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", string.Empty),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer password too short).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_TooShort()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "A#a1"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer password too long).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_TooLong()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "A#a1" + new string('x', 20)),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer password that doesn't contain uppercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_MissingUpperCaseLetter()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "p@ssword123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer password that doesn't contain lowercase letters).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_MissingLowerCaseLetter()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@SSWORD123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer password that doesn't contain numbers).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_MissingNumber()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with buyer password that doesn't contain symbols).</summary>
        [Test]
        public void InvalidBid_InvalidBuyer_Password_MissingSymbol()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "Password123"),
                1000,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithInvalidBuyer, results[0].ErrorMessage);
        }

        /// <summary>Test for invalid bid (bid with negative amount).</summary>
        [Test]
        public void InvalidBid_Amount_Negative()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                -1,
                ECurrency.EUR);

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(bid, context, results, true));
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(LogTestData.LogBidWithNegativeAmount, results[0].ErrorMessage);
        }
    }
}
