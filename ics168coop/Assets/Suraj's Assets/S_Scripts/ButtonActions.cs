using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public GameObject instructions;

    public void CloseGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenInstructions()
    {
        instructions.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructions.SetActive(false);
    }
}
