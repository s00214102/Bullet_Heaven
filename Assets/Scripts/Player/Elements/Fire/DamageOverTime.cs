using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    //pass it a health manager and a damage value and it will do damage every X seconds
    float damageInterval;
    float currentTime;
    Element element;
    PrefabElement prefabElement;

    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        if (element != null) { damageInterval = element.damageInterval; }
        else { damageInterval = 1; }

        currentTime = damageInterval;
    }
    public void DoDamageOverTime(HealthManager health, float damage, Vector2 position)
    {
        if(currentTime <= 0)
        {
            health.TakeDamage(damage, position);
            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoDamageOverTime(HealthManager health, float damage, Vector2 position, Color textColor)
    {
        //FONT COLOR OVERLOAD
        if (currentTime <= 0)
        {
            health.TakeDamage(damage, position, textColor);
            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoDamageOverTime(HealthManager health, AilmentManager ailment, float damage, Vector2 position)
    {
        if (currentTime <= 0)
        {
            health.TakeDamage(damage, position);
            if (ailment != null)
            {
                ailment.FireBuildup();
            }
            
            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoDamageOverTime(HealthManager health, AilmentManager ailment, float damage, Vector2 position, Color textColor)
    {
        //AILMENT OVERLOAD FOR TEXT COLOR
        if (currentTime <= 0)
        {
            health.TakeDamage(damage, position, textColor);
            if (ailment != null)
            {
                ailment.FireBuildup();
            }

            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoDamageOverTime(HealthManager health, AilmentManager ailment, float damage, Vector2 position, Color textColor, float textSize)
    {
        //AILMENT OVERLOAD FOR TEXT COLOR+SIZE
        if (currentTime <= 0)
        {
            health.TakeDamage(damage, position, textColor, textSize);
            if (ailment != null)
            {
                ailment.FireBuildup();
            }

            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoWeaknessDamageOverTime(HealthManager health, float damage, Vector2 position)
    {
        //WEAKNESS OVERLOAD
        if (currentTime <= 0)
        {
            health.WeaknessExploit(damage, position);

            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoWeaknessDamageOverTime(HealthManager health, float damage, Vector2 position, Color textColor, float textSize)
    {
        //WEAKNESS OVERLOAD + FONT COLOR AND SIZE
        if (currentTime <= 0)
        {
            health.WeaknessExploit(damage, position, textColor, textSize);

            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoWeaknessDamageOverTime(HealthManager health, AilmentManager ailment, float damage, Vector2 position)
    {
        if (currentTime <= 0)
        {
            health.WeaknessExploit(damage, position);
            if (ailment != null)
            {
                ailment.FireBuildup();
            }

            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    public void DoWeaknessDamageOverTime(HealthManager health, AilmentManager ailment, float damage, Vector2 position, Color textColor, float textSize)
    {
        //AILMENT OVERLOAD FOR TEXT COLOR+SIZE
        if (currentTime <= 0)
        {
            health.WeaknessExploit(damage, position, textColor,textSize);
            if (ailment != null)
            {
                ailment.FireBuildup();
            }

            currentTime = damageInterval;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}
