using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpriteManager : MonoBehaviour
{
    //changes player sprite to current element sprite

    SpriteRenderer m_renderer => GetComponent<SpriteRenderer>(); //for changing sprite

    public ElementManager element; //drag in inspector
    public void ChangeSprite()
    {
        m_renderer.sprite = element.currentElement.playerSprite; //change sprite
    }
}
