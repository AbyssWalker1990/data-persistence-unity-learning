using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName;
        public int BestScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.BestPlayerName = bestPlayerName;
        data.BestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.BestPlayerName;
            bestScore = data.BestScore;
        }
    }
    public static MenuManager Instance;

    public string playerName;

    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SetBestScore(int score, string name)
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestPlayerName = name;
        }

    }
}
