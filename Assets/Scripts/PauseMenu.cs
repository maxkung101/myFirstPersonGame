using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private PlayerControls controls;

    public static bool GameIsPaused;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        GameIsPaused = false;
        controls = new PlayerControls();

        controls.Gameplay.Pause.performed += ctx => StartPause();
        controls.Gameplay.Jump.performed += ctx => BackHome();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void StartPause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Resume()
    {
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }

    private void Pause()
    {
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        GameIsPaused = true;
    }

    public void BackHome()
    {
        if (GameIsPaused)
        {
            AudioListener.pause = false;
            Time.timeScale = 1f;
            GameIsPaused = false;
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
