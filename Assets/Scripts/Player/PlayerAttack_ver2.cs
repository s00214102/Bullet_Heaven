using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_ver2 : MonoBehaviour
{
    Vector3 mousePosition;
    public Transform spawnPoint;
    PlayerData playerData => GetComponent<PlayerData>();
    MeterManager meter => GetComponent<MeterManager>();
    OrbController orbController;
    ElementManager elementManager;

    public bool canShoot = true;
    bool orbActive = false;
    public bool tailActive = false;
    float iceFireCooldownTimer;

    [Header("Earth")]
    public float earthChargeTimer = 2.5f;
    float currentEarthChargeTimer;
    float chargedBulletSpeed;
    public float chargeRate = 1;
    public GameObject chargeAnimationPrefab;
    GameObject currentChargeAnimationPrefab;

    [Header("Lightning")]
    public LightningStrike lightningStrike;
    float lightningStrikeTimer;

    //testing passing an element into the orb detached class
    //Element element = new Fire();
    private void Start()
    {
        elementManager = GetComponentInChildren<ElementManager>();
        orbController = GetComponentInChildren<OrbController>();
    }
    void Update()
    {
        FaceMouseCursor();

        IceFireCooldowns();
        ShootFireOrIceOrb();
        ShootChargedEarthOrb();
        ChargedEarthOrbTimer();

        LightningStrikeCooldown();
        LightningStrike();

        DetachOrbAbility();

        EnableTailAbility();
    }

    private void EnableTailAbility()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            tailActive = true;
            //- swap to active orbs
            if (!orbActive)
            {
                orbActive = true;
                orbController.SwapToNewOrb(elementManager.currentElement.tailPrefab);
                orbController.SetOrbsElement();
                orbController.SetOrbsMeterManager();
                orbController.SetOrbTrailTargets();
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            tailActive = false;
            //- swap to inactive orbs
            if (orbActive)
            {
                orbActive = false;
                orbController.SwapToNewOrb(elementManager.currentElement.inactiveOrbPrefab);
                orbController.SetOrbTrailTargets();
            }
        }
        TailMeterCost();
    }

    private void TailMeterCost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (orbController.TailNullCheck())
            {
                print("ORB WAS DESTROYED");
            }

            if (tailActive)
            {
                //-spend meter
                meter.MeterDegeneration(elementManager.currentElement.tailMeterCost);
            }

            if (meter.MeterIsEmpty()) //-if meter is zero swap to inactive orbs
            {
                tailActive = false;
                orbActive = false;
                orbController.SwapToNewOrb(elementManager.currentElement.inactiveOrbPrefab);
                orbController.SetOrbTrailTargets();
            }
        }
    }

    private void DetachOrbAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(meter.currentMeter >= elementManager.currentElement.detachMeterCost)
            {
                meter.SpendMeter(elementManager.currentElement.detachMeterCost);
                //OrbDetached orbDetached = this.gameObject.AddComponent<OrbDetached>();

                orbController.SwapToNewOrb(elementManager.currentElement.activeOrbPrefab);

                orbController.SetOrbsElement(); //give each of these orbs the current element values

                //-access orbController and tell it to add the orb detach class to each orb in its list
                orbController.StopOrbFollow();
            }
        }
    }

    private void FaceMouseCursor()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - transform.position;
        transform.up = direction;
    }

    void ShootFireOrIceOrb()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            if(elementManager.elementSelected == ElementManager.ElementSelected.Fire || elementManager.elementSelected == ElementManager.ElementSelected.Ice)
            {
                if (iceFireCooldownTimer <= 0)
                {
                    GameObject bulletClone = Instantiate(elementManager.currentElement.bulletPrefab, spawnPoint.position, transform.rotation);
                    bulletClone.GetComponent<Bullet>().bulletSpeed = elementManager.currentElement.bulletSpeed;
                    bulletClone.GetComponent<PrefabElement>().p_element = elementManager.currentElement;
                    iceFireCooldownTimer = elementManager.currentElement.bulletCooldown;
                }

            }
        }
    }
    void IceFireCooldowns()
    {
        if (iceFireCooldownTimer > 0)
        {
            iceFireCooldownTimer -= Time.deltaTime;
        }
    }
    void LightningStrikeCooldown()
    {
        if(lightningStrikeTimer > 0)
        {
            lightningStrikeTimer -= Time.deltaTime;
        }
    }
    void ShootChargedEarthOrb()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            if (elementManager.elementSelected == ElementManager.ElementSelected.Earth)
            {
                //meter.SpendMeter(elementManager.currentElement.bulletMeterCost);

                //GameObject bulletClone = Instantiate(elementManager.currentElement.bulletPrefab, spawnPoint.position, transform.rotation);
                //bulletClone.GetComponent<Bullet>().bulletSpeed = elementManager.currentElement.bulletSpeed;

                currentEarthChargeTimer = earthChargeTimer;
                chargedBulletSpeed = elementManager.currentElement.bulletSpeed;
                currentChargeAnimationPrefab = Instantiate(chargeAnimationPrefab, transform.position, Quaternion.identity);
                currentChargeAnimationPrefab.transform.parent = transform;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (elementManager.elementSelected == ElementManager.ElementSelected.Earth)
            {
                //meter.SpendMeter(elementManager.currentElement.bulletMeterCost);

                GameObject bulletClone = Instantiate(elementManager.currentElement.bulletPrefab, spawnPoint.position, transform.rotation);
                bulletClone.GetComponent<Bullet>().bulletSpeed = chargedBulletSpeed;
                bulletClone.GetComponent<PrefabElement>().p_element = elementManager.currentElement;
                Destroy(currentChargeAnimationPrefab);
            }
        }
    }
    void ChargedEarthOrbTimer() // timer for how long you can hold the earth charge shot
    {
        if(currentEarthChargeTimer > 0)
        {
            currentEarthChargeTimer -= Time.deltaTime;

            chargedBulletSpeed += chargeRate*Time.deltaTime;
        }
    }
    void LightningStrike()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot && elementManager.elementSelected == ElementManager.ElementSelected.Lightning)
        {
            if(lightningStrikeTimer<=0)
            {
                lightningStrike.SpawnLightningStrike();
                lightningStrikeTimer = elementManager.currentElement.bulletCooldown;
            }
        }
    }
}
