using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class TextureDivider
{
    public static void DivideTextures(LevelController myLevelcontroller)
    {
        int blockFactor = myLevelcontroller.blockFactor;
        float slicedBlockSize = 1024 / blockFactor;
        int blockNumber = 0;
        Block newBlock;

        GameObject spritesRoot = GameObject.Find("SpritesRoot");

        for (int i = 0; i < blockFactor; i++)
        {
            for (int j = 0; j < blockFactor; j++)
            {
                blockNumber++;

                Sprite newSprite = Sprite.Create(myLevelcontroller.sourceImage, new Rect(i * slicedBlockSize, j * slicedBlockSize, slicedBlockSize, slicedBlockSize), new Vector2(0f, 0f));
                GameObject n = new GameObject(blockNumber.ToString());

                // Set the layer to puzzlepiece
                n.layer = 8;

                // Add an image to the box
                SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                sr.sprite = newSprite;

                // Position the box
                Vector3 position = new Vector3((i * (slicedBlockSize / 100)) - 8.88f, (j * (slicedBlockSize / 100) - 5f), 0);
                n.transform.position = position;
                n.transform.parent = spritesRoot.transform;

                // Add a box collider to each block
                BoxCollider2D collider = n.AddComponent<BoxCollider2D>();

                newBlock = new Block(blockNumber, n);
                myLevelcontroller.sortedBlockList.Add(newBlock);
                myLevelcontroller.gameplayBlockList.Add(newBlock);
            }
        }
   }

}
