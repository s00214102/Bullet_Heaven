using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD_Controller : MonoBehaviour
{
    [Header("Fire")]
    public Image fire;
    public Sprite fireActive;
    public Sprite fireInactive;

    [Header("Ice")]
    public Image ice;
    public Sprite iceActive;
    public Sprite iceInactive;

    [Header("Earth")]
    public Image earth;
    public Sprite earthActive;
    public Sprite earthInactive;

    [Header("Lightning")]
    public Image lightning;
    public Sprite lightningActive;
    public Sprite lightningInactive;


    public void FireActive()
    {
        fire.sprite = fireActive;
    }
    public void FireInactive()
    {
        fire.sprite = fireInactive;
    }
    public void IceActive()
    {
        ice.sprite = iceActive;
    }
    public void IceInactive()
    {
        ice.sprite = iceInactive;
    }
    public void EarthActive()
    {
        earth.sprite = earthActive;
    }
    public void EarthInactive()
    {
        earth.sprite = earthInactive;
    }
    public void LightningActive()
    {
        lightning.sprite = lightningActive;
    }
    public void LightningInactive()
    {
        lightning.sprite = lightningInactive;
    }
}
