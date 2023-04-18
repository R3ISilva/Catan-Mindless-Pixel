using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicUIHex : MonoBehaviour
{
    public Sprite GreyHexUI;
    public Sprite GreenHexUI;
    private SpriteRenderer spriteRenderer;
    public HexProperties myHexProperties;

    #region Hex Properties
    public class HexProperties
    {
        public int Row { get; set; }
        public int Collumn { get; set; }
        public bool Selected { get; set; } = false;
        public string Sprite { get; set; }
        public int myIndex { get; set; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        RenderHexBase(myHexProperties.Selected);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        myHexProperties.Selected = !myHexProperties.Selected;
        RenderHexBase(myHexProperties.Selected);
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
