using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;

public class PhysicsCharacterController : MonoBehaviour
{
    public Rigidbody2D myRigidBody = null;
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
        Vector3 characterPosition = myRigidBody.velocity;
        characterPosition.x = 0.0f;
        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
        if (JumpingState == CharacterState.Jumping)
        {
            


            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }



        //Down
        if (Input.GetKey(KeyCode.S))

        {

            characterPosition.y -= MovementSpeedPerSecond;
            transform.position = characterPosition;
        }


        //Left
        if (Input.GetKey(KeyCode.A))
        {

            characterPosition.x -= MovementSpeedPerSecond;
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {


            characterPosition.x += MovementSpeedPerSecond;


        }
        myRigidBody.velocity = characterPosition;

        if (JumpingState == CharacterState.Airborne)
        {
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= GravitySpeedPerSecond * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;

        }
    }
}















