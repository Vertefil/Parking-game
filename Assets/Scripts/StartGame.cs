using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static bool IsGameStarted = false;
    public GameObject Logo, PlayImage, CountMoves, GameOver, WinGameImg,ShopImage;
    private bool IsLoseGame = false, IsWinGame = false;
    private CarController ct;
    //Функция которая запускает игру, скрывает интерфейс
    public void PlayGame()
    {
        if (!IsLoseGame && !IsWinGame)
        {
            IsGameStarted = true;
            Logo.SetActive(false);
            PlayImage.SetActive(false);
            CountMoves.SetActive(true);
            GameOver.SetActive(false);
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        IsWinGame = true;
        IsGameStarted = false;
        Logo.SetActive(true);
        PlayImage.SetActive(true);
        WinGameImg.SetActive(true);
        CountMoves.SetActive(false);
        ShopImage.SetActive(true);
        PlayerPrefs.SetInt("Game Level", PlayerPrefs.GetInt("Game Level") + 1);
    }

    public void LoseGame()
    {
        IsLoseGame = true;
        IsGameStarted = false;
        Logo.SetActive(false);
        PlayImage.SetActive(true);
        CountMoves.SetActive(false);
        GameOver.SetActive(true);
        ShopImage.SetActive(true);
    }
}
