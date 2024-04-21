using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource MainSountrack;
    [SerializeField] AudioSource GameOverSound;
    [SerializeField] AudioSource OmNomSound;
    [SerializeField] AudioSource Bonksound;

    public void PlayOmnomSound()
    {
        OmNomSound.Play();
    }
    public void StartSoundTrack()
    {
        MainSountrack.Play();
    }
    public void StopSoundTrack() 
    {
        MainSountrack.Stop();
    }
    public void OmnomSound()
    {
        OmNomSound.Play();
    }
    public void BonkSoundPlay()
    {
        Bonksound.Play();
    }
    public void GameOverSoundPlay() 
    {
        GameOverSound.Play();
    }
}
