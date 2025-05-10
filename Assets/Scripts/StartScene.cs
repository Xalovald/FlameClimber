using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Button startButton;

    void Start()
    {

        startButton.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
