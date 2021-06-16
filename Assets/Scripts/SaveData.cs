using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;

    public string bestScoreName;
    public int bestScorePoints;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    //private void Start()
    //{
    //    bestScoreName = MainManager.Instance._myName;
    //    bestScorePoints = MainManager.Instance.m_Points;
    //}

    [Serializable]
    class SaveBestScoreData
    {
        public string bestScoreName;
        public int bestScorepoints;
    }

    public void SaveScoreData()
    {
        SaveBestScoreData data = new SaveBestScoreData();
        data.bestScoreName = MainManager.Instance._myName;
        data.bestScorepoints = MainManager.Instance.m_Points;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadScoreData()
    {
        string path = Application.persistentDataPath + "/bestscore.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveBestScoreData data = JsonUtility.FromJson<SaveBestScoreData>(json);

            bestScoreName = data.bestScoreName;
            bestScorePoints = data.bestScorepoints;
        }
    }
}
