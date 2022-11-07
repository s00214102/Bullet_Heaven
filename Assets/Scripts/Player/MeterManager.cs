using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MeterManager : MonoBehaviour
{
    //-this is the players health and ability resource
    //-spend meter to use abilities
    //-lose meter when hit
    //-gain meter when not moving
    //-enter a critical state when at 0 meter
    //-die if hit in critical state
    //-exit critical state when gaining enough meter(maybe 50%)

    [Header("Meter")]
    public float maxMeter = 100;
    public float currentMeter;


    //[Header("Critical State")]
    //public float criticalStateExitMeterThreshold = 25;
    //public float criticalStateFlashRate = 0.2f;
    //bool criticalState = false;


    [Header("Regeneration")]
    public float minRegenSpeed = 1;
    public float regenTime = 0.5f;
    [SerializeField]float currentTime;
    public float regenAmount = 5;
    public bool canRegen = true;
    public Slider slider;

    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    //PlayerData data => GetComponent<PlayerData>();
    PlayerAttack_ver2 attack => GetComponent<PlayerAttack_ver2>();
    public SpriteRenderer sprite;
    Color s_color;

    private void Start()
    {
        currentMeter = maxMeter;
        currentTime = regenTime;

        slider.maxValue = maxMeter;
        slider.value = currentMeter;

        s_color = sprite.color;
    }
    private void Update()
    {
        if (!attack.tailActive)
        {
            MeterRegeneration();
        }

        //CriticalStateFlash();

    }
    //public void LoseMeter(float value) //call when hit by enemy attack
    //{
    //    currentMeter -= value;

    //    SetMeterSliderValue(); // UI

    //    CriticalStateMeterCheck();

    //    if (criticalState)
    //    {
    //        PlayerDeath();
    //    }
    //}
    public void SpendMeter(float value) //call when using abilities
    {
        //seperated from lose meter because of critical state, wouldnt want to die from using your own abilities

        if(currentMeter >= value) //can only spend meter when have enough meter
        {
            currentMeter -= value;

            SetMeterSliderValue(); // UI
        }
    }
    //void EnterCriticalState() 
    //{
    //    criticalState = true;
    //}
    //void ExitCriticalState()
    //{
    //    if(criticalState && currentMeter>=criticalStateExitMeterThreshold)
    //    criticalState = false;
    //}
    //void MeterRegenerationOld() //passive regeneration while moving
    //{
    //    if (currentMeter < maxMeter) //-only regen when below max meter
    //    {
    //        if (rb.velocity.magnitude <= minRegenSpeed) //-when travelling faster than X speed
    //        {
    //            currentTime -= Time.deltaTime; 
    //            if (currentTime <= 0)                  //add some meter every X seconds
    //            {
    //                GainMeter(regenAmount);
    //                currentTime = regenTime;
    //                if (currentMeter > maxMeter) currentMeter = maxMeter; // in case regen puts you over max meter amount
    //            }
    //        }
    //    }
    //}
    void MeterRegeneration() //passive regeneration while moving
    {
        if (currentMeter > maxMeter) //-only regen when below max meter
            return;
        if (rb.velocity.magnitude > minRegenSpeed) //-when travelling faster than X speed
            return;
        if (!canRegen) //-bool used for arm ability (cant regen while using it)
            return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0) //add some meter every X seconds
        {
            GainMeter(regenAmount);
            currentTime = regenTime;
            if (currentMeter > maxMeter) currentMeter = maxMeter; // in case regen puts you over max meter amount
        }
    }
    public void SetMeterToMax()
    {
        currentMeter = maxMeter;
    }
    public void MeterDegeneration(float value) //meter degeneration while ability is active, such as the tail or arm abilities
    {
        //lose some meter every X seconds
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            SpendMeter(value);

            currentTime = regenTime;
        }
    }
    public void GainMeter(float value) //use for pick ups that give the player meter
    {
        currentMeter += value;

        SetMeterSliderValue(); // UI
    }
    //void CriticalStateMeterCheck()
    //{
    //    if(currentMeter <= 0)
    //    {
    //        EnterCriticalState();
    //    }

    //}
    //void CriticalStateFlash()
    //{
    //    if (criticalState)
    //    {
    //        sprite.color = new Color(0,0,0,255);
    //    }
    //}
    public bool MeterIsEmpty()
    {
        if (currentMeter <= 0)
        {
            return true;
        }
        else { return false; }
    }
    //void PlayerDeath()
    //{
    //    //transform.position = data.currentCheckpoint.position;
    //    currentMeter = maxMeter;
    //    criticalState = false;
    //}
    public void SetMeterSliderValue()
    {
        slider.value = currentMeter;
    }

}
