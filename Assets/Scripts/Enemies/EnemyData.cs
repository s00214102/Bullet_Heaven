using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public bool canMove = true;
    public bool canAttack = true;

    public float moveSpeed;
    [HideInInspector] public float defaultMoveSpeed = 3;

    public float bulletDamage = 10;
    public float bulletFireRate = 2;
    public float bulletSpeed = 5;
    [HideInInspector] public float defaultBulletSpeed = 10;
}
