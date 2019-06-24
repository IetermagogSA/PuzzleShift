﻿using System;
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
            float slicedBlockSize = 1024 / blockFactor;
            int blockSwapNumber = 0;
            System.Random r = new System.Random();

            for(int i = 0; i < levelController.maxBlocks; i++)
            {
                // Get a random block number to swap with
                blockSwapNumber = r.Next(levelController.maxBlocks);

                BlockSwapper.SwapBlocks(levelController.gameplayBlockList[i], levelController.gameplayBlockList[blockSwapNumber]);
            }
        }
    }
}
