using System.Collections;
using UnityEngine;

namespace Assets
{
    public class BlockSwapper : MonoBehaviour
    {
        public static void SwapBlocks(Block blockA, Block blockB)
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
        }
    }
}
