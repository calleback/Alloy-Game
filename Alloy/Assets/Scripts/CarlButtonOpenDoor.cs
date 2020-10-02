using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlButtonOpenDoor : MonoBehaviour
{
    public GameObject button;
    public GameObject door;

    public Transform doorFinalPos;
    public Transform doorStartingPos;

    public Transform buttonStartPos;
    public Transform buttonEndPos;

    public float doorSpeed = 3f;
    public float buttonSpeed = 1f;

    bool buttonIsPressed;
  
    void Update()
    {
        float stepDoor = doorSpeed * Time.deltaTime;
        float stepButton = buttonSpeed * Time.deltaTime;
        if (buttonIsPressed)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorFinalPos.position, stepDoor);
            button.transform.position = Vector3.MoveTowards(button.transform.position, buttonEndPos.position, stepButton);
        }
        if (!buttonIsPressed)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorStartingPos.position, stepDoor);
            button.transform.position = Vector3.MoveTowards(button.transform.position, buttonStartPos.position, stepButton);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !buttonIsPressed)
        {
            buttonIsPressed = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && buttonIsPressed)
        {
            buttonIsPressed = false;
        }
    }

}
