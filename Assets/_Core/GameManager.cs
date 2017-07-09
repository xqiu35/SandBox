using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode { Test, Prod }

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static GameMode gameMode = GameMode.Test;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        initPrivates();
    }

    void initPrivates()
    {
    }

    public static string getSceneName()
    {
        Scene scene = SceneManager.GetActiveScene();
        return scene.name;
    }

    public static void loadScene(string senceName)
    {
        SceneManager.LoadScene(senceName);
    }

    public static GameMode getGameMode()
    {
        return gameMode;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Logger.log("loadSence: " + scene.name);
    }
}
