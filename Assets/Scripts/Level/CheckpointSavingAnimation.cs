using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSavingAnimation : MonoBehaviour
{
    public void EndOfAnimation()
    {
        GetComponentInParent<CheckPoint>().FinishedSaving();
    }
}
