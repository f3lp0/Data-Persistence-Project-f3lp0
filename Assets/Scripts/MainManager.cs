using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    //private DataManager dataManager;

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    // Variables across the scenes:
    [SerializeField] string playerName;

    // Top 10 variables:
    private int belongsTop10;
    public Text bestScoreText;
    [SerializeField] string bestPlayer;
    [SerializeField] int bestScore;
    public Text top10Text;
    public GameObject top10Object;

    // Start is called before the first frame update
    void Start()
    {
        playerName = DataManager.Instance.playerName;
        Debug.Log("Hola " + playerName);
        Debug.Log("Hola " + DataManager.Instance.playerNameText.text);

        ScoreText.text = $"Score of {playerName}: {m_Points}";

        DataManager.Instance.LoadTop10();
        bestPlayer = DataManager.Instance.players[0];
        bestScore = DataManager.Instance.scores[0];
        bestScoreText.text = "Best Score: " + bestPlayer + " score: " + bestScore;

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        //ScoreText.text = $"Score of {DataManager.Instance.playerTextUGUI.text}: {m_Points}";
        ScoreText.text = $"Score of {playerName}: {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        belongsTop10 = DataManager.Instance.CheckPlayerScore(playerName, m_Points);
        if (belongsTop10 < 10)
        {
            // Code for congrats
            int actualPlace = belongsTop10 + 1;
            top10Text.text = "Congratulations! You are in the top 10 scores, your place is: " + actualPlace;
            top10Object.SetActive(true);
        }
    }

}
