using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Camera mainCamera;

    bool carrying;
    bool canEnableXhair = true;

    GameObject carriedObject;
    public GameObject defaultXhair, lookatXhair, pickupXhair, holdingXhair;

    /*[float distance = how far forward the player holds the picked up item from the camera POV]
      [float smooth = how fast the object follows the player]
      [float pickupRange = how close the player can stand to still pick up the object]
      [float dropDistance = the distance the player can walk from the held object before it drops]*/
    public float distance, smooth, pickupRange, dropDistance;

    // Start is called before the first frame update
    void Start()
    {
        defaultXhair.SetActive(true);
        lookatXhair.SetActive(false);
        pickupXhair.SetActive(false);
        holdingXhair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCheck();

        if (carrying)
        {
            Carry(carriedObject);
            CheckDrop();
        }
        else
        {
            Pickup();
        }
    }

    void Carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }
    void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.distance < pickupRange)
            {
                defaultXhair.SetActive(false);
                lookatXhair.SetActive(false);
                pickupXhair.SetActive(false);
                holdingXhair.SetActive(true);
                canEnableXhair = false;

                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.GetComponent<Rigidbody>().freezeRotation = true;
                    p.GetComponent<Rigidbody>().useGravity = false;          
                }
            }
        }
    }
    void CheckDrop()
    {
        float dist = Vector3.Distance(this.transform.position, carriedObject.transform.position);

        print(dist);

        if (Input.GetKeyDown(KeyCode.E) || dist >= dropDistance)
        {
            DropObject();
        }
    }
    void DropObject()
    {
        canEnableXhair = true;
        defaultXhair.SetActive(true);
        holdingXhair.SetActive(false);
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().freezeRotation = false;
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }
    void CrosshairCheck()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 3000, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "IntObj" && hit.distance > pickupRange && canEnableXhair)
            {
                lookatXhair.SetActive(true);
                pickupXhair.SetActive(false);
            }
            if (hit.transform.tag == "IntObj" && hit.distance < pickupRange && canEnableXhair)
            {
                lookatXhair.SetActive(false);
                pickupXhair.SetActive(true);
            }
            else if (hit.transform.tag != "IntObj")
            {
                lookatXhair.SetActive(false);
                pickupXhair.SetActive(false);
            }
        }
    }
}
