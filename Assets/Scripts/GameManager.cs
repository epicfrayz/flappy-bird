using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject startMenu;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void Play() {
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
