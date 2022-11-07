using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayerSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    public Sprite[] sprites;

    private void Start()
    {
        int maxSprites = sprites.Length;

        int index = Random.Range(0, maxSprites);

        spriteRenderer.sprite = sprites[index];
    }
}
