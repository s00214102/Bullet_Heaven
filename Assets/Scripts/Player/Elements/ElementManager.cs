using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
    //handles switch between the elements

    [Header("Elements")]
    //hold each element prefab
    public Element currentElement;
    Element fireElement;
    Element earthElement;
    Element lightningElement;
    Element iceElement;

    [SerializeField]float cooldownTimer = 5;

    float fireCooldownCurrent;

    float earthCooldownCurrent;

    float lightningCooldownCurrent;

    float iceCooldownCurrent;


    bool fireOnCooldown;
    bool earthOnCooldown;
    bool lightningOnCooldown;
    bool iceOnCooldown;

    //private void Start()
    //{
    //    currentElement = fireElement;
    //}
    public float testFloat = 69;

    public OrbController orbControl;

    public ElementSpriteManager spriteManager;

    public HUD_Controller hud;

    PlayerAttack_ver2 attack => GetComponentInParent<PlayerAttack_ver2>(); //for changing the current bullet
    MeterManager meter => GetComponentInParent<MeterManager>();

    //--ENUM--
    public enum ElementSelected
    {
        Fire,
        Earth,
        Lightning,
        Ice
    }

    public ElementSelected elementSelected = ElementSelected.Fire;

    private void Awake()
    {
        fireElement = GetComponentInChildren<Fire>();
        earthElement = GetComponentInChildren<Earth>();
        lightningElement = GetComponentInChildren<Lightning>();
        iceElement = GetComponentInChildren<Ice>();

        ChangeToFire();
    }

    private void Update()
    {
        ElementInputSelect();
        //ElementSwitchCase();

        //-cooldown timers
        FireCooldown();
        EarthCooldown();
        IceCooldown();
        LightningCooldown();
    }

    //private void ElementSwitchCase()
    //{
    //    //-switch case (what to do when an element is selected)
    //    switch (elementSelected)
    //    {
    //        case ElementSelected.Fire:
    //            orbControl.DespawnAllOrbs();
    //            currentElement = fireElement;
    //            orbControl.SpawnInactiveOrbs();
    //            break;

    //        case ElementSelected.Earth:
    //            orbControl.DespawnAllOrbs();
    //            currentElement = earthElement;
    //            orbControl.SpawnInactiveOrbs();
    //            break;

    //        case ElementSelected.Lightning:

    //            currentElement = lightningElement;
    //            break;

    //        case ElementSelected.Wind:

    //            currentElement = windElement;
    //            break;
    //    }
    //}

    private void ElementInputSelect()
    {
        //-FIRE
        if(currentElement != fireElement)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)&&!fireOnCooldown)
            {
                ElementCooldown();
                ChangeToFire();
            }
        }
        //-EARTH
        if (currentElement != earthElement)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2)&&!earthOnCooldown)
            {
                ElementCooldown();
                ChangeToEarth();
            }
        }
        //-LIGHTNING
        if (currentElement != lightningElement)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3)&&!lightningOnCooldown)
            {
                ElementCooldown();
                ChangeToLightning();
            }
        }
        //-ICE
        if (currentElement != iceElement)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4)&&!iceOnCooldown)
            {
                ElementCooldown();
                ChangeToIce();
            }
        }

    }
    void ElementCooldown()
    {
        if (currentElement == iceElement) { iceCooldownCurrent = cooldownTimer; return; }

        if (currentElement == fireElement) { fireCooldownCurrent = cooldownTimer; return; }

        if (currentElement == earthElement) { earthCooldownCurrent = cooldownTimer; return; }

        if (currentElement == lightningElement) { lightningCooldownCurrent = cooldownTimer; return; }
    }
    private void ChangeToIce()
    {
        meter.SetMeterToMax();

        orbControl.DespawnAllOrbs();

        elementSelected = ElementSelected.Ice;

        currentElement = iceElement;

        spriteManager.ChangeSprite();

        orbControl.SpawnInactiveOrbs();
    }
    void IceCooldown()
    {
        if(iceCooldownCurrent > 0)
        {
            iceCooldownCurrent -= Time.deltaTime;
            if (!iceOnCooldown) iceOnCooldown = true;
            hud.IceInactive();
        }
        else if (iceCooldownCurrent <= 0)
        { if(iceOnCooldown) iceOnCooldown = false; hud.IceActive(); }
    }
    private void ChangeToLightning()
    {
        meter.SetMeterToMax();

        orbControl.DespawnAllOrbs();

        elementSelected = ElementSelected.Lightning;

        currentElement = lightningElement;

        spriteManager.ChangeSprite();

        orbControl.SpawnInactiveOrbs();
    }
    void LightningCooldown()
    {
        if (lightningCooldownCurrent > 0)
        {
            lightningCooldownCurrent -= Time.deltaTime;
            if (!lightningOnCooldown) lightningOnCooldown = true;
            hud.LightningInactive();
        }
        else if (lightningCooldownCurrent <= 0)
        { if (lightningOnCooldown) lightningOnCooldown = false; hud.LightningActive(); }
    }
    private void ChangeToEarth()
    {
        meter.SetMeterToMax();

        orbControl.DespawnAllOrbs();

        elementSelected = ElementSelected.Earth;

        currentElement = earthElement;

        spriteManager.ChangeSprite();

        orbControl.SpawnInactiveOrbs();
    }
    void EarthCooldown()
    {
        if (earthCooldownCurrent > 0)
        {
            earthCooldownCurrent -= Time.deltaTime;
            if (!earthOnCooldown) earthOnCooldown = true;
            hud.EarthInactive();
        }
        else if (earthCooldownCurrent <= 0)
        { if (earthOnCooldown) earthOnCooldown = false; hud.EarthActive(); }
    }
    private void ChangeToFire()
    {
        meter.SetMeterToMax();

        orbControl.DespawnAllOrbs();

        elementSelected = ElementSelected.Fire;

        currentElement = fireElement;

        spriteManager.ChangeSprite();

        orbControl.SpawnInactiveOrbs();
    }
    void FireCooldown()
    {
        if (fireCooldownCurrent > 0)
        {
            fireCooldownCurrent -= Time.deltaTime;
            if (!fireOnCooldown) fireOnCooldown = true;
            hud.FireInactive();
        }
        else if (fireCooldownCurrent <= 0)
        { if (fireOnCooldown) fireOnCooldown = false; hud.FireActive(); }
    }

}
