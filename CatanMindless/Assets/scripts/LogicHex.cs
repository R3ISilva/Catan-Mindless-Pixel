using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicHex : MonoBehaviour
{
    public Sprite BaseHex;
    private SpriteRenderer spriteRenderer;
   
    // Start is called before the first frame update
    void Start()
    {
        RenderHexBase();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void RenderHexBase()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = BaseHex;
        
    }
}
