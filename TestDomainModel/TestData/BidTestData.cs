// <copyright file="BidTestData.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace ModelValidationTests
{
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Enums;
    using DomainModel.Models;

    [ExcludeFromCodeCoverage]
    internal class BidTestData
    {
        private ProductTestData productTestData = new ProductTestData();

        private UserTestData userTestData = new UserTestData();

        private decimal validAmount = 1000m;

        private ECurrency validCurrency = ECurrency.EUR;

        public Bid GetValidBid()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetEmptyBid()
        {
            return new Bid();
        }

        public Bid GetBidWithNullProduct()
        {
            return new Bid(
                null,
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptyName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductDescription()
        {
            return new Bid(
                this.productTestData.GetProductWithNullDescription(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductDescription()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptyDescription(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductDescriptionTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithDescriptionTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductCategory()
        {
            return new Bid(
                this.productTestData.GetProductWithNullCategory(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductCategoryName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullCategoryName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductCategoryName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptyCategoryName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductCategoryNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithCategoryNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNegativeProductStartingPrice()
        {
            return new Bid(
                this.productTestData.GetProductWithNegativeStartingPrice(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductSeller()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSeller(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductSellerFirstNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerFirstNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoUppercaseInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoUppercaseLetterInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoLowercaseInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoLowercaseLetterInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithSymbolInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithSymbolInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNumberInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNumberInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductSellerLastNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerLastNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoUppercaseLetterInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoUppercaseLetterInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoLowercaseLetterInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoLowercaseLetterInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithSymbolInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithSymbolInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNumberInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNumberInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductSellerUserName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerUserName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductSellerUserName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerUserName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductSellerUserNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerUserNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductSellerPhoneNumber()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerPhoneNumber(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductSellerPhoneNumber()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerPhoneNumber(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductSellerPhoneNumberTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerPhoneNumberTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithInvalidProductSellerPhoneNumber()
        {
            return new Bid(
                this.productTestData.GetProductWithInvalidSellerPhoneNumber(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductSellerEmail()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerEmail(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductSellerEmail()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerEmail(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductSellerEmailTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerEmailTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithInvalidProductSellerEmail()
        {
            return new Bid(
                this.productTestData.GetProductWithInvalidSellerEmail(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductSellerPasswordTooShort()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerPasswordTooShort(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithProductSellerPasswordTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerPasswordTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoUppercaseLetterInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoUppercaseLetterInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoLowercaseLetterInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoLowercaseLetterInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoNumberInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoNumberInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoSymbolInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoSymbolInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEndDateBeforeStartDate()
        {
            return new Bid(
                this.productTestData.GetProductWithEndDateBeforeStartDate(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullBuyer()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                null,
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNullFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithEmptyFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithBuyerFirstNameTooLong()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithFirstNameTooLong(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoUppercaseLetterInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoUppercaseLetterInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoLowercaseLetterInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoLowercaseLetterInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithSymbolInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithSymbolInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNumberInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNumberInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNullLastName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithEmptyLastName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithBuyerLastNameTooLong()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithLastNameTooLong(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoUppercaseLetterInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoUppercaseLetterInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNoLowercaseLetterInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoLowercaseLetterInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithSymbolInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithSymbolInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNumberInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNumberInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithNullBuyerUserName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNullUserName(),
                this.validAmount,
                this.validCurrency);
        }

        public Bid GetBidWithEmptyBuyerUserName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithEmptyUserName(),
                this.validAmount,
                this.validCurrency);
        }
    }
}
