using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayersManager : IPlayersManagerFirstStep, IPlayersManagerSecondStep, IPlayersManagerThirdStep
    {
        int NumberOfPlayers { get; }

        void CardsTurn(SelectedCardsConfirmationDelegate cardsTurnCallback);
    }
    public interface IPlayersManagerFirstStep
    {
        IPlayersManagerSecondStep GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards);
    }
    public interface IPlayersManagerSecondStep
    {
        IPlayersManagerThirdStep GiveRaicingCards();
    }
    public interface IPlayersManagerThirdStep
    {
        IPlayersManager ChooseSecondBet();
    }

   
}