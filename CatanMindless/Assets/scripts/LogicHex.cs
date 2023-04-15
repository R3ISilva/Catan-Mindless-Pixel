using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicHex : MonoBehaviour
{
    public Sprite HexPlain,HexFront, HexRight, HexLeft;


    private SpriteRenderer spriteRendererPlain, spriteRendererFront, spriteRendererRight, spriteRendererLeft;
   
    // Called when spawned
    public void ConstructHex(List<bool> selectedHexes, int myIndex, int row, int column, int rows, int columns)
    {
        HexPlain = Resources.Load<Sprite>("SpriteHexPlain");
        HexFront = Resources.Load<Sprite>("SpriteHexFront");
        HexLeft = Resources.Load<Sprite>("SpriteHexLeft");
        HexRight = Resources.Load<Sprite>("SpriteHexRight");
        try
        {
            HexDirection hexDirection = GetHexRenderDirection(selectedHexes, myIndex, row, column, rows, columns);
            RenderHexBase(hexDirection);
        }
        catch (UnityEngine.UnityException ex)
        {
            Debug.Log("Error Rendering Hex" + ex.Message);
        }
    }

    private void RenderHexBase(HexDirection hexRenderDirection)
    {
        spriteRendererPlain = GetComponent<SpriteRenderer>();
        spriteRendererPlain.sprite = HexPlain;

        //renders sides of the hex depending on adjacent hexes position
        if (hexRenderDirection.front)
        {
            spriteRendererLeft = GetComponent<SpriteRenderer>();
            spriteRendererLeft.sprite = HexFront;
        }
        if (hexRenderDirection.left)
        {
            spriteRendererLeft.sprite = HexLeft;
        }
        if (hexRenderDirection.right)
        {
            spriteRendererLeft.sprite = HexRight;
        }
    }

    private HexDirection GetHexRenderDirection(List<bool> selectedHexes, int myIndex, int row, int column, int rows, int columns)
    {
        HexDirection hexDirection = new HexDirection();

        // Gets the index below
        int indexBelow = myIndex - 1;
        // Check if the calculated index is within the bounds of the list and if the bool value at that index is true
        if (indexBelow > 0 && !selectedHexes[indexBelow])
        {
            hexDirection.front = true;
        }

        return hexDirection;
    }

    public class HexDirection
    {
        public bool front { get; set; } = false;
        public bool left { get; set; } = false;
        public bool right { get; set; } = false;
    }

}
