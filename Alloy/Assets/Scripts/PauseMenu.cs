using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool gameIsPaused;
    public GameObject menuPopUp;
    public GameObject crosshairUI, timerUI;

    public Button resumeButton;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameIsPaused = false;
        Button btn = resumeButton.GetComponent<Button>();
        btn.onClick.AddListener(ResumeGame);
        btn.onClick.AddListener(BoolIsPaused);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused == false)
        {
            PauseGame();
            gameIsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused == true)
        {
            ResumeGame();
            gameIsPaused = false;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        FindObjectOfType<MouseLook>().mouseSensitivty = 0f;
        menuPopUp.SetActive(true);
        crosshairUI.SetActive(false);
        timerUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<MouseLook>().mouseSensitivty = 100f;
        menuPopUp.SetActive(false);
        crosshairUI.SetActive(true);
        timerUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void BoolIsPaused()
    {
        gameIsPaused = false;
    }
}
