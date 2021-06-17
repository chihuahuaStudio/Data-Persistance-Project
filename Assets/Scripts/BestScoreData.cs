using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BestScoreData : MonoBehaviour
{
    public Text bestScore;

    private void Start()
    {
        SaveData.Instance.LoadScoreData();
        bestScore.text = $"Best score by: {SaveData.Instance.bestScoreName} {SaveData.Instance.bestScorePoints}";
    }

    public void DeleteBestScore()
    {
        bestScore.text = "";
    }

}
