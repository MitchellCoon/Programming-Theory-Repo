using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject RestartButton;
    public GameObject BackButton;
    public TextMeshProUGUI healthText;
    public void NewRobotSelected(Robot robot)
    {
        MainManager.Instance.robot = robot;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Exit()
    {
        MainManager.Instance.SaveRobot();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
    public void StartNew()
    {
        MainManager.Instance.gameOver = false;
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SaveRobotClicked()
    {
        MainManager.Instance.SaveRobot();
    }
    public void LoadRobotClicked()
    {
        MainManager.Instance.LoadRobot();
    }
    public void DisplayGameOverScreen()
    {
        GameOverText.SetActive(true);
        RestartButton.SetActive(true);
        BackButton.SetActive(true);
    }
    public void UpdateHealth(int health)
    {
        healthText.SetText("Health: " + health);
    }
}
