using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public GameObject bestScoreText;
    public Text ScoreText;
    public Text bestScore;
    public string _myName;

    public GameObject GameOverText;
    
    private bool m_Started = false;
    public int m_Points;
    public static int totalPoints;
    public int saveDataPoints;
    
    private bool m_GameOver = false;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(totalPoints);
        
       

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
                AudioManager.Instance.PlayBallSound();
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
        ScoreText.text = $"Score : {m_Points}";  
    }

    public void GameOver()
    {
        _myName = InputName.Instance.myName;

        m_GameOver = true;
        bestScoreText.SetActive(true);
        GameOverText.SetActive(true);
        //totalPoints = m_Points;
        PrintBestScore();

        if(saveDataPoints > 0)
        {
            SaveData.Instance.SaveScoreData();
        }
        
    }

    public void PrintBestScore()
    {
      
        if (m_Points > totalPoints)
        {
            bestScore.text = $"New Best score: {_myName} {m_Points}";
        }
        else if(m_Points < totalPoints)
        {
            bestScore.text = $"Your score: {_myName} {m_Points}";
        }

        if(m_Points > totalPoints)
        {
            totalPoints = m_Points;
            saveDataPoints = totalPoints;
        }

        
        Debug.Log("SavePoints: " + saveDataPoints);

    }
       
}
