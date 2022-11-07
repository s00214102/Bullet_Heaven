//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OrbArm_old : MonoBehaviour
//{
//    bool armActive = false;
//    public float armPointOffset = 0.25f;
//    public GameObject PositionOne;
//    public GameObject PositionTwo;
//    public GameObject PositionThree;
//    public GameObject PositionFour;
//    public GameObject PositionFive;

//    OrbController orbControl;

//    Movement_custom_accel movement;

//    PlayerAttack_ver2 attack;

//    public MeterManager meter;
//    public ElementManager elementManager;

//    // Start is called before the first frame update
//    void Start()
//    {
//        orbControl = GetComponent<OrbController>();

//        movement = GetComponentInParent<Movement_custom_accel>();

//        attack = GetComponentInParent<PlayerAttack_ver2>();

//        //SetArmPointPositions();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        EnableArmAbility();

//    }

//    private void EnableArmAbility()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            armActive = true;
//            meter.canRegen = false;
//            ActivateArm();
//        }
//        else if (Input.GetKeyUp(KeyCode.Space))
//        {
//            armActive = false;
//            meter.canRegen = true;
//            DeActivateArm();
//        }
//        ArmMeterCost();
//    }

//    private void ArmMeterCost()
//    {
//        if (Input.GetKey(KeyCode.Space))
//        {
//            if (armActive)
//            {
//                meter.MeterDegeneration(elementManager.currentElement.armMeterCost);
//            }

//            if (meter.IsMeterEmpty())
//            {
//                armActive = false;
//                meter.canRegen = true;
//                DeActivateArm();
//            }
//        }
//    }

//    private void ActivateArm()
//    {
//        orbControl.DespawnAllOrbs();
//        orbControl.SpawnArmOrbs();
//        SetOrbArmTargets();
//        movement.getInput = false;
//        movement.canMove = false;
//        attack.canShoot = false;
//    }
//    private void DeActivateArm()
//    {
//        orbControl.DespawnAllOrbs();
//        orbControl.SpawnInactiveOrbs();
//        movement.getInput = true;
//        movement.canMove = true;
//        attack.canShoot = true;
//    }

//    public void SetOrbArmTargets()
//    {
//        //-set targets based on number of spawned orbs for current element

//        orbControl.orbs[3].GetComponent<OrbFollow>().target = PositionOne.GetComponent<Transform>();
//        orbControl.orbs[2].GetComponent<OrbFollow>().target = PositionTwo.GetComponent<Transform>();
//        orbControl.orbs[1].GetComponent<OrbFollow>().target = PositionThree.GetComponent<Transform>();
//        orbControl.orbs[0].GetComponent<OrbFollow>().target = PositionFour.GetComponent<Transform>();
//    }
//}
