using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerName;

    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        Debug.Log("Awake MainManager");
        Debug.Log("Player Name: " + playerName);
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
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
