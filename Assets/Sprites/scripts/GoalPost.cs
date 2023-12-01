using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{


    public SceneLoader mySceneLoader = null;
    public string NextScene = "MainMenu";



    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (PlayerScript != null)
        {
            if(mySceneLoader != null)
            {
                mySceneLoader.LoadScene(NextScene);

            }
        }

    }
}
// Update is called once per frame


