using UnityEngine;

namespace Revamp
{
    public class PlayerStats : MonoBehaviour
    {
        private int currentScore;
        public int CurrentScore
        {
            get { return currentScore; }
            set { currentScore = value; }
        }

        IPlayerStatModifier receivedStat = null;

        public void Scoring (IPlayerStatModifier receivedScore)
        {
            receivedStat = receivedScore;
            receivedStat?.AddPlayerScore(this);
        }
    }
}

