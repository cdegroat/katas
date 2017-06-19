using System;

namespace ClassLibrary1
{
    public class BowlingGame : IBowlingGame
    {
        int score = 0;
        private static int NUM_FRAMES = 10;
        private static int NUM_ROLLS = 3;
        int[,] frames = new int[NUM_FRAMES, NUM_ROLLS];
        int currFrame = 0;
        int currRoll = 0;
        public void Roll(int pins)
        {
            frames[currFrame, currRoll] = pins;
            IncrementRoll(pins);
            ValidateRoll(pins);
            SumScore();
        }

        private void IncrementRoll(int pins)
        {
            if (currFrame != 9 && (currRoll == 1 || pins == 10))
            {
                IncrementFrame();
            }
            else
            {
                currRoll++;
            }

        }
        private void IncrementFrame()
        {
            currFrame++;
            currRoll = 0;
        }

        private void SumScore()
        {
            score = 0;
            for (int i = 0; i < NUM_FRAMES; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if(x == 3 && i != 9)
                    {
                        continue;
                    }
                    int value = frames[i, x];
                    score += value;
                    if (i != 9 && (value == 10 || (x == 1 && value != 0 && value + frames[i, 0] == 10)))
                    {
                        score += DetermineBonusValue(value == 10, i, x);
                    }
                }
            }
        }

        private int DetermineBonusValue(Boolean strike, int frame, int roll)
        {
            int bonus = 0;
            if (frame == 9)
            {
                if (roll < 2)
                {
                    bonus = frames[frame, roll + 1];
                    if (bonus == 10 && roll < 1)
                    {
                        bonus += frames[frame, roll + 2];
                    }
                }
            }
            else
            {
                bonus = frames[frame + 1, 0];
                if (strike)
                {
                    if (bonus == 10)
                    {
                        if (frame == 8)
                        {
                            bonus += frames[frame + 1, 2];
                        }
                        else
                        {
                            bonus += frames[frame + 2, 0];
                        }
                    }
                    else
                    {
                        bonus += frames[frame + 1, 1];
                    }
                }
            }
            return bonus;
        }

        private void ValidateRoll(int pins)
        {
            if (currFrame >= 11)
            {
                ThrowException("More Rolls than Frames, begin a new game.");
            }
            if (pins > 10)
            {
                ThrowException("Only 10 pins in bowling game.");
            }
            if (currRoll > 0)
            {
                int lastRoll = frames[currFrame, currRoll - 1];
                if (currFrame != 9 && lastRoll + currRoll > 10)
                {
                    ThrowException("Invalid number of knocked down pins.");
                }
            }
            if (currRoll >= 2 && currFrame != 9)
            {
                ThrowException("Can't roll more than twice on any frame except last.");
            }
            if (currRoll >= 3)
            {
                int priorRoll = frames[currFrame, currRoll - 1];
                if (priorRoll != 10)
                {
                    int rollBeforeLast = frames[currFrame, currRoll - 2];
                    if (priorRoll + rollBeforeLast != 10)
                    {
                        ThrowException("Can't roll on bonus square unless you're on a strike or spare.");
                    }
                }
            }
        }

        private void ThrowException(String message)
        {
            throw new Exception(message);
        }

        public int GetScore()
        {
            return score;
        }
    }
}
