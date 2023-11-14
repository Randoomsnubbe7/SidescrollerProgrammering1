using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int AddHealth = 1;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
            if (PlayerScript != null )
            { 
              PlayerScript.HP  += AddHealth;
              AddHealth = 0;
        GameObject.Destroy(gameObject);

            }
    }

}
