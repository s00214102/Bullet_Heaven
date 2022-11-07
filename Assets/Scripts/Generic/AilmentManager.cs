using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AilmentManager : MonoBehaviour
{
    //-handles the ailments that can be inflicted on an enemy
    //-Stun = movement and attacking disabled
    //-Shock = they take more damage
    //-On Fire = a flame follows them dealing DoT

    [Header("STUN AILMENT")]
    [SerializeField]int stunThreshold;
    [SerializeField] int currentStun = 0;
    float stunBuildup = 0; //used to set a timer
    float stunTimer = 0;
    float stunThawTimer = 0;
    float lastStunDamageTaken;
    [SerializeField] float stunThawSpeed = 2;
    bool stunned = false;
    GameObject stunFollowerPrefab;
    GameObject currentStunFollower;

    [Header("FREEZE AILMENT")]
    [SerializeField] int freezeThreshold;
    int currentFreeze = 0;
    //float freezeBuildup = 0; //used to set a timer
    float freezeTimer = 0;
    float freezeThawTimer = 0;
    [SerializeField] float freezeThawSpeed = 2;
    bool frozen = false;
    GameObject freezeFollowerPrefab;
    GameObject currentFreezeFollower;

    [Header("SHOCK AILMENT")]
    [SerializeField] int shockThreshold;
    int currentShock = 0;
    //float shockBuildup = 0; //used to set a timer
    float shockTimer = 0;
    float shockThawTimer = 0;
    [SerializeField] float shockThawSpeed = 2;
    bool shocked = false;
    GameObject shockFollowerPrefab;
    GameObject currentShockFollower;

    [Header("FIRE AILMENT")]
    [SerializeField] int fireThreshold;
    [SerializeField] int currentFire = 0;
    //[SerializeField] float fireBuildup = 0; //used to set a timer
    [SerializeField] float fireTimer = 0;
    [SerializeField] float fireQuenchTimer = 0;
    [SerializeField] float fireQuenchSpeed = 2;
    [SerializeField] bool enflamed = false;
    GameObject flameFollowerPrefab;
    GameObject currentFlamePrefab;

    EnemyData data => GetComponent<EnemyData>();
    EnemySetup setup;
    HealthManager health => GetComponent<HealthManager>();
    private void Start()
    {
        setup = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySetup>();
        stunFollowerPrefab = setup.earthPrefab;
        freezeFollowerPrefab = setup.icePrefab;
        shockFollowerPrefab = setup.lightningPrefab;
        flameFollowerPrefab = setup.firePrefab;
    }
    private void Update()
    {
        //STUN
        StunTimer();

        //FREEZE
        FreezeTimer();
        FreezeThawTimer();

        //ENFLAME
        FireTimer();
        FireQuenchTimer();

        //SHOCK
        ShockTimer();
        ShockThawTimer();
    }

    public void DestroyAllAilmentFollowers()
    {
        DestroyStunFollower();
        DestroyFlameFollower();
        DestroyShockFollower();
        DestroyFreezeFollower();
    }
    //STUN
    public void StunBuildup(float damage) //-damage of the attack is passed in, used to calculate stun duration
    {
        if(stunned == false)
        {
            currentStun += 1;
            //build up the damage each time they are hit
            //reset this buildup after they are stunned
            stunBuildup += damage;
            lastStunDamageTaken = damage;

            if (currentStun >= stunThreshold)
            {
                float time = 0;
                if (stunBuildup > 0 && stunBuildup <= 10)
                {
                    time = 1;
                }
                else if (stunBuildup > 10 && stunBuildup <= 20)
                {
                    time = 2;
                }
                else if (stunBuildup > 20 && stunBuildup <= 40)
                {
                    time = 3;
                }
                else if (stunBuildup > 40 && stunBuildup <= 60)
                {
                    time = 4;
                }
                else if (stunBuildup > 60)
                {
                    time = 5;
                }

                Stunned(time);
            }
        }
    }
    private void Stunned(float time)
    {
        //disable movement and attacks
        stunned = true;
        data.canMove = false;
        data.canAttack = false;

        if (currentStunFollower == null) //only spawn a flame if there isnt one there already
        {
            currentStunFollower = Instantiate(stunFollowerPrefab, transform.position, Quaternion.identity);
            currentStunFollower.transform.parent = transform;
        }

        //start timer
        stunTimer = time;
    }
    void StunTimer()
    {
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0)
            {
                stunned = false;
                data.canMove = true;
                data.canAttack = true;
                stunBuildup = 0;
                currentStun = 0;
                DestroyStunFollower();
            }
        }
    }
    void StunThawTimer()
    {
        if (!stunned && stunThawTimer > 0 && currentStun > 0)
        {
            stunThawTimer -= Time.deltaTime;
            if (stunThawTimer <= 0)
            {
                currentStun -= 1;
                stunBuildup -= lastStunDamageTaken;
                stunThawTimer = stunThawSpeed;
            }
        }
    }
    public void DestroyStunFollower()
    {
        if (currentStunFollower != null)
        {
            Destroy(currentStunFollower);
        }
    }

    //FREEZE
    public void FreezeBuildup() 
    {
        if (currentFreeze < freezeThreshold)
        {
            currentFreeze += 1;
        }

        freezeThawTimer = freezeThawSpeed;

        if (currentFreeze >= freezeThreshold)
        {
            Frozen(3);
        }
    }
    private void Frozen(float time)
    {
        frozen = true;
        freezeThawTimer = 0;

        //freeze effects
        data.moveSpeed /= 2;
        data.bulletSpeed *= 0.8f;
        if (currentFreezeFollower == null) //only spawn a flame if there isnt one there already
        {
            currentFreezeFollower = Instantiate(freezeFollowerPrefab, transform.position, Quaternion.identity);
            currentFreezeFollower.transform.parent = transform;
        }

        //start timer
        freezeTimer = time;
    }
    void FreezeTimer()
    {
        if (freezeTimer > 0)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                frozen = false;
                currentFreeze -= 1;
                freezeThawTimer = freezeThawSpeed;

                //undo freeze effects
                data.moveSpeed = data.defaultMoveSpeed;
                data.bulletSpeed = data.defaultBulletSpeed;
                DestroyFreezeFollower();
            }
        }
    }
    void FreezeThawTimer()
    {
        if(!frozen && freezeThawTimer > 0 && currentFreeze > 0)
        {
            freezeThawTimer -= Time.deltaTime;
            if(freezeThawTimer <= 0)
            {
                currentFreeze -= 1;
                freezeThawTimer = freezeThawSpeed;
            }
        }
    }
    public void DestroyFreezeFollower()
    {
        if (currentFreezeFollower != null)
        {
            Destroy(currentFreezeFollower);
        }
    }

    //FIRE
    public void FireBuildup()
    {
        if (currentFire < fireThreshold)
        {
            currentFire += 1;
        }

        fireQuenchTimer = fireQuenchSpeed;

        if (currentFire >= fireThreshold)
        {
            Enflamed(3);
        }
    }
    private void Enflamed(float time)
    {
        enflamed = true;
        fireQuenchTimer = 0;

        //enflame effects
        if(currentFlamePrefab == null) //only spawn a flame if there isnt one there already
        {
            currentFlamePrefab = Instantiate(flameFollowerPrefab, transform.position, Quaternion.identity);
            //currentFlame.GetComponent<FlameFollowObject>().ObjectToFollow = this.transform;
            currentFlamePrefab.transform.parent = transform;
            //currentFlame.transform.position = Vector2.zero;
        }
        

        //start timer
        fireTimer = time;
    }
    void FireTimer()
    {
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0)
            {
                enflamed = false;
                currentFire -= 1;
                fireQuenchTimer = fireQuenchSpeed;

                //undo enflamed effects
                DestroyFlameFollower();
            }
        }
    }
    void FireQuenchTimer()
    {
        if (!enflamed && fireQuenchTimer > 0 && currentFire > 0)
        {
            fireQuenchTimer -= Time.deltaTime;
            if (fireQuenchTimer <= 0)
            {
                currentFire -= 1;
                fireQuenchTimer = fireQuenchSpeed;
            }
        }
    }
    public void DestroyFlameFollower()
    {
        if (currentFlamePrefab != null)
        {
            Destroy(currentFlamePrefab);
        }
    }

    //SHOCK
    public void ShockBuildup()
    {
        if (currentShock < shockThreshold)
        {
            currentShock += 1;
        }

        shockThawTimer = shockThawSpeed;

        if (currentShock >= shockThreshold)
        {
            Shocked(3);
        }
    }
    private void Shocked(float time)
    {
        shocked = true;
        shockThawTimer = 0;

        //shock effects
        health.shocked = true;

        if (currentShockFollower == null) //only spawn if there isnt one there already
        {
            currentShockFollower = Instantiate(shockFollowerPrefab, transform.position, Quaternion.identity);
            currentShockFollower.transform.parent = transform;
        }

        //start timer
        shockTimer = time;
    }
    void ShockTimer()
    {
        if (shockTimer > 0)
        {
            shockTimer -= Time.deltaTime;
            if (shockTimer <= 0)
            {
                shocked = false;
                currentShock -= 1;
                shockThawTimer = shockThawSpeed;

                //undo shock effects
                health.shocked = false;
                DestroyShockFollower();
            }
        }
    }
    void ShockThawTimer()
    {
        if (!shocked && shockThawTimer > 0 && currentShock > 0)
        {
            shockThawTimer -= Time.deltaTime;
            if (shockThawTimer <= 0)
            {
                currentShock -= 1;
                shockThawTimer = shockThawSpeed;
            }
        }
    }
    public void DestroyShockFollower()
    {
        if (currentShockFollower != null)
        {
            Destroy(currentShockFollower);
        }
    }
}
