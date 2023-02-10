using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuPresenter : MonoBehaviour
{
    [SerializeField]
    SceneOrganizer _sceneOrganizer;

    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("MM_PlayGame").clicked += () => PlayGame();
        root.Q<Button>("MM_Settings").clicked += () => Settings();
        root.Q<Button>("MM_Quit").clicked += () => Quit();
    }

    void Start()
    {
        _sceneOrganizer = SceneOrganizer.instance;
    }

    void PlayGame()
    {
        Debug.Log("Play");
        _sceneOrganizer.LoadNextScene();
    }

    void Settings()
    {
        Debug.Log("Settings");
    }

    void Quit()
    {
        Debug.Log("Quit");
    }
}
