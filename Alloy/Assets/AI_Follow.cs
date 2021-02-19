using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Follow : MonoBehaviour
{
    Transform player;

    Vector3 playerTransform;

    private bool chasePlayer;

    double chasePlayerRange = 100;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        chasePlayer = false;

        gameObject.GetComponent<NavMeshAgent>().speed = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) < chasePlayerRange)
        {
            chasePlayer = true;
        }
        if (Vector3.Distance(player.position, transform.position) > chasePlayerRange)
        {
            chasePlayer = false;
        }
    }
    private void Update()
    {
        if (chasePlayer == true)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
    }
}
