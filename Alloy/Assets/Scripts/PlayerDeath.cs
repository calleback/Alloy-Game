using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Transform player;
    private void Start()
    {
        player = GameObject.Find("FirstPersonCharacter").transform;
    }
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            FindObjectOfType<MouseLook>().mouseSensitivty = 100f;
        }
    }
}
