using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject door;

    public int buttonsToOpenDoor;

    public Transform doorStartPos;
    public Transform doorEndPos;

    public float doorSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float stepDoor = doorSpeed * Time.deltaTime;

        if (ButtonOpening.buttonPresses == buttonsToOpenDoor)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorEndPos.position, stepDoor);
        }
        else
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorStartPos.position, stepDoor);
        }
    }
}
