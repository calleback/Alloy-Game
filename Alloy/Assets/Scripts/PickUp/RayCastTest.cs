using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayCastTest : MonoBehaviour
{
    public Camera cameraMain;
    public float pickupRange;

    public Transform rightHand;

    bool isHoldingItem = false;
    bool canEnableXhair = true;

    //används inte än
    private float fadeRate = 1f;
    private Image image;
    private float targetAlpha;

    public GameObject defaultXhair;
    public GameObject pickupXhair;

    private GameObject tempObj;

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
            if (hit.transform.tag == "IntObj" && hit.distance > pickupRange && canEnableXhair)
            {
                defaultXhair.SetActive(true);
                pickupXhair.SetActive(false);
            }
            if (hit.transform.tag == "IntObj" && hit.distance < pickupRange && canEnableXhair)
            {
                defaultXhair.SetActive(false);
                pickupXhair.SetActive(true);
            }
            else if (hit.transform.tag != "IntObj")
            {
                defaultXhair.SetActive(false);
                pickupXhair.SetActive(false);
            }
            if (hit.transform.tag == "IntObj" && hit.distance < pickupRange && Input.GetKeyDown(KeyCode.Mouse0) && !isHoldingItem)
            {
                defaultXhair.SetActive(false);
                pickupXhair.SetActive(false);
                // ^(Precaution to fix a small bug)

                tempObj = hit.transform.gameObject;

                hit.transform.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.GetComponent<Rigidbody>().freezeRotation = true;
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.position = rightHand.position;
                hit.transform.parent = GameObject.Find("HoldObject").transform;

                canEnableXhair = false;
                isHoldingItem = true;
            }
            // Change to GetKeyDown (KEY) If you dont want to drop item when letting go of button
            if (Input.GetKeyUp(KeyCode.Mouse0) && isHoldingItem)
            {
                tempObj.transform.parent = null;
                tempObj.GetComponent<Rigidbody>().useGravity = true;
                tempObj.GetComponent<Rigidbody>().freezeRotation = false;
                tempObj.GetComponent<Rigidbody>().isKinematic = false;

                canEnableXhair = true;
                isHoldingItem = false;
            }
        }
    }
}
