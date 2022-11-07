using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int damage;
    public int MaxDamage = 3;

    DeathEffects Death;

    // Start is called before the first frame update
    void Start()
    {
        Death = GetComponent<DeathEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damage == MaxDamage)
        {
            Destroy(gameObject);

            Death.DeathEffectCheck();
        }
    }

    public void Damage()
    {
        damage += 1;
    }
}
