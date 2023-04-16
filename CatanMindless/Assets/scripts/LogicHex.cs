using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LogicHex;

public class LogicHex : MonoBehaviour
{
    public Sprite HexBase;
    public LogicHex myHexProperties;

    #region Hex Properties

    public int Row { get; set; }
    public int Collumn { get; set; }
    public bool Selected { get; set; } = false;
    public string Sprite { get; set; }
    public int myIndex { get; set; }

    #endregion

    private SpriteRenderer spriteRendererHexBase;
   
    // Called when spawned
    public void ConstructHex(LogicUIHex hexProperties, int rows, int columns)
    {        
        myHexProperties = ConvertLogicUIHexToLogicHex(hexProperties);

        try
        {
            string sortingLayer = "HexBaseLayer"; //manual input

            RenderHexBase(GetRenderLayer(columns), sortingLayer);
        }
        catch (UnityEngine.UnityException ex)
        {
            Debug.Log("Error Rendering Hex" + ex.Message);
        }
    }

    private int GetRenderLayer(int columns)
    {
        if(myHexProperties.Row % 2 == 0)
        {
            return (columns - myHexProperties.Collumn) * 2;
        }

        return (columns - myHexProperties.Collumn) * 2 - 1;  
    }

    private void RenderHexBase(int RenderLayer, string sortingLayer)
    {
        HexBase = Resources.Load<Sprite>(myHexProperties.Sprite);
        spriteRendererHexBase = GetComponent<SpriteRenderer>();
        spriteRendererHexBase.sprite = HexBase;

        spriteRendererHexBase.sortingLayerName = sortingLayer; //render layer
        spriteRendererHexBase.sortingOrder = RenderLayer; // render position inside layer (layers in layers)
    }

    public LogicHex ConvertLogicUIHexToLogicHex(LogicUIHex logicUIHex)
    {


        //Passar logicuihex para logichex campo a campo

        LogicHex newLogicHex;


    }
}
