using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    // Variables    
    [SerializeField] private string playerName;
    
    public TextMeshProUGUI playerTextUGUI;

    public static DataManager Instance;

    // Singleton
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
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerName = playerTextUGUI.text;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
    }

    public void SaveTop10()
    {

    }

    public void LoadTop10()
    {

    }
}
