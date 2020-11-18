using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GrabMultiplayer : NetworkBehaviour
{
    public Camera mainCamera;

    bool carrying;
    bool canEnableXhair = true;

    GameObject carriedObject;
    public GameObject defaultXhair;
    public GameObject pickupXhair;
    public GameObject holdingXhair;

    public float distance, smooth, pickupRange, dropDistance;

    // Start is called before the first frame update
    void Start()
    {
        defaultXhair.SetActive(false);
        pickupXhair.SetActive(false);
        holdingXhair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCheck();

        if (carrying)
        {
            CmdCarry(carriedObject);
            CheckDrop();
        }
        else
        {
            Pickup();
        }
    }

    [Command]
    void CmdCarry(GameObject o)
    {
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        carriedObject.GetComponent<Rigidbody>().freezeRotation = true;
        carriedObject.GetComponent<Rigidbody>().useGravity = false;
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
                pickupXhair.SetActive(false);
                holdingXhair.SetActive(true);
                canEnableXhair = false;

                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    //p.GetComponent<Rigidbody>().freezeRotation = true;
                    //p.GetComponent<Rigidbody>().useGravity = false;
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
        }
    }
}

