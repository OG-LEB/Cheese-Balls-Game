using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //Wins
    [Header("Links")]
    [SerializeField] private GameController gameController;
    [Header("ui elements")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject PlayWin;
    [SerializeField] private GameObject GameOverUI;
    [Space]
    [Header("ui elements")]
    [SerializeField] private TextMeshProUGUI ScoreTest;
    [SerializeField] private TextMeshProUGUI GameOverScoreText;

    private void Start()
    {
        OpenMainMenu();
    }
    public void OpenMainMenu() 
    {
        MainMenu.SetActive(true);
        PlayWin.SetActive(false);
        GameOverUI.SetActive(false);
    }
    public void OpenPlayUI() 
    {
        MainMenu.SetActive(false);
        PlayWin.SetActive(true);
    }
    public void GameOver() 
    {
        MainMenu.SetActive(false);
        PlayWin.SetActive(false);
        GameOverUI.SetActive(true);
    }
    public void UpdateScore(int value) 
    {
        ScoreTest.text = $"Очки: {value}";
    }
    public void UpdateGameOverScore()
    {
     GameOverScoreText.text =  $"Очки: { gameController.GetScore().ToString()}";
    }
}
