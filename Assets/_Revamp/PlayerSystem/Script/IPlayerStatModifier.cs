namespace Revamp
{
    public interface IPlayerStatModifier
    {
        void AddPlayerScore(PlayerStats playerStats);
    }
    public class KamikazeShipOrigin : IPlayerStatModifier
    {
        private int kamikazeScore;
        public void AddPlayerScore(PlayerStats playerStats)
        {
            playerStats.CurrentScore += kamikazeScore;
        }
    }
    public class ShooterShipOrigin : IPlayerStatModifier
    {
        private int shooterScore;
        public void AddPlayerScore(PlayerStats playerStats)
        {
            playerStats.CurrentScore += shooterScore;
        }
    }
    public class RotatingRockOrigin : IPlayerStatModifier
    {
        private int rotationRockScore;
        public void AddPlayerScore(PlayerStats playerStats)
        {
            playerStats.CurrentScore += rotationRockScore;
        }
    }
}

