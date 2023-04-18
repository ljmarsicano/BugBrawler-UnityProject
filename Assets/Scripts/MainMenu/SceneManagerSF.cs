using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SceneManagerSF : MonoBehaviour
{
    public static SceneManagerSF instance;
    public static SceneManagerSF.Scene savedScene;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        savedScene = SceneManagerSF.Scene.MainMenu;
    }

    public enum Scene
    {
        MainMenu,
        MainStageRand,
        GameOver,
        LevelSelect,
        Tutorial,
        Stage1
    }


    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewRandGame()
    {
        SceneManager.LoadScene(Scene.MainStageRand.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(Scene.Tutorial.ToString());
    }

    public void LoadSaved()
    {
        SceneManager.LoadScene(savedScene.ToString());
    }

    public void SaveScene(Scene scene)
    {
        savedScene = scene;
    }

    public void debugReportSaved()
    {
        Debug.Log(savedScene.ToString());
    }

}
