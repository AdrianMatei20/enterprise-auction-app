// <copyright file="UserServicesImplementation.cs" company="Transilvania University of Brasov">
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
    ///     The user services.
    /// </summary>
    public class UserServicesImplementation : IUserServices
    {
        /// <summary>The logger.</summary>
        private ILog logger;

        /// <summary>The user data services.</summary>
        private IUserDataServices userDataServices;

        /// <summary>Initializes a new instance of the <see cref="UserServicesImplementation" /> class.</summary>
        /// <param name="userDataServices">The user data services.</param>
        /// <param name="logger">The logger.</param>
        public UserServicesImplementation(IUserDataServices userDataServices, ILog logger)
        {
            this.userDataServices = userDataServices;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public bool AddUser(User user)
        {
            // Check if <user> is null.
            if (user == null)
            {
                this.logger.Warn("Attempted to add a null user.");
                return false;
            }

            // Check if <user> is valid.
            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                this.logger.Warn("Attempted to add an invalid user. " + string.Join(' ', results));
                return false;
            }

            // Check if a user with this email or username already exists.
            if (this.userDataServices.EmailAlreadyExists(user.Email)
                || this.userDataServices.UsernameAlreadyExists(user.UserName))
            {
                this.logger.Warn("Attempted to add an already existing user.");
                return false;
            }

            // If all checks pass call AddUser.
            return this.userDataServices.AddUser(user);
        }

        /// <inheritdoc/>
        public IList<User> GetAllUsers()
        {
            return this.userDataServices.GetAllUsers();
        }

        /// <inheritdoc/>
        public User GetUserById(int id)
        {
            return this.userDataServices.GetUserById(id);
        }

        /// <inheritdoc/>
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return this.userDataServices.GetUserByEmailAndPassword(email, password);
        }

        /// <inheritdoc/>
        public bool UpdateUser(User user)
        {
            // Check if <user> is null.
            if (user == null)
            {
                this.logger.Warn("Attempted to update a null user.");
                return false;
            }

            // Check if <user> is valid.
            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid user.");
                return false;
            }

            // Check if <user> exists.
            if (this.userDataServices.GetUserById(user.Id) == null)
            {
                this.logger.Warn("Attempted to update a nonexisting user.");
                return false;
            }

            // If all checks pass call UpdateUser.
            return this.userDataServices.UpdateUser(user);
        }

        /// <inheritdoc/>
        public bool DeleteUser(User user)
        {
            // Check if <user> is null.
            if (user == null)
            {
                this.logger.Warn("Attempted to delete a null user.");
                return false;
            }

            // Check if <user> exists.
            if (this.userDataServices.GetUserById(user.Id) == null)
            {
                this.logger.Warn("Attempted to delete a nonexisting user.");
                return false;
            }

            // If all checks pass call DeleteUser.
            return this.userDataServices.DeleteUser(user);
        }
    }
}
