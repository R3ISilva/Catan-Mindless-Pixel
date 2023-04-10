using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicUIHex : MonoBehaviour
{
    public Sprite GreyHexUI;
    public Sprite GreenHexUI;
    private SpriteRenderer spriteRenderer;
    public int row { get; set; }
    public int collumn { get; set; }
    public bool Selected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        RenderHexBase(Selected);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Selected = !Selected;
        RenderHexBase(Selected);
    }

    private void RenderHexBase(bool Selected)
    {
        if(Selected)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = GreenHexUI;
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = GreyHexUI;
        }
    }
}
