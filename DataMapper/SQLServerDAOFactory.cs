// <copyright file="SQLServerDAOFactory.cs" company="Transilvania University of Brasov">
// Matei Adrian
// </copyright>

namespace DataMapper
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DataMapper.SqlServerDAO;

    /// <summary>The service factory.</summary>
    [ExcludeFromCodeCoverage]
    public class SQLServerDAOFactory : IDAOFactory
    {
        /// <inheritdoc/>
        public IProductDataServices ProductDataServices
        {
            get
            {
                return new SQLProductDataServices();
            }
        }

        /// <inheritdoc/>
        public ICategoryDataServices CategoryDataServices
        {
            get
            {
                return new SQLCategoryDataServices();
            }
        }

        /// <inheritdoc/>
        public IBidDataServices BidDataServices
        {
            get
            {
                return new SQLBidDataServices();
            }
        }

        /// <inheritdoc/>
        public IUserDataServices UserDataServices
        {
            get
            {
                return new SQLUserDataServices();
            }
        }

        /// <inheritdoc/>
        public IRatingDataServices RatingDataServices
        {
            get
            {
                return new SQLRatingDataServices();
            }
        }

        /// <inheritdoc/>
        public IConditionDataServices ConditionDataServices
        {
            get
            {
                return new SQLConditionDataServices();
            }
        }

        /// <inheritdoc/>
        public IUserScoreAndLimitsDataServices UserScoreAndLimitsDataServices
        {
            get
            {
                return new SQLUserScoreAndLimitsDataServices();
            }
        }
    }
}
