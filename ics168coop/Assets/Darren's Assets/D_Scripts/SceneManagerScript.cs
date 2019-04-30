using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private bool isPaused = false;
    private bool isGameOver = false;
    public GameObject PauseCanvas;
    public GameObject GameOverCanvas;
    public GameObject WinText;

    private int maxStages;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (PauseCanvas == null || GameOverCanvas == null || WinText == null) return;
        PauseCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        maxStages = SceneManager.sceneCountInBuildSettings;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver && PauseCanvas != null)
        {
            PauseOrResume();
        }
        if (WinText!=null && WinText.GetComponent<Canvas>().enabled)
        {
            Time.timeScale = 0.1f;
            StartCoroutine( HoldUntilNext() );
        }
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % maxStages);
    }
    public void loadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseOrResume()
    {
        try
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            PauseCanvas.SetActive(isPaused);
        }
        catch
        {
            Debug.Log("Esc No Work");
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            GameOverCanvas.SetActive(true);
            isGameOver = true;
            Time.timeScale = 0;
        }
    }

    private IEnumerator HoldUntilNext()
    {
        yield return new WaitForSeconds( 0.3f );
        loadNextScene();
    }
}
