using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject door;

    public int buttonsToOpenDoor;

    public Transform doorStartPos;
    public Transform doorEndPos;

    public bool isOrange;
    public bool isBlue;

    public float doorSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float stepDoor = doorSpeed * Time.deltaTime;

        if (isBlue && ButtonOpening.bluePresses == buttonsToOpenDoor)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorEndPos.position, stepDoor);
        }
        else if (isBlue && ButtonOpening.bluePresses != buttonsToOpenDoor)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorStartPos.position, stepDoor);
        }
        if (isOrange && ButtonOpening.orangePresses == buttonsToOpenDoor)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorEndPos.position, stepDoor);
        }
        else if (isOrange && ButtonOpening.orangePresses != buttonsToOpenDoor)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorStartPos.position, stepDoor);
        }
    }
}
