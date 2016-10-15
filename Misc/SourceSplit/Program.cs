using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SourceLiveTimer.SourceSplit
{
    internal static class Program
    {

        private static void Main()
        {
            GameMemory _gameMemory;

            _gameMemory = new GameMemory();
            _gameMemory.OnSignOnStateChange += gameMemory_OnSignOnStateChange;
            _gameMemory.OnGameTimeUpdate += gameMemory_OnGameTimeUpdate;
            _gameMemory.StartReading();
            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        private static void gameMemory_OnSignOnStateChange(object sender, SignOnStateChangeEventArgs state)
        {
            Console.WriteLine(state.GameTime);
            Console.WriteLine(state.NewMap);
            Console.WriteLine(state.PrevMap);
        }

        private static void gameMemory_OnGameTimeUpdate(object sender, float gameTime)
        {
            Console.WriteLine(gameTime);
        }

    }
}
