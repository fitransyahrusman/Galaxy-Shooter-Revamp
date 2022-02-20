namespace Revamp
{
    public interface IPlayerStatModifier
    {
        void AddPlayerScore(PlayerStats playerStats);
    }
    public class KamikazeOrigin : IPlayerStatModifier
    {
        public void AddPlayerScore(PlayerStats playerStats)
        {
            throw new System.NotImplementedException();
        }
    }
    public class ShooterOrigin : IPlayerStatModifier
    {
        public void AddPlayerScore(PlayerStats playerStats)
        {
            throw new System.NotImplementedException();
        }
    }
    public class RotatingRockOrigin : IPlayerStatModifier
    {
        public void AddPlayerScore(PlayerStats playerStats)
        {
            throw new System.NotImplementedException();
        }
    }
}

