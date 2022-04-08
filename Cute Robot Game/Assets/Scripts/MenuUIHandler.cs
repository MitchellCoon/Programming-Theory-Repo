using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
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
        SceneManager.LoadScene(1);
    }
    public void SaveRobotClicked()
    {
        MainManager.Instance.SaveRobot();
    }
    public void LoadRobotClicked()
    {
        MainManager.Instance.LoadRobot();
    }
}
