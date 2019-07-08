using System.Collections;
using UnityEngine;

namespace Assets
{
    public class BlockSwapper : MonoBehaviour
    {
        public static void SwapBlocks(Block blockA, Block blockB, bool isNewGame)
        {
            if (AllowSwap(blockA.BlockNumber, blockB.BlockNumber))
            {
                // swap the blocks around
                Vector3 oldPos = new Vector3(blockA.BlockObject.transform.position.x, blockA.BlockObject.transform.position.y);
                Vector3 newPos = new Vector3(blockB.BlockObject.transform.position.x, blockB.BlockObject.transform.position.y);
                string oldName = blockA.BlockObject.name;
                string newName = blockB.BlockObject.name;
                int oldBlockNumber = blockA.BlockNumber;

                blockA.BlockObject.transform.position = newPos;
                blockA.BlockNumber = blockB.BlockNumber;
                blockA.BlockObject.name = newName;

                blockB.BlockObject.transform.position = oldPos;
                blockB.BlockNumber = oldBlockNumber;
                blockB.BlockObject.name = oldName;

                if (!isNewGame)
                {
                    // Play a sound
                    BlockShiftSound blockShiftSound = FindObjectOfType<BlockShiftSound>();
                    blockShiftSound.PlayShiftSound();

                    // Increment the move counter
                    FindObjectOfType<MoveCounter>().IncreaseMoveCount();
                }
            }
        }

        private static bool AllowSwap(int emptyBlockNumber, int clickedBlockNumber)
        {
            int blockFactor = FindObjectOfType<LevelController>().blockFactor;
            int minBlocks = 0;
            int maxBlocks = FindObjectOfType<LevelController>().maxBlocks;

            // case 1 - clicked left of empty block
            if(emptyBlockNumber - blockFactor == clickedBlockNumber)
            {
                return true;
            }

            // case 2 - clicked right of empty block
            if(emptyBlockNumber + blockFactor == clickedBlockNumber)
            {
                return true;
            }

            // case 3 - clicked above empty block
            if(emptyBlockNumber % blockFactor > 0)
            {
                if (emptyBlockNumber + 1 == clickedBlockNumber)
                    return true;
            }

            // case 4 - clicked below empty block
            if (clickedBlockNumber % blockFactor > 0)
            {
                if (emptyBlockNumber - 1 == clickedBlockNumber)
                    return true;
            }

            return false;
        }
    }
}
