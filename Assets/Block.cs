using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Block : MonoBehaviour
{

    public Vector2 Dimensions = new Vector2(16.0f, 16.0f);
    public Vector2 LowerLeftCorner = new Vector2();
    // Start is called before the first frame update
    public static bool CheckCollision(Block aObject, Block aObject2)
    {
        if (aObject.LowerLeftCorner.x < aObject2.LowerLeftCorner.x + aObject2.Dimensions.x &&
         aObject.LowerLeftCorner.x + aObject2.LowerLeftCorner.x > aObject2.Dimensions.x &&
         aObject.LowerLeftCorner.y < aObject2.LowerLeftCorner.y + aObject2.Dimensions.y &&
         aObject.LowerLeftCorner.y + aObject2.LowerLeftCorner.y < aObject2.LowerLeftCorner.y)
        {

            return true;
        }
        return false;
            
                                                              
    }

    // Update is called once per frame
    void Update()
    {
        LowerLeftCorner = new Vector2(transform.position.x - (Dimensions.x * 0.5f),
            transform.position.y - (Dimensions.y * 0 - 5f));

        
    }
}
