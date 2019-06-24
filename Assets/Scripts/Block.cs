using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Block
    {
        public int BlockNumber{ get; set; }
        public GameObject BlockObject { get; set; }

        public Block(int blockNumber, GameObject blockObject)
        {
            this.BlockObject = blockObject;
            this.BlockNumber = blockNumber;
        }

        public Block()
        {

        }

        public static void CreateEmptyBlock(LevelController levelController)
        {
            System.Random r = new System.Random();
            int indexToDelete = r.Next(levelController.gameplayBlockList.Count);
            LevelController.emptyBlock = levelController.gameplayBlockList[indexToDelete];
            levelController.gameplayBlockList.RemoveAt(indexToDelete);
            HideBlock(LevelController.emptyBlock);
        }

        public static void HideBlock(Block block)
        {
            block.BlockObject.SetActive(false);
        }

        public static void ShowBlock(Block block)
        {
            block.BlockObject.SetActive(true);
        }
    }
}
