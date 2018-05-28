using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Players.Interfaces;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.Player
{
    public class PlayersManager : IPlayersManager
    {
        private readonly IGenericMixStrategy _mixStrategy;
        public IPlayers _players;
        public int NumberOfPlayers => _players.NumberOfPlayers;

        public PlayersManager(IPlayers players,
                              IGenericMixStrategy mixStrategy)
        {
            _mixStrategy = mixStrategy;
            _players = players;
        }
        public IPlayersManager GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            if (beatsCards == null || beatsCards.Count != 5)
                throw new ArgumentException(nameof(beatsCards));

            _players.GiveCards(_mixStrategy.Mix(beatsCards.ToList()).ToList());
            return this;
        }

        /// <summary>
        /// Deal one raicing card to each player
        /// </summary>
        public IPlayersManager GiveRaicingCards()
        {
            Enumerable.Range(1, 7)
                .ToList()
                .ForEach(x => _players.TakeCard());

            return this;
        }
    }
}