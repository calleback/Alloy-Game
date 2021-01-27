using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera mainCamera;

    public GameObject lever;

    float interactDist = 3f;

    bool leverIsActive;

    public GameObject defaultXhair, lookatXhair, inRangeXhair;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCheck();
        InteractObj();
    }
    void InteractObj()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.distance < interactDist)
            {
                {
                    if (hit.transform.tag == "IntLever")
                    {
                        if (leverIsActive)
                        {
                            ReturnSwitch();
                            leverIsActive = false;
                        }
                        else if (!leverIsActive)
                        {
                            FlipSwitch();
                            leverIsActive = true;
                        }
                    }
                }
            }
        }
    }
    void FlipSwitch()
    {
        lever.transform.rotation = Quaternion.Euler(-30, 0, 0);
    }
    void ReturnSwitch()
    {
        lever.transform.rotation = Quaternion.Euler(30, 0, 0);
    }
    void CrosshairCheck()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 3000, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "IntLever" && hit.distance > interactDist)
            {
                lookatXhair.SetActive(true);
                inRangeXhair.SetActive(false);
            }
            if (hit.transform.tag == "IntLever" && hit.distance < interactDist)
            {
                lookatXhair.SetActive(false);
                inRangeXhair.SetActive(true);
            }
            else if (hit.transform.tag != "IntLever")
            {
                lookatXhair.SetActive(false);
                inRangeXhair.SetActive(false);
            }
        }
    }
}
