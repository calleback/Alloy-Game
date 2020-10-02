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
        //sets the float for the opening speeds.
        float stepDoor = doorSpeed * Time.deltaTime;
        float stepButton = buttonSpeed * Time.deltaTime;

        //if button is pressed, opening animation plays.
        if (buttonIsPressed)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorFinalPos.position, stepDoor);
            button.transform.position = Vector3.MoveTowards(button.transform.position, buttonEndPos.position, stepButton);
        }
        //if button is not pressed, return door and button to original position
        if (!buttonIsPressed)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorStartingPos.position, stepDoor);
            button.transform.position = Vector3.MoveTowards(button.transform.position, buttonStartPos.position, stepButton);
        }
    }
    //if the player touches the button buttonIsPressed bool is set to true
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
