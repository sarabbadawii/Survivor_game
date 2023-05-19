using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI;

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level01");
    }
    public void Exit()
    {
        SceneManager.LoadScene("StartScene");
    }
}
