using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using GameEndpoints.Common.Validations;
using HungryUp.Common.Resources;
namespace HungryUp.Domain.Model
{
    public class ScoreBoard
    {
        public int Votes { get; set; }
        public string Restaurant { get; set; }
        public long RestaurantId { get; set; }
        public bool Draw { get; set; }

        public void SetMostVoted(IList<ScoreBoard> scoreBoard)
        {
            AssertionConcern.AssertArgumentNotNull(scoreBoard, ErrorMessages.NoVotesInTheCurrentDate);
            AssertionConcern.AssertArgumentTrue(scoreBoard.Count() > 0, ErrorMessages.NoVotesInTheCurrentDate);

            var itemMaxVote = scoreBoard.Max(y => y.Votes);
            IList<ScoreBoard> itemsMaxVotes = scoreBoard.Where(x => x.Votes == itemMaxVote).ToList();
            if (itemsMaxVotes.Count > 1)
            {
                this.Draw = true;
                Random rnd = new Random();
                int randomRestaurant = rnd.Next(0, itemsMaxVotes.Count());
                this.RestaurantId = itemsMaxVotes.ElementAt(randomRestaurant).RestaurantId;
            }
            else
            {
                this.RestaurantId = itemsMaxVotes.FirstOrDefault().RestaurantId;
            }
        }
    }
}
