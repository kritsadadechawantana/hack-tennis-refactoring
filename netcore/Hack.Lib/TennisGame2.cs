using System;

namespace Hack.Lib
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Score;
        private int player2Score;
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = string.Empty;
            if (player1Score == player2Score)
            {
                if (player1Score < 3) return string.Format("{0}-All", getPlayerScoreText(player1Score));
                else return "Deuce";
            }
            else
            {
                if (player1Score < 4 && player2Score < 4)
                {
                    if (player1Score > player2Score)
                    {
                        return string.Format("{0}-{1}",
                            getPlayerScoreText(player1Score),
                            getPlayerScoreText(player2Score));
                    }
                    if (player1Score > 0 || player2Score > 0)
                    {
                        return string.Format("{0}-{1}",
                            getPlayerScoreText(player1Score),
                            getPlayerScoreText(player2Score));
                    }
                }
                
                if (player1Score >= 4 && player2Score >= 0 && (player1Score - player2Score) >= 2)
                {
                    return "Win for player1";
                }
                if (player2Score >= 4 && player1Score >= 0 && (player2Score - player1Score) >= 2)
                {
                    return "Win for player2";
                }
                if (player1Score > player2Score && player2Score >= 3)
                {
                    return "Advantage player1";
                }
                if (player2Score > player1Score && player1Score >= 3)
                {
                    return "Advantage player2";
                }
            }

            return score;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                player1Score++;
            else
                player2Score++;
        }

        private string getPlayerScoreText(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    throw new NotSupportedException();
            }
        }

    }
}

