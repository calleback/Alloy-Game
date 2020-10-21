using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastTest : MonoBehaviour
{
    public Camera cameraMain;
    public float pickupRange;

    //används inte än
    private float fadeRate = 1f;
    private Image image;
    private float targetAlpha;

    public GameObject defaultXhair;
    public GameObject pickupXhair;

    void Start()
    {
        
    }
    private void Update()
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
            if (hit.transform.tag == "IntObj" && hit.distance > pickupRange)
            {
                defaultXhair.SetActive(true);
                pickupXhair.SetActive(false);
            }
            if (hit.transform.tag == "IntObj" && hit.distance < pickupRange)
            {
                defaultXhair.SetActive(false);
                pickupXhair.SetActive(true);
            }
            else if (hit.transform.tag != "IntObj")
            {
                defaultXhair.SetActive(false);
                pickupXhair.SetActive(false);
            }
        }
    }
}
