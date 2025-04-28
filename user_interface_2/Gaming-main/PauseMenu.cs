using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Reference to the pause menu UI
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Pause the game when Escape key is pressed
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void TogglePause()
{
    if (isPaused)
        Resume();
    else
        Pause();
}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);   // Hide the pause menu
        Time.timeScale = 1f;            // Resume the game time
        isPaused = false;               // Update the paused state
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);    // Show the pause menu
        Time.timeScale = 0f;            // Stop the game time
        isPaused = true;                // Update the paused state
    }

}
