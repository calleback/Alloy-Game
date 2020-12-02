using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpening : MonoBehaviour
{
    public GameObject button;

    public Transform buttonStartPos;
    public Transform buttonEndPos;

    public float buttonSpeed = 1f;

    bool buttonIsPressed;

    public bool groupBlue;
    public bool groupOrange;

    //public static float buttonPresses = 0;
    public static float bluePresses = 0;
    public static float orangePresses = 0;

    void Update()
    {
        //sets the float for the opening speeds.
        float stepButton = buttonSpeed * Time.deltaTime;

        //if button is pressed, opening animation plays.
        if (buttonIsPressed)
        {
            button.transform.position = Vector3.MoveTowards(button.transform.position, buttonEndPos.position, stepButton);
        }
        //if button is not pressed, return door and button to original position
        if (!buttonIsPressed)
        {
            button.transform.position = Vector3.MoveTowards(button.transform.position, buttonStartPos.position, stepButton);
        }
    }
    //if the player touches the button buttonIsPressed bool is set to true
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !buttonIsPressed || other.tag == "IntObj" && !buttonIsPressed)
        {
            if (groupBlue)
            {
                buttonIsPressed = true;
                bluePresses++;
            }
            if (groupOrange)
            {
                buttonIsPressed = true;
                orangePresses++;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && buttonIsPressed || other.tag == "IntObj" && buttonIsPressed)
        {
            if (groupBlue)
            {
                buttonIsPressed = false;
                bluePresses--;
            }
            if (groupOrange)
            {
                buttonIsPressed = false;
                orangePresses--;
            }
        }
    }

}
