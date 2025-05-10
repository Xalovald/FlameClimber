using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public void TriggerGameOver(int coinCount, float timeSurvived)
    {
        if (isGameOver) return;

        if (coinCount >= 10)
        {
            isGameOver = true;
            PlayerPrefs.SetFloat("SurvivalTime", timeSurvived);
            PlayerPrefs.Save();
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            isGameOver = true;
            PlayerPrefs.SetInt("FinalCoins", coinCount);
            PlayerPrefs.SetFloat("SurvivalTime", timeSurvived);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
