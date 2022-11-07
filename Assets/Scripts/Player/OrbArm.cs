using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbArm : MonoBehaviour
{
    bool armActive = false;
    public float armPointOffset = 0.25f;

    public Transform[] armPositions;

    OrbController orbControl;
    Movement_custom_accel movement;
    PlayerAttack_ver2 attack;
    public MeterManager meter;
    public ElementManager elementManager;

    // Start is called before the first frame update
    void Start()
    {
        orbControl = GetComponent<OrbController>();

        movement = GetComponentInParent<Movement_custom_accel>();

        attack = GetComponentInParent<PlayerAttack_ver2>();

        //SetArmPointPositions();
    }

    // Update is called once per frame
    void Update()
    {
        EnableArmAbility();
        ArmMeterCost();
    }

    private void EnableArmAbility()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)&&(orbControl.OrbCheck()))
        {
            armActive = true;
            meter.canRegen = false;
            ActivateArm();
            orbControl.SetOrbsElement();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Space))
        {
            DeActivateArm();
        }
    }

    private void ArmMeterCost()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (armActive)
            {
                meter.MeterDegeneration(elementManager.currentElement.armMeterCost);
            }

            if (meter.MeterIsEmpty())
            {
                armActive = false;
                meter.canRegen = true;
                DeActivateArm();
            }
        }
    }

    private void ActivateArm()
    {
        orbControl.DespawnAllOrbs();
        orbControl.SpawnArmOrbs();
        orbControl.SetOrbsMeterManager();
        SetOrbArmTargets();
        movement.getInput = false;
        movement.canMove = false;
        attack.canShoot = false;
    }
    private void DeActivateArm()
    {
        //orbControl.DespawnAllOrbs();
        //orbControl.SpawnInactiveOrbs();
        //-trying to use swap orb instead
        orbControl.SwapToNewOrb(elementManager.currentElement.inactiveOrbPrefab);
        orbControl.SetOrbTrailTargets();
        armActive = false;
        meter.canRegen = true;
        movement.getInput = true;
        movement.canMove = true;
        attack.canShoot = true;
    }

    public void SetOrbArmTargets()
    {
        //-set targets based on number of spawned orbs for current element
        for (int i = 0; i < elementManager.currentElement.startingOrbs; i++)
        {
            //Instantiate(orb, transform.position, Quaternion.identity);
            orbControl.orbs[i].GetComponent<OrbFollow>().target = armPositions[i];
        }
        //orbControl.orbs[3].GetComponent<OrbFollow>().target = PositionOne.GetComponent<Transform>();
        //orbControl.orbs[2].GetComponent<OrbFollow>().target = PositionTwo.GetComponent<Transform>();
        //orbControl.orbs[1].GetComponent<OrbFollow>().target = PositionThree.GetComponent<Transform>();
        //orbControl.orbs[0].GetComponent<OrbFollow>().target = PositionFour.GetComponent<Transform>();
    }
}
