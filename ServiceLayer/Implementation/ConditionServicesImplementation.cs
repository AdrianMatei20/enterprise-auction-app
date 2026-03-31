// <copyright file="ConditionServicesImplementation.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace ServiceLayer.Implementation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using log4net;
    using ServiceLayer.Interfaces;

    /// <summary>
    ///     The condition services.
    /// </summary>
    public class ConditionServicesImplementation : IConditionServices
    {
        /// <summary>The logger.</summary>
        private ILog logger;

        /// <summary>The category data services.</summary>
        private IConditionDataServices conditionDataServices;

        /// <summary>Initializes a new instance of the <see cref="ConditionServicesImplementation" /> class.</summary>
        /// <param name="conditionDataServices">The category data services.</param>
        /// <param name="logger">The logger.</param>
        public ConditionServicesImplementation(IConditionDataServices conditionDataServices, ILog logger)
        {
            this.conditionDataServices = conditionDataServices;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public bool AddCondition(Condition condition)
        {
            // Check if <condition> is null.
            if (condition == null)
            {
                this.logger.Warn("Attempted to add a null condition.");
                return false;
            }

            // Check if <condition> is valid.
            var context = new ValidationContext(condition, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(condition, context, results, true))
            {
                this.logger.Warn("Attempted to add an invalid condition. " + string.Join(' ', results));
                return false;
            }

            // Check if <condition> already exists.
            if (this.conditionDataServices.GetConditionByName(condition.Name) != null)
            {
                this.logger.Warn("Attempted to add an already existing condition.");
                return false;
            }

            // If all checks pass call AddCondition.
            return this.conditionDataServices.AddCondition(condition);
        }

        /// <inheritdoc/>
        public IList<Condition> GetAllConditions()
        {
            return this.conditionDataServices.GetAllConditions();
        }

        /// <inheritdoc/>
        public Condition GetConditionById(int id)
        {
            return this.conditionDataServices.GetConditionById(id);
        }

        /// <inheritdoc/>
        public Condition GetConditionByName(string name)
        {
            return this.conditionDataServices.GetConditionByName(name);
        }

        /// <inheritdoc/>
        public bool UpdateCondition(Condition condition)
        {
            // Check if <condition> is null.
            if (condition == null)
            {
                this.logger.Warn("Attempted to update a null condition.");
                return false;
            }

            // Check if <condition> is valid.
            var context = new ValidationContext(condition, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(condition, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid condition. " + string.Join(' ', results));
                return false;
            }

            // Check if <condition> exists.
            if (this.conditionDataServices.GetConditionById(condition.Id) == null)
            {
                this.logger.Warn("Attempted to update a nonexisting condition.");
                return false;
            }

            // Check if <condition name> changed and if a condition with that name already exists.
            if (condition.Name != this.conditionDataServices.GetConditionById(condition.Id).Name
                    && this.conditionDataServices.GetConditionByName(condition.Name) != null)
            {
                this.logger.Warn("Attempted to update a condition by changing the name to an existing condition name.");
                return false;
            }

            // If all checks pass call UpdateCondition.
            return this.conditionDataServices.UpdateCondition(condition);
        }

        /// <inheritdoc/>
        public bool DeleteCondition(Condition condition)
        {
            // Check if <condition> is null.
            if (condition == null)
            {
                this.logger.Warn("Attempted to delete a null condition.");
                return false;
            }

            // Check if <condition> exists.
            if (this.conditionDataServices.GetConditionById(condition.Id) == null)
            {
                this.logger.Warn("Attempted to delete a nonexisting condition.");
                return false;
            }

            // If all checks pass call DeleteCondition.
            return this.conditionDataServices.DeleteCondition(condition);
        }
    }
}
