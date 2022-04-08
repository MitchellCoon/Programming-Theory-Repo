using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance {get; private set;}
    private bool m_GameOver = false;
    public bool gameOver
    {
        get{return m_GameOver;}
        set{m_GameOver = value;}
    }
    public Robot robot;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    class SaveData
    {
        public Robot robot;
    }
    public void SaveRobot()
    {
        SaveData data = new SaveData();
        data.robot = robot;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadRobot()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            robot = data.robot;
        }
    }
    public void GameOver()
    {
        m_GameOver = true;
    }
}
