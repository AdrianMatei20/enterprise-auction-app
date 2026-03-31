// <copyright file="UserTestData.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace ModelValidationTests
{
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Enums;
    using DomainModel.Models;

    [ExcludeFromCodeCoverage]
    internal class UserTestData
    {
        private string validFirstName = "Adrian";

        private string validLastName = "Matei";

        private string validUsername = "AdiMatei20";

        private string validPhoneNumber = "0123456789";

        private string validEmail = "adrian.matei@FakeEmail.com";

        private string validPassword = "P@ssword123";

        private string longName = 'X' + new string('x', 16);

        private string noUppercaseName = new string('x', 10);

        private string noLowercaseName = new string('X', 10);

        private string symbolInFirstName = "Adr!an";

        private string numberInFirstName = "Adr1an";

        private string symbolInLastName = "Mate!";

        private string numberInLastName = "Mat3i";

        private string longUserName = new string('x', 31);

        private string longPhoneNumber = new string('8', 16);

        private string invalidPhoneNumber = "abc";

        private string longEmail = new string('x', 30) + '@' + new string('x', 30);

        private string invalidEmail = "adrian.mateiFakeEmail.com";

        private string shortPassword = "A#a1";

        private string longPassword = "A#a1" + new string('x', 20);

        private string noUppercasePassword = "p@ssword123";

        private string noLowercasePassword = "P@SSWORD123";

        private string noNumberPassword = "P@ssword";

        private string noSymbolPassword = "Password123";

        public User GetValidUser()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetAnotherValidUser()
        {
            return new User("Dinu", "Garbuz", "GbDinu", "8888888888", "dinu.garbuz@FakeEmail.com", "P@rola123");
        }

        public User GetEmptyUser()
        {
            return new User();
        }

        public User GetUserWithNullFirstName()
        {
            return new User(
                null,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithEmptyFirstName()
        {
            return new User(
                string.Empty,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithFirstNameTooLong()
        {
            return new User(
                this.longName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNoUppercaseLetterInFirstName()
        {
            return new User(
                this.noUppercaseName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNoLowercaseLetterInFirstName()
        {
            return new User(
                this.noLowercaseName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithSymbolInFirstName()
        {
            return new User(
                this.symbolInFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNumberInFirstName()
        {
            return new User(
                this.numberInFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNullLastName()
        {
            return new User(
                this.validFirstName,
                null,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithEmptyLastName()
        {
            return new User(
                this.validFirstName,
                string.Empty,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithLastNameTooLong()
        {
            return new User(
                this.validFirstName,
                this.longName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNoUppercaseLetterInLastName()
        {
            return new User(
                this.validFirstName,
                this.noUppercaseName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNoLowercaseLetterInLastName()
        {
            return new User(
                this.validFirstName,
                this.noLowercaseName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithSymbolInLastName()
        {
            return new User(
                this.validFirstName,
                this.symbolInLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNumberInLastName()
        {
            return new User(
                this.validFirstName,
                this.numberInLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNullUserName()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                null,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithEmptyUserName()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                string.Empty,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithUserNameTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.longUserName,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNullPhoneNumber()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                null,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithEmptyPhoneNumber()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                string.Empty,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithPhoneNumberTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.longPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithInvalidPhoneNumber()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.invalidPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        public User GetUserWithNullEmail()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                null,
                this.validPassword);
        }

        public User GetUserWithEmptyEmail()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                string.Empty,
                this.validPassword);
        }

        public User GetUserWithEmailTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.longEmail,
                this.validPassword);
        }

        public User GetUserWithInvalidEmail()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.invalidEmail,
                this.validPassword);
        }

        public User GetUserWithNullPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                null);
        }

        public User GetUserWithEmptyPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                string.Empty);
        }

        public User GetUserWithPasswordTooShort()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.shortPassword);
        }

        public User GetUserWithPasswordTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.longPassword);
        }

        public User GetUserWithNoUppercaseLetterInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noUppercasePassword);
        }

        public User GetUserWithNoLowercaseLetterInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noLowercasePassword);
        }

        public User GetUserWithNoNumberInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noNumberPassword);
        }

        public User GetUserWithNoSymbolInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noSymbolPassword);
        }

        public User GetUserWithUnknownAccountType()
        {
            User user = new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);

            user.AccountType = EAccountType.Unknown;

            return user;
        }
    }
}
