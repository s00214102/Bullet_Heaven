using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    //public Vector3 OpenPosition;

    Vector2 startingPosition;
    public int Speed;
    public float range = 5f;

    public Sprite unlockedDoorSprite;
    SpriteRenderer s_Renderer;

    public SwitchControl[] switches;
    bool doorUnlocked;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    void Start()
    {
        startingPosition = transform.position;
        s_Renderer = GetComponent <SpriteRenderer>();
    }

    private void Update()
    {
        if (!doorUnlocked)
        {
            CheckSwitches();
        }
    }
    void FixedUpdate()
    {
        if (doorUnlocked){ OpenDoor();}
    }

    void CheckSwitches()
    {
        for (int i = 0; i < switches.Length; i++)
        {
            if (!switches[i].SwitchState)
            {
                return;
            }
        }

        s_Renderer.sprite = unlockedDoorSprite;
        doorUnlocked = true;
    }
    private void OpenDoor()
    {
        if (GetDistance(startingPosition) < range)
        {
            rb.velocity = new Vector2(0, 1) * Speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<DoorControl>().enabled = false;
        }
    }

    float GetDistance(Vector2 target)
    {
        return Vector2.Distance(target, transform.position);
    }
}
