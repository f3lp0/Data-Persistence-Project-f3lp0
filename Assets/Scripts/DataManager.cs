using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DataManager : MonoBehaviour
{
    // Variables    
    public string playerName;
    
    public TextMeshProUGUI playerNameText;

    public static DataManager Instance;

    // Inicial values
    public string[] players = {"","","","","","","","","","" };
    public int[] scores = {0,0,0,0,0,0,0,0,0,0 };

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

        playerName = playerNameText.text;
        LoadTop10();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //if (scores.Sum() == 0)
        //{
        //    SaveTop10();
        //} else
        //{
        //    LoadTop10();
        //}
        playerName = playerNameText.text;
        LoadTop10();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string[] players;
        public int[] scores;
    }

    public void SaveTop10()
    {
        SaveData data = new SaveData();
        data.players = players;
        data.scores = scores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadTop10()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            players = data.players;
            scores = data.scores;
        }
    }

    public int CheckPlayerScore(string player, int score)
    {
        int place = 10;
        LoadTop10();
        for (int i = 0; i < players.Length; i++)
        {
            if (score > scores[i] && place == 10)
            {
                place = i;
                for (int j = players.Length - 1; j > i; j--)
                {
                    players[j] = players[j - 1];
                    scores[j] = scores[j - 1];
                }
                players[i] = player;
                scores[i] = score;
                SaveTop10();
            }
        }
        return place;
    }
}
