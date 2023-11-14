using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    Total
}
public class CharacterController : MonoBehaviour
{
    public CharacterState JumpingState = CharacterState.Airborne;


    public float MovementSpeedPerSecond = 10.0f;
    public float GravitySpeedPerSecond = 160.0f; //Movement Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 3.0f;
    public float JumpMaxHeight = 150.0f;
    private float JumpHeightDelta = 0.0f;






    // Update is called once per frame
    void Update()
    {
        bool isMoving = false;
        //Gravity
        if (isMoving == false) ; //Tells us if character is moving  
        {
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= GravitySpeedPerSecond * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;
                   
        }



        if (transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded; 
        }
        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
        if (JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition; 
            JumpHeightDelta += totalJumpMovementThisFrame;
            if(JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f; 
            }
        }



        //Down
        if (Input.GetKey(KeyCode.S))

        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }


        //Left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            {
                Vector3 characterPosition = transform.position;
                characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
                transform.position = characterPosition;
            }
            if (JumpingState == CharacterState.Airborne)
            {
                Vector3 gravityPosition = transform.position;
                gravityPosition.y -= GravitySpeedPerSecond * Time.deltaTime;
                if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
                transform.position = gravityPosition;

            }
        }
    }
}











