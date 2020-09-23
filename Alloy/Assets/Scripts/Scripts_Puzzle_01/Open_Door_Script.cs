using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Door_Script : MonoBehaviour
{
    public GameObject door;

    public bool doorIsOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Stand_On_Button_Script.buttonIsPressed == 2)
        {
            doorIsOpen = true;
        }

        if (doorIsOpen)
        {
            GameObject.Destroy(door);
        }
    }
}
