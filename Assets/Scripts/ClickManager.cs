using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    class ClickManager : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                //int layerMask = 1 << 8;
                int layerMask = LayerMask.GetMask("PuzzlePiece");

                // Does the ray intersect any objects which are in the PuzzlePiece layer?
                if (Physics2D.Raycast(mousePos2D, Vector3.forward, Mathf.Infinity, layerMask))
                {
                    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);

                    // Process the click here - get the object that was clicked and then determine if it can be swapped with the empty block
                    if (hit.collider != null)
                    {
                        //Debug.Log(hit.collider.gameObject.name);

                        Block clickedBlock = new Block(Convert.ToInt32(hit.collider.gameObject.name), hit.collider.gameObject);

                        BlockSwapper.SwapBlocks(LevelController.emptyBlock, clickedBlock);
                    }
                }
            }
        }
    }
}
