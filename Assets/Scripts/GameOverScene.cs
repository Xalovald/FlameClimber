using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScene : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI timeText;
    public Button retryButton;

    void Start()
    {
        int coins = PlayerPrefs.GetInt("FinalCoins", 0);
        float time = PlayerPrefs.GetFloat("SurvivalTime", 0f);

        coinsText.text = "Coins collected : " + coins;
        timeText.text = "Time survived : " + time.ToString("0.0") + "s";

        retryButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("PlayScene"); 
    }
}
