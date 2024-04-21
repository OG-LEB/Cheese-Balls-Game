using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using YG;

public class GameController : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private UIController _UIController;
    [SerializeField] private MouthMovement _MouthMovement;
    [SerializeField] private SoundController _SoundController;
    private bool isPause;
    [Header("Location objects")]
    [SerializeField] private GameObject CheeseBall;
    [SerializeField] private Transform SpawnPosition;
    [Space]
    [Header("Settings")]
    [SerializeField] private float ThrowForce;
    private int score = 0;
    private bool isCheeseBallThown;

    private void Start()
    {
        GameAwake();
    }
    public void GameAwake()
    {
        isPause = true;
        CheeseBall.GetComponent<Rigidbody>().isKinematic = true;
        CheeseBall.transform.position = SpawnPosition.position;
        _UIController.OpenMainMenu();
        CheeseBall.SetActive(true);
        _MouthMovement.StopMovement();
        _MouthMovement.ResetPosition();
        score = 0;
        _MouthMovement.Restart();
        isCheeseBallThown = false;
        _UIController.UpdateScore(score);
        _SoundController.StartSoundTrack();
    }
    public void PlayButton()
    {
        _UIController.OpenPlayUI();
        isPause = false;
        _MouthMovement.StartMovement();
    }
    public void GameOver()
    {
        _MouthMovement.StopMovement();
        isPause = true;
        _UIController.GameOver();
        _UIController.UpdateGameOverScore();
        _SoundController.GameOverSoundPlay();
        _SoundController.StopSoundTrack();
    }
    private void Update()
    {
        if (!isPause && !isCheeseBallThown)
        {
            ThrowCheeseBall();
        }
    }
    private void ThrowCheeseBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheeseBall.GetComponent<Rigidbody>().isKinematic = false;
            CheeseBall.GetComponent<Rigidbody>().AddForce(SpawnPosition.forward * ThrowForce, ForceMode.Impulse);
            isCheeseBallThown = true;
            _SoundController.BonkSoundPlay();
        }
    }
    public void HitTarget()
    {
        score++;
        _UIController.UpdateScore(score);
        _MouthMovement.SpeedUp();
        _SoundController.OmnomSound();
    }
    public void RespawnCheeseBall()
    {
        CheeseBall.GetComponent<Rigidbody>().isKinematic = true;
        CheeseBall.transform.position = SpawnPosition.position;
        isCheeseBallThown = false;
    }
    public void GameRestart() 
    {
        GameAwake();
        YandexGame.FullscreenShow();
    }
    public int GetScore() { return score; }
}
