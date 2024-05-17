using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource inGameAudioSource;
    [SerializeField] private AudioSource finishGameAudioSource;

    [SerializeField] private AudioClip cardFlipSound;
    [SerializeField] private AudioClip cardMatchSound;
    [SerializeField] private AudioClip cardMisMatchSound;
    [SerializeField] private AudioClip gameFinishSound;

    public void PlayCardFlipSound()
    {
        inGameAudioSource.PlayOneShot(cardFlipSound);
    }

    public void PlayCardMatchSound()
    {
        inGameAudioSource.PlayOneShot(cardMatchSound);
    }

    public void PlayCardMisMatchSound()
    {
        inGameAudioSource.PlayOneShot(cardMisMatchSound);
    }

    public void PlayGameFinishSound()
    {
        finishGameAudioSource.PlayOneShot(gameFinishSound);
    }
}
