using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    public Camera cameraMain;
    public float crosshairRange;
    public float pickupRange;
    void Update()
    {
        RayCastCheck();
    }
    void RayCastCheck()
    {
        RaycastHit hit;
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 3000, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "IntObj")
            {
                //draw crosshair
            }
            if (hit.distance <= pickupRange)
            {
                //draw pickup crosshair and allow player to pick up object
            }
        }
    }
}
