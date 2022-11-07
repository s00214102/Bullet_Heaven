using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    //-notes
    //-[SerializeField] - shows private variables in the inspector
    //-"protected" - private, but can be accessed by children

    //-common variables
    [Header("Prefabs")]
    public GameObject bulletPrefab;
    public GameObject activeOrbPrefab;
    public GameObject armPrefab;
    public GameObject tailPrefab;
    public GameObject inactiveOrbPrefab;
    [Header("Sprites")]
    public Sprite playerSprite;
    public Color color;
    public float weaknessHitTextSize = 5f;
    [Header("Orbs")]
    public int startingOrbs;
    public float explosionDamage;
    //public int armOrbs;
    public Sprite elementSprite;
    [Header("Bullet")]
    public float bulletSpeed;
    public float bulletDamage;
    public float bulletLifespan;
    public float bulletCooldown;
    //public float bulletMeterCost;
    [Header("Arm")]
    public float damageInterval;
    public float armMeterCost;
    public float armDamage;
    [Header("Tail")]
    public float tailMeterCost;
    public float tailDamage;
    [Header("Detach")]
    public float detachMeterCost;
    public float detachDuration;
    public float detachDamage;

    //public float bulletSpeed
    //{
    //    get { return m_bulletSpeed; }
    //    set { m_bulletSpeed = value; }
    //}
    protected virtual void Shoot()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
