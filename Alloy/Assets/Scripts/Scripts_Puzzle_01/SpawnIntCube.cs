using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class SpawnIntCube : NetworkBehaviour
{
    public GameObject cube;

    private void Awake()
    {
        InitiateSpawn();
    }

    [ClientRpc]
    void InitiateSpawn()
    {
        NetworkServer.Spawn(gameObject, cube);
    }
}
