using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Player;
using UnityEngine;

public class ShowTop10 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1;
    [SerializeField] TextMeshProUGUI player2;
    [SerializeField] TextMeshProUGUI player3;
    [SerializeField] TextMeshProUGUI player4;
    [SerializeField] TextMeshProUGUI player5;
    [SerializeField] TextMeshProUGUI player6;
    [SerializeField] TextMeshProUGUI player7;
    [SerializeField] TextMeshProUGUI player8;
    [SerializeField] TextMeshProUGUI player9;
    [SerializeField] TextMeshProUGUI player10;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadTop10();
        
        string[] players = DataManager.Instance.players;
        int[] scores = DataManager.Instance.scores;
        
        player1.text = players[0] + " score: " + scores[0];
        player2.text = players[1] + " score: " + scores[1];
        player3.text = players[2] + " score: " + scores[2];
        player4.text = players[3] + " score: " + scores[3];
        player5.text = players[4] + " score: " + scores[4];
        player6.text = players[5] + " score: " + scores[5];
        player7.text = players[6] + " score: " + scores[6];
        player8.text = players[7] + " score: " + scores[7];
        player9.text = players[8] + " score: " + scores[8];
        player10.text = players[9] + " score: " + scores[9];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
