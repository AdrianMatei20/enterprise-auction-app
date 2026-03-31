// <copyright file="ConditionTestData.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace ModelValidationTests
{
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Models;

    [ExcludeFromCodeCoverage]
    internal class ConditionTestData
    {
        private string validName = "X";

        private string longName = new string('x', 16);

        private string validDescription = "description";

        private string longDescription = new string('x', 101);

        private int validValue = 10;

        public Condition GetValidCondition()
        {
            return new Condition(this.validName, this.validDescription, this.validValue);
        }

        public Condition GetEmptyCondition()
        {
            return new Condition();
        }

        public Condition GetConditionWithNullName()
        {
            return new Condition(null, this.validDescription, this.validValue);
        }

        public Condition GetConditionWithEmptyName()
        {
            return new Condition(string.Empty, this.validDescription, this.validValue);
        }

        public Condition GetConditionWithNameTooLong()
        {
            return new Condition(this.longName, this.validDescription, this.validValue);
        }

        public Condition GetConditionWithNullDescription()
        {
            return new Condition(this.validName, null, this.validValue);
        }

        public Condition GetConditionWithEmptyDescription()
        {
            return new Condition(this.validName, string.Empty, this.validValue);
        }

        public Condition GetConditionWithDescriptionTooLong()
        {
            return new Condition(this.validName, this.longDescription, this.validValue);
        }
    }
}
