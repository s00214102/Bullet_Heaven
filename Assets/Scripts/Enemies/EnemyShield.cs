using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    //-put on an enemy to give them a shield
    //-shield health works on a per hit basis
    //-one hit from the earth element = -1hp
    //-when shield health reaches zero, the component is removed
    //-while the shield is intact the healthmanager will reduce incoming damage

    public int ShieldHealthMax;
    [SerializeField] int ShieldHealthCurrent;
    public float damageReduction = 0.3f; //damage will be multiplied by this value, 10 damage * 0.3 = 3 damage

    public Sprite shieldSprite;
    public Sprite nonShieldSprite;
    SpriteRenderer spriteRenderer;


    private void Start()
    {
        ShieldHealthCurrent = ShieldHealthMax;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ShieldDamage()
    {
        ShieldHealthCurrent -= 1;

        if(ShieldHealthCurrent <= 0)
        {
            ShieldBroken();
        }
    }
    void ShieldBroken()
    {
        spriteRenderer.sprite = nonShieldSprite;
        Destroy(GetComponent<EnemyShield>());
    }
}
