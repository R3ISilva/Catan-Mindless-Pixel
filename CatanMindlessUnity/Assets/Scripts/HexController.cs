using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Brick,
    Wheat,
    Sheep
}

public class HexController : MonoBehaviour
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public int myIndex { get; private set; }
    public ResourceType ResourceType { get; private set; }
    [SerializeField] private SortingLayer SortingLayer;
    private Sprite HexBase;

    //Constructor
    public void ConstructHex(int row, int column, int totalRowsCount, int totalColumnsCount, ResourceType resourceType)
    {
        Row = row;
        Column = column;
        resourceType = ResourceType;

        int renderLayer = GetRenderLayer(Row,Column, totalColumnsCount);
        Sprite spriteToRender= GetSpriteOnResourceByResource(resourceType);

        Vector2 hexPosition = new Vector2(transform.position.x, transform.position.y);
        RenderOnResourceSprite(renderLayer, SortingLayer, spriteToRender);
    }

    /// <summary>
    /// Creates a SpriteRenderer Component and renders a sprite with sorting/render layer
    /// </summary>
    public void RenderOnResourceSprite(int renderLayer, SortingLayer sortingLayer, Sprite sprite) 
    {
        SpriteRenderer spriteRendererHexBase;
        spriteRendererHexBase = GetComponent<SpriteRenderer>();
        spriteRendererHexBase.sprite = sprite;

        spriteRendererHexBase.sortingLayerName= sortingLayer.name; //render layer
        spriteRendererHexBase.sortingOrder = renderLayer; // render position inside layer (layers in layers)
    }

    /// <summary>
    /// Gets RenderLayer on the hex grid
    /// </summary>
    public int GetRenderLayer(int row, int column, int totalColumnsCount)
    {
        if (row % 2 == 0)
        {
            return (totalColumnsCount - column) * 2;
        }

        return (totalColumnsCount - column) * 2 - 1;
    }

    /// <summary>
    /// Gets a Sprite that is on Resource Folder (fast acess sprites unity), with its resource type (wood, brick e.t.c.) 
    /// </summary>
    /// <param name="resourceType"></param>
    /// <returns></returns>
    public Sprite GetSpriteOnResourceByResource(ResourceType resourceType)
    {
        return Resources.Load<Sprite>(string.Format("Sprite_Hex_" + resourceType.ToString()));
    }
}
