using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoomba : MonoBehaviour
{
      public Rigidbody2D myRigidBody = null;



    public float MovementSpeedperSecond = 10.0f;
    public float MovementSign = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0;

        characterVelocity += MovementSign*MovementSpeedperSecond * transform.right.normalized;
        myRigidBody.velocity = characterVelocity;
    }
}
