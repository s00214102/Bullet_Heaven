using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthShooterAnimation : MonoBehaviour
{
    Animator[] anims;

    private void Start()
    {
        anims = GetComponentsInChildren<Animator>();
    }
    public void PlayHitAnimation()
    {
        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].Play("Hit");
        }
    }
    public void PlayShootAnimation()
    {
        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].Play("Shoot");
        }
    }
}
