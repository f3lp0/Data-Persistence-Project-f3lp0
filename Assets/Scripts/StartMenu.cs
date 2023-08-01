using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    // Variables
    public TextMeshProUGUI playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    public void StartNew()
    {
        if (playerNameText.text == "Write your name here ...")
        {
            DataManager.Instance.playerName = "unknown";
        }
        else
        {
            DataManager.Instance.playerName = playerNameText.text;
        }
        Debug.Log("The player's name is: " + DataManager.Instance.playerName);
        SceneManager.LoadScene(1);
    }

    public void ViewTop10()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
