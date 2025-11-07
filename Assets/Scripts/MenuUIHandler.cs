using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField playerInput;
    public void StartNew()
    {
        string playerName = playerInput.text;

        MenuManager.Instance.SetPlayerName(playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }

    private void Start()
    {
        bestScoreText.text = "Best Score: " + MenuManager.Instance.bestPlayerName + " : " + MenuManager.Instance.bestScore;
    }
}
