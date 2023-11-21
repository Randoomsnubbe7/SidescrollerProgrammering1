using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool IsPlayer = false;
    public int AddHealth = 1;


    public int DamageValue = -1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayer)
        {




            var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
            if (PlayerScript != null)
            {
                PlayerScript.TakeDamage(DamageValue);


            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
