using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTop10()
    {

    }

    public void SaveTop10()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ViewTop10()
    {
        SceneManager.LoadScene(2);
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
