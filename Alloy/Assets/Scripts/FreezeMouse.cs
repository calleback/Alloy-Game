using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMouse : MonoBehaviour
{
    public bool isFrozen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isFrozen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 0;
            isFrozen = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isFrozen)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;
            isFrozen = false;
        }
    }
}
