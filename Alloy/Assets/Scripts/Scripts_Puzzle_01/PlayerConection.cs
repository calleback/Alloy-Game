using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerConection : NetworkBehaviour
{
    public GameObject playerUnitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Is this actually my own local playerConection?
        if (isLocalPlayer == false)
        {
            // This object belongs to another player
            return;
        }

        // Since the PlayerConection is invinsible and not part of the world,
        // give me something physical to move around!

        Debug.Log("PlayerConection: :Start -- Spawning my own personal unit");

        // Instantiate() only creates an object on the LOCAL COMPUTER.
        // Even if it has a NetworkIdentity it will still NOT exist on
        // the network (and therefore not on any other client) UNLSESS
        // NetworkServer.Spawn() is called on this object.

        //Instantiate(playerUnitPrefab);

        // Command the server to SPAWN our unit

        CmdSpawnMyUnit();
    }

    // Update is called once per frame
    void Update()
    {
        // Remember: Update runs on EVERYONE`s computer, whether or not they own this
        // particular player object.

        // How do i verify that i am allowed to mess around with this object?
        if (isLocalPlayer == false)
        {
            return;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // Spacebar was hit -- we could instruct the server
        //    // to do something with our unit.
        //    CmdMoveUnitUp();
        //}
    }

    ////////////////// COMMANDS
    // Commands are special functions that ONLY get executed on the server.

    GameObject myPlayerUnit;

    [Command]
    void CmdSpawnMyUnit()
    {
        // We are garanteed to be on the server right now.
        GameObject go = Instantiate(playerUnitPrefab);

        myPlayerUnit = go;

        go.GetComponent<NetworkIdentity>().AssignClientAuthority( connectionToClient);

        // Now that the object exists on the server, propogate it to all
        // the clients (and also wire up the NetworkIdentity)
        NetworkServer.Spawn(go);
    }

    //[Command]
    //void CmdMoveUnitUp()
    //{
    //    if(myPlayerUnit == null)
    //    {
    //        return;
    //    }

    //    myPlayerUnit.transform.Translate(-1, 1, 0);
    //}
}
