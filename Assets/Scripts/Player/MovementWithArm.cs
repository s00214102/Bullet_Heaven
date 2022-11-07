using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithArm : MonoBehaviour
{
    //-first just get horizontal and vertical inputs
    //--now might be a good time to look into the new unity input system

    public float speed = 10;

    public bool rawInput = false;
    public bool normalize = false;
    public bool printInput = false;
    public bool rounded = false;

    public bool canMove = true;

    public Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private void FixedUpdate()
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
            //-print so i can see what im working with
            PrintDirectionalInputs(inputVector);
        }

        if (normalize)
        {
            //-normalize 
            //inputVector = inputVector.normalized;
            inputVector.Normalize();
        }

        if (inputVector != Vector2.zero)
        {
            //-either 45 angle or only X or only Y
            //if(Mathf.Abs(inputVector.x) > 0.5 && Mathf.Abs(inputVector.y) > 0.5 || Mathf.Abs(inputVector.x) == 1 && Mathf.Abs(inputVector.y) == 0 || Mathf.Abs(inputVector.x) == 0 && Mathf.Abs(inputVector.y) == 1)
            //{
            //    rb.transform.up = inputVector;
            //}

            rb.transform.up = inputVector;

            ////-cardinal directions
            //else if(Mathf.Abs(inputVector.x) == 1 && Mathf.Abs(inputVector.y) == 0)
            //{
            //    rb.transform.up = inputVector;
            //}
            //else if (Mathf.Abs(inputVector.x) == 0 && Mathf.Abs(inputVector.y) == 1)
            //{
            //    rb.transform.up = inputVector;
            //}
        }

        //-setting the transform.up to the input vector works somewhat
        //-i can move the player in circle just fine, but when i release the stick (input = (0,0) the transform.up resets

        //rb.velocity = inputVector * speed * Time.deltaTime;

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
        rb.AddForce(inputVector * speed * Time.deltaTime, ForceMode2D.Force);
    }

    void PrintDirectionalInputs(Vector2 direction)
    {
        print(direction);

    }


}
