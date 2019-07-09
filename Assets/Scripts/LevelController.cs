using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int blockFactor;
    public int maxBlocks;
    public static List<Block> gameplayBlockList;
    public Texture2D sourceImage;
    public static Block emptyBlock;
    public bool isNewGame;
    public bool isGameOver;

    private void Start()
    {
        isNewGame = true;
        isGameOver = false;
        maxBlocks = blockFactor * blockFactor;
        gameplayBlockList = new List<Block>();

        // Divide the picture into smaller blocks by using the texturedivider
        TextureDivider.DivideTextures(this);

        // Scramble the blocks by using the BlockScrambler
        BlockScrambler.ScrambleBlocks(this);

        Block.CreateEmptyBlock(this);
    }

    public void SetGameOver(bool value)
    {
        isGameOver = value;
    }

    public void SetNewGame(bool value)
    {
        isNewGame = value;
    }

    private void Update()
    {
        if(isGameOver)
        {
            Debug.Log("Game Over, Bucko!");
        }
    }

    public void CompareBlockLists()
    {
        List<Block> test = new List<Block>();
        test = gameplayBlockList.OrderBy(i => i.BlockNumber).ToList();

        if (gameplayBlockList.SequenceEqual(test))
        {
            isGameOver = true;
        }
    }
}
