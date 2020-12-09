using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class SpawnIntCube : NetworkBehaviour
{
    public GameObject cube;
    //public Transform spawnPoint;

    void Update()
    {
        if(!isServer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            CmdSpawnCube();   
        }
    }

    [Command]
    public void CmdSpawnCube()
    {
        GameObject go = Instantiate(cube, gameObject.transform);
        NetworkServer.Spawn(go);
    }
}
