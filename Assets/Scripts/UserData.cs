using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData Instance;

    public string UserName;
    public int BestScore;
    public string BestScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }


    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.userName = BestScoreName;
        data.userScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.userScore;
            BestScoreName = data.userName;
        }
        else
        {
            BestScore = 0;
            BestScoreName = "User";
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int userScore;
    }
}
