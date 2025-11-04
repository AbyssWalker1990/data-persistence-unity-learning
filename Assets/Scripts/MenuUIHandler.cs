using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerInput;
    public void StartNew()
    {
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
        MainManager.Instance.playerName = playerInput.text;
    }
}
