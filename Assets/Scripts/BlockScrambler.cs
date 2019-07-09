using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class BlockScrambler
    {
        public static void ScrambleBlocks(LevelController levelController)
        {
            int blockFactor = levelController.blockFactor;
            int blockSwapNumber = 0;
            System.Random r = new System.Random();

            for (int i = 0; i < levelController.maxBlocks; i++)
            {
                // Get a random block number to swap with
                blockSwapNumber = r.Next(levelController.maxBlocks);

                BlockSwapper.SwapBlocks(LevelController.gameplayBlockList[i], LevelController.gameplayBlockList[blockSwapNumber]);
            }

            levelController.SetNewGame(false);
        }
    }
}
