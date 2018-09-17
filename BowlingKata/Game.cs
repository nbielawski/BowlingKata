using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Game
    {
        private List<int> rolls = new List<int>();

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }

               else  if (isSpare(frameIndex))
                {
                    score += 10 + spareBonus(frameIndex);
                    frameIndex += 2;

                }
                else
                {
                    score += FramePins(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        public int spareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

       public int FramePins(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

    
    }
}
