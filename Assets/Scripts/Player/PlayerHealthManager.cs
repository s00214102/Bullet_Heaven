using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100;
    public float currentHealth;
    public Slider slider;
    SpriteRenderer sprite;
    //Color s_color;

    [Header("Critical State")]
    public float criticalStateExitMeterThreshold = 25;
    public float criticalStateFlashRate = 0.2f;
    public float InvincibilityTimer = 0.5f;
    public float InvincibilityCurrentTime;
    bool criticalState = false;
    bool canTakeDamage = true;

    GameManager gameManager;
    CameraShake cameraShake;
    public float shakeTime = 0.8f;

    private void Start()
    {
        currentHealth = maxHealth;
        criticalState = false;

        slider.maxValue = maxHealth;
        slider.value = currentHealth;

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        //s_color = sprite.color;
    }
    private void Update()
    {
        CriticalStateFlash();
        StartInvincibilityTimer();
        ExitCriticalState();
    }

    private void StartInvincibilityTimer()
    {
        if (InvincibilityCurrentTime > 0)
        {
            InvincibilityCurrentTime -= Time.deltaTime;
        }
        else if (InvincibilityCurrentTime <= 0){ canTakeDamage = true;}
    }
    public void GainHealth(float value) //use for pick ups that give the player meter
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        SetMeterSliderValue(); // UI
    }
    public void LoseHealth(float value) //call when hit by enemy attack
    {
        if (canTakeDamage) { currentHealth -= value; }

        cameraShake.StartCameraShake(shakeTime);

        SetMeterSliderValue(); // UI

        CriticalStateMeterCheck();

        if (criticalState)
        {
            PlayerDeath();
        }
    }
    void CriticalStateMeterCheck()
    {
        if (currentHealth <= 0)
        {
            EnterCriticalState();
        }
    }
    void EnterCriticalState()
    {
        canTakeDamage = false;
        InvincibilityCurrentTime = InvincibilityTimer;
        criticalState = true;
    }
    void ExitCriticalState()
    {
        if (criticalState && currentHealth >= criticalStateExitMeterThreshold)
            criticalState = false;
    }

    void CriticalStateFlash()
    {
        if (criticalState)
        {
            //sprite.color = new Color(0, 0, 0, 255);
        }
    }
    void PlayerDeath()
    {
        gameManager.ReloadScene();
    }
    public void SetMeterSliderValue()
    {
        slider.value = currentHealth;
    }
}
