namespace Revamp
{
    public interface IPlayerStatModifier
    {
        void AddPlayerScore(PlayerStats playerStats);
    }
    public class KamikazeShipOrigin : IPlayerStatModifier
    {
        private int kamikazeScore = 75;
        public void AddPlayerScore(PlayerStats playerStats)
        {
            playerStats.CurrentScore += kamikazeScore;
        }
    }
    public class ShooterShipOrigin : IPlayerStatModifier
    {
        private int shooterScore = 100;
        public void AddPlayerScore(PlayerStats playerStats)
        {
            playerStats.CurrentScore += shooterScore;
        }
    }
    public class RotatingRockOrigin : IPlayerStatModifier
    {
        private int rotationRockScore = 25;
        public void AddPlayerScore(PlayerStats playerStats)
        {
            playerStats.CurrentScore += rotationRockScore;
        }
    }
    // meanwhile each score hard coded in each class
}

