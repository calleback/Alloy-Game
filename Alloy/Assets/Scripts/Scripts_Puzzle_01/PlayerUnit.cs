using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

// A PlayerUnit is a unit controlled by a player
// this could be a character in an FPS or a scout in a TBS

public class PlayerUnit : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This function runs on ALL PlayerUnits -- not just the ones that i own.


        //// How do i verify that i am allowed to mess around with this object?
        //if (isLocalPlayer == false)
        //{
        //    return;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // Spacebar was hit -- we could instruct the server
        //    // to do something with our unit.
        //}
    }
}
