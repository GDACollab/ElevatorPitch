using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emailColorSwap : MonoBehaviour
{
    public Sprite whiteEmail;
    public Sprite grayEmail;
    private SpriteRenderer spriteRenderer;
    public bool color; //true white , false gray

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void switchColor() {
        if(color) {
            spriteRenderer.sprite = grayEmail;
            color = false;
        } else {
            spriteRenderer.sprite = whiteEmail;
            color = true;
        }
    }


}
