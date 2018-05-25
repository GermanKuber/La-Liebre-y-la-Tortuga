using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Player
{
    public class NonePlayer : IPlayer
    {
        public static NonePlayer Create => new NonePlayer();
        public void GiveCard(IBetCard betCard)
        {

        }

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => default(ISideBoderSelected);
    }
}