using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]float maxHealth;
    [SerializeField] float currentHealth;
    private GameObject damagePopUpPrefab;
    AilmentManager ailment;

    [Header("Weaknesses")]
    public bool FireWeak;
    public bool EarthWeak;
    public bool LightningWeak;
    public bool IceWeak;

    public bool shocked;

    public float WeaknessMultiplier = 2;

    EnemyShield shield;
    EnemySetup setup;
    DeathEffects death;

    private void Start()
    {
        currentHealth = maxHealth;
        ailment = GetComponent<AilmentManager>();
        death = GetComponent<DeathEffects>();
        setup = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySetup>();
        damagePopUpPrefab = setup.damageNumberPrefab;
    }

    public void TakeDamage(float damage)
    {
        if (TryGetComponent<EnemyShield>(out shield)) //-if we are shielded, reduce the damage
        {
            float reduction = shield.damageReduction;
            damage *= reduction;
        }
        if (shocked)
        {
            damage *= 2;
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void TakeDamage(float damage, Vector2 position) //-this overload is for the position of the damage numbers
    {
        //-shield reduces damage
        if (TryGetComponent<EnemyShield>(out shield)) //-if we are shielded, reduce the damage
        {
            float reduction = shield.damageReduction;
            damage *= reduction;
        }
        if (shocked)
        {
            damage *= 2;
        }
        //-deal the damage
        currentHealth -= damage;

        //-spawn damage numbers
        if (damagePopUpPrefab != null)
        {
            //-damage number pop up
            GameObject damagePopUp = Instantiate(damagePopUpPrefab, position, Quaternion.identity);
            //DamagePopUp damagePopUp = damagePopupTransform.GetComponent<DamagePopUp>();
            damagePopUp.GetComponentInChildren<DamagePopUp>().Setup((int)damage);
        }
       
        //-Death check
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void TakeDamage(float damage, Vector2 position, Color textColor)
    {
        //-COLOR OVERLOAD

        //-shield reduces damage
        if (TryGetComponent<EnemyShield>(out shield)) //-if we are shielded, reduce the damage
        {
            float reduction = shield.damageReduction;
            damage *= reduction;
        }
        if (shocked)
        {
            damage *= 2;
        }
        //-deal the damage
        currentHealth -= damage;

        //-spawn damage numbers
        if (damagePopUpPrefab != null)
        {
            //-damage number pop up
            GameObject damagePopUp = Instantiate(damagePopUpPrefab, position, Quaternion.identity);
            //DamagePopUp damagePopUp = damagePopupTransform.GetComponent<DamagePopUp>();
            damagePopUp.GetComponentInChildren<DamagePopUp>().Setup((int)damage, textColor);

        }

        //-Death check
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void TakeDamage(float damage, Vector2 position, Color textColor, float textSize) 
    {
        //-COLOR AND SIZE OVERLOAD

        //-shield reduces damage
        if (TryGetComponent<EnemyShield>(out shield)) //-if we are shielded, reduce the damage
        {
            float reduction = shield.damageReduction;
            damage *= reduction;
        }
        if (shocked)
        {
            damage *= 2;
        }
        //-deal the damage
        currentHealth -= damage;

        //-spawn damage numbers
        if (damagePopUpPrefab != null)
        {
            //-damage number pop up
            GameObject damagePopUp = Instantiate(damagePopUpPrefab, position, Quaternion.identity);
            //DamagePopUp damagePopUp = damagePopupTransform.GetComponent<DamagePopUp>();
            damagePopUp.GetComponentInChildren<DamagePopUp>().Setup((int)damage, textColor, textSize);

        }

        //-Death check
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        if (!this.gameObject.CompareTag("Player"))
        {
            if (ailment != null)
            {
                ailment.DestroyAllAilmentFollowers();
            }
            if (death != null)
            {
                death.DeathEffectCheck();
            }
                
            Destroy(this.gameObject);
        }
        
    }

    //-if the enemy has a weakness, the damage value is first increased here
    public void WeaknessExploit(float damage)
    {
        float m_damage = damage * WeaknessMultiplier;
        TakeDamage(m_damage);
    }
    public void WeaknessExploit(float damage, Vector2 position)
    {
        float m_damage = damage * WeaknessMultiplier;
        TakeDamage(m_damage, position);
    }
    public void WeaknessExploit(float damage, Vector2 position, Color textColor, float textSize)
    {
        //SIZE + COLOR OVERLOAD
        float m_damage = damage * WeaknessMultiplier;
        TakeDamage(m_damage, position, textColor, textSize);
    }
    public void WeakToFire(float damage)
    {
        float FireDamage = damage * WeaknessMultiplier;

        TakeDamage(FireDamage);
    }
    public void WeakToEarth(float damage)
    {
        float EarthDamage = damage * WeaknessMultiplier;

        TakeDamage(EarthDamage);
    }
    public void WeakToLightning(float damage)
    {
        float ElectricDamage = damage * WeaknessMultiplier;

        TakeDamage(ElectricDamage);
    }
    public void WeakToIce(float damage)
    {
        float IceDamage = damage * WeaknessMultiplier;

        TakeDamage(IceDamage);
    }

}
