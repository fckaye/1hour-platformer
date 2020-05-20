using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlowController : MonoBehaviour
{
    public GameObject UIPanel;
    public Text gameOverText;

    void Start()
    {
        UIPanel.SetActive(false);    
    }

    public void PlayerWin()
    {
        UIPanel.SetActive(true);
        gameOverText.text = "YOU WIN";
    }

    public void PlayerLose()
    {
        UIPanel.SetActive(true);
        gameOverText.text = "YOU LOSE";
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
