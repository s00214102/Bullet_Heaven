using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera camera;
    public GameObject FireBullet; //Fire bullet prefab
    public GameObject WaterBullet; //Water bullet prefab
    public GameObject EarthBullet; //Earth bullet prefab
    public GameObject ElectricBullet; //Electric bullet prefab
    public GameObject WindBullet; //Electric bullet prefab
    public float BulletSpeed = 50;
    public string FireInput = "Fire1";
    public int BulletChoice = 1; //Variable to decide type of bullet

    Vector3 mousePosition;

    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            BulletChoice++;
        }

        FaceMouseCursor();

        if (Input.GetButtonDown(FireInput))
        {
            if (BulletChoice == 1)
            {
                FireShoot(); //Shoots fire bullet
            }
            else if (BulletChoice == 2)
            {
                WaterShoot(); //Shoots water bullet
            }
            else if (BulletChoice == 3)
            {
                EarthShoot(); //Shoots earth bullet
            }
            else if (BulletChoice == 4)
            {
                ElectricShoot(); //Shoots electric bullet
            }
            else if (BulletChoice == 5)
            {
                WindShoot(); //Shoots Wind bullet
            }
        }

        if (BulletChoice <= 0)
        {
            BulletChoice = 5;
        }
        else if (BulletChoice >= 6)
        {
            BulletChoice = 1;
        }
    }

    private void FaceMouseCursor()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;

        transform.up = direction;
    }

    void FireShoot()
    {
        //spawn the bullet and store the new bullet in a local variable
        GameObject bulletClone = Instantiate(FireBullet, spawnPoint.position, Quaternion.identity);

        //get the rigid body from the new bullet
        Rigidbody2D body = bulletClone.GetComponent<Rigidbody2D>();
        //set the bullet moving in the direction the player is facing 
        body.velocity = transform.up * BulletSpeed;
    }

    void WaterShoot()
    {
        //spawn the bullet and store the new bullet in a local variable
        GameObject bulletClone = Instantiate(WaterBullet, spawnPoint.position, Quaternion.identity);

        //get the rigid body from the new bullet
        Rigidbody2D body = bulletClone.GetComponent<Rigidbody2D>();
        //set the bullet moving in the direction the player is facing 
        body.velocity = transform.up * BulletSpeed;
    }

    void EarthShoot()
    {
        //spawn the bullet and store the new bullet in a local variable
        GameObject bulletClone = Instantiate(EarthBullet, spawnPoint.position, Quaternion.identity);

        //get the rigid body from the new bullet
        Rigidbody2D body = bulletClone.GetComponent<Rigidbody2D>();
        //set the bullet moving in the direction the player is facing 
        body.velocity = transform.up * BulletSpeed;
    }

    void ElectricShoot()
    {
        //spawn the bullet and store the new bullet in a local variable
        GameObject bulletClone = Instantiate(ElectricBullet, spawnPoint.position, Quaternion.identity);

        //get the rigid body from the new bullet
        Rigidbody2D body = bulletClone.GetComponent<Rigidbody2D>();
        //set the bullet moving in the direction the player is facing 
        body.velocity = transform.up * BulletSpeed;
    }

    void WindShoot()
    {
        //spawn the bullet and store the new bullet in a local variable
        GameObject bulletClone = Instantiate(WindBullet, spawnPoint.position, Quaternion.identity);

        //get the rigid body from the new bullet
        Rigidbody2D body = bulletClone.GetComponent<Rigidbody2D>();
        //set the bullet moving in the direction the player is facing 
        body.velocity = transform.up * BulletSpeed;
    }
}
