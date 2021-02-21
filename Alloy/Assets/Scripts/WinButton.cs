using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinButton : MonoBehaviour
{
    public GameObject winMenu;
    public Image timerBackground;
    public Text winTimer;

    private void Awake()
    {
        timerBackground.canvasRenderer.SetAlpha(0);
        winTimer.canvasRenderer.SetAlpha(0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timerBackground.canvasRenderer.SetAlpha(1);
            winTimer.canvasRenderer.SetAlpha(1);
            Time.timeScale = 0f;
            FindObjectOfType<MouseLook>().mouseSensitivty = 0f;
            winMenu.SetActive(true);
            //crosshairUI.SetActive(false);
            //timerUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
