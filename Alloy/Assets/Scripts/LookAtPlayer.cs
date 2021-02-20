using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform player;
    private void Start()
    {
        player = GameObject.Find("FirstPersonCharacter").transform;
    }
    void Update()
    {
        transform.LookAt(player);
    }
}
