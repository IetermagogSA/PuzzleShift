using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int blockFactor;
    public int maxBlocks;
    public List<Block> sortedBlockList;
    public List<Block> gameplayBlockList;
    public Texture2D sourceImage;
    public static Block emptyBlock;

    private void Start()
    {
        maxBlocks = blockFactor * blockFactor;
        sortedBlockList = new List<Block>();
        gameplayBlockList = new List<Block>();

        // Divide the picture into smaller blocks by using the texturedivider
        TextureDivider.DivideTextures(this);

        // Scramble the blocks by using the BlockScrambler
        BlockScrambler.ScrambleBlocks(this);

        Block.CreateEmptyBlock(this);
    }

}
