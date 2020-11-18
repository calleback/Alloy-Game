using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class SpawnIntCube : NetworkBehaviour
{
    public GameObject cube;
    public Transform spawnPoint;

    public void Start()
    {
        CmdSpawnCube();
        Debug.Log("CmdSpawnCube");
    }

    [Command]
    public  void CmdSpawnCube()
    {
        GameObject cubeOBJ = Instantiate(cube, spawnPoint);
        NetworkServer.Spawn(cubeOBJ);
    }
}
