using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuPresenter : MonoBehaviour
{
    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("Start").clicked += () => Debug.Log("Start");
        root.Q<Button>("Settings").clicked += () => Debug.Log("Settings");
        root.Q<Button>("Quit").clicked += () => Debug.Log("Quit");
    }
}
