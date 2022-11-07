using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivation : MonoBehaviour
{
    //used to enable/disable certain player classes
    //for saving in a checkpoint etc..

    PlayerAttack_ver2 attack;
    Movement_custom_accel move;
    MeterManager meter;
    PlayerCollisions collisions;
    PlayerHealthManager health; //dont disable this for the checkpoint saving, since you will heal while saving
    OrbController orbControl;
    OrbArm orbArm;

}
