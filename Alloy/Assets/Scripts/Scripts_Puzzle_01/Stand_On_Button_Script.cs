using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand_On_Button_Script : MonoBehaviour
{
    public static int buttonIsPressed;
    private bool buttonIsPressedBool = false;

    // Start is called before the first frame update
    void Start()
    {
        buttonIsPressed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && buttonIsPressedBool == false)
        {
            buttonIsPressed += 1;
            buttonIsPressedBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && buttonIsPressedBool == true)
        {
            buttonIsPressed -= 1;
            buttonIsPressedBool = false;
        }
    }
}
