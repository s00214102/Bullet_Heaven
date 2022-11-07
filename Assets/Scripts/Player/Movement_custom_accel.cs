using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_custom_accel : MonoBehaviour
{
    //-first just get horizontal and vertical inputs
    //--now might be a good time to look into the new unity input system

    public float defaultSpeed = 200;
    float currentSpeed;
    [SerializeField]float runSpeed = 300;

    public bool rawInput = false;
    public bool normalize = false;
    public bool printInput = false;
    public bool rounded = false;

    public bool canMove = true;
    public bool getInput = true;

    public Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private void Start()
    {
        currentSpeed = defaultSpeed;
    }
    private void FixedUpdate()
    {
        PlayerInput();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(currentSpeed != runSpeed)
            {
                currentSpeed = runSpeed;
            }
        }
        else
        { if (currentSpeed != defaultSpeed) { currentSpeed = defaultSpeed; } }
    }

    private void PlayerInput()
    {
        float inputX;
        float inputY;

        if (rawInput)
        {
            //-get input from axis and store as floats
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");
        }
        else
        {
            //-get input from axis and store as floats
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
        }
        if (rounded)
        {
            inputX = Mathf.Round(inputX);
            inputY = Mathf.Round(inputY);
        }

        //-use floats to make a new vector 2 to be used later for velocity/direction
        Vector2 inputVector = new Vector2(inputX, inputY);

        if (printInput)
        {
            PrintDirectionalInputs(inputVector);
        }
        if (normalize)
        {
            inputVector.Normalize();
        }

        //if (inputVector != Vector2.zero)
        //{
        //    rb.transform.up = inputVector;
        //}

        if (canMove == true)
        {
            Movement(inputVector);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void Movement(Vector2 inputVector)
    {
        rb.velocity = (inputVector * currentSpeed * Time.deltaTime);
    }

    void PrintDirectionalInputs(Vector2 direction)
    {
        print(direction);

    }


}
