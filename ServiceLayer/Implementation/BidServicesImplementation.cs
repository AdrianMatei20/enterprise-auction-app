// <copyright file="BidServicesImplementation.cs" company="Transilvania University of Brasov">
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
    ///     The bid services.
    /// </summary>
    public class BidServicesImplementation : IBidServices
    {
        /// <summary>The logger.</summary>
        private ILog logger;

        /// <summary>The bid data services.</summary>
        private IBidDataServices bidDataServices;

        /// <summary>The user score and limits data services.</summary>
        private IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices;

        /// <summary>Initializes a new instance of the <see cref="BidServicesImplementation" /> class.</summary>
        /// <param name="bidDataServices">The bid data services.</param>
        /// <param name="userScoreAndLimitsDataServices">The user score and limits data services.</param>
        /// <param name="logger">The logger.</param>
        public BidServicesImplementation(IBidDataServices bidDataServices, IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices, ILog logger)
        {
            this.bidDataServices = bidDataServices;
            this.userScoreAndLimitsDataServices = userScoreAndLimitsDataServices;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public bool AddBid(Bid bid)
        {
            // Check if <bid> is null.
            if (bid == null)
            {
                this.logger.Warn("Attempted to add a null bid.");
                return false;
            }

            // Check if <bid> is valid.
            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(bid, context, results, true))
            {
                this.logger.Warn("Attempted to add an invalid bid. " + string.Join(' ', results));
                return false;
            }

            // Check if <user> can bid.
            if (this.bidDataServices.GetNoOfActiveBidsByUserId(bid.Buyer.Id)
                >= this.userScoreAndLimitsDataServices.GetUserLimitByUserId(bid.Buyer.Id))
            {
                this.logger.Warn("Attempted to bid over limit.");
                return false;
            }

            // Check if the auction has started and that it hasn't ended yet.
            if (bid.DateAndTime < bid.Product.StartDate
                || bid.DateAndTime > bid.Product.EndDate
                || bid.DateAndTime > bid.Product.TerminationDate)
            {
                this.logger.Warn("Attempted to bid before the auction started or after the auction ended.");
                return false;
            }

            // Check if the buyer is also the seller.
            if (bid.Buyer.Id == bid.Product.Seller.Id)
            {
                this.logger.Warn("Attempted to bid on an owned product.");
                return false;
            }

            // Check if the currency is the correct one.
            if (bid.Currency != bid.Product.Currency)
            {
                this.logger.Warn("Attempted to bid with different currency.");
                return false;
            }

            // Check if the bid is high enough. Also, check if the user already has the top bid.
            var existingBids = this.bidDataServices.GetBidsByProductId(bid.Product.Id);
            if ((existingBids.Count == 0 && bid.Amount < bid.Product.StartingPrice)
                || (existingBids.Count > 0 && (bid.Amount < existingBids[0].Amount || bid.Buyer.Id == existingBids[0].Buyer.Id)))
            {
                this.logger.Warn("Attempted to bid with not enough money or user already has the winning bid.");
                return false;
            }

            // If all checks pass call AddBid.
            return this.bidDataServices.AddBid(bid);
        }

        /// <inheritdoc/>
        public IList<Bid> GetAllBids()
        {
            return this.bidDataServices.GetAllBids();
        }

        /// <inheritdoc/>
        public Bid GetBidById(int id)
        {
            return this.bidDataServices.GetBidById(id);
        }

        /// <inheritdoc/>
        public IList<Bid> GetBidsByProductId(int id)
        {
            return this.bidDataServices.GetBidsByProductId(id);
        }

        /*
        public bool UpdateBid(Bid bid)
        {
            if (bid != null)
            {
                var context = new ValidationContext(bid, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(bid, context, results, true))
                {
                    if (_bidDataServices.GetBidById(bid.Id) != null)
                    {
                        return _bidDataServices.UpdateBid(bid);
                    }
                    else
                    {
                        _logger.Warn("Attempted to update a nonexisting bid.");
                        return false;
                    }
                }
                else
                {
                    _logger.Warn("Attempted to update an invalid bid.");
                    return false;
                }
            }
            else
            {
                _logger.Warn("Attempted to update a null bid.");
                return false;
            }
        }

        public bool DeleteBid(Bid bid)
        {
            if (bid != null)
            {
                if (_bidDataServices.GetBidById(bid.Id) != null)
                {
                    return _bidDataServices.DeleteBid(bid);
                }
                else
                {
                    _logger.Warn("Attempted to delete a nonexisting bid.");
                    return false;
                }
            }
            else
            {
                _logger.Warn("Attempted to delete a null bid.");
                return false;
            }
        }
        */
    }
}
