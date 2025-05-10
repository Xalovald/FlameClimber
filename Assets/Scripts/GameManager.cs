using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public void TriggerGameOver(int coinCount, float timeSurvived)
    {
        if (!isGameOver)
        {
            isGameOver = true;
            PlayerPrefs.SetInt("FinalCoins", coinCount);
            PlayerPrefs.SetFloat("SurvivalTime", timeSurvived);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
