using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public interface IBowlingGame
    {
        void Roll(int pins);

        int GetScore();
    }
}
