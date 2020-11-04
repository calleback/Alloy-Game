using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Camera mainCamera;

    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
    void CheckDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropObject();
        }
    }
    void DropObject()
    {
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }
}
