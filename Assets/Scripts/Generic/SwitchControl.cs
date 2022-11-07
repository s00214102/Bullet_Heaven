using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    [HideInInspector] public bool SwitchState = false;

    public Sprite onSprite;
    public Sprite offSprite;
    SpriteRenderer s_Renderer;

    private void Start()
    {
        s_Renderer = GetComponent<SpriteRenderer>();
        s_Renderer.sprite = offSprite;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }

    void ActivateSwitch()
    {
        SwitchState = true;
        s_Renderer.sprite = onSprite;
    }
}
