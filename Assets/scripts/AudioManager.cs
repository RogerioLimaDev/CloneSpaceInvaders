using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List <AudioClip> audioClips = new List<AudioClip>();
    AudioSource audioSource;
    ActionsController actionsController;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        actionsController = FindAnyObjectByType<ActionsController>();
    }

    void OnEnable()
    {
        actionsController.playExplosionSound += PlayExplosion;
        actionsController.playFireSound += PlayFire;
        actionsController.playInvadersKilledSound += PlayInvadersKilled;
        actionsController.playUfoSound += PlayUfo;
        actionsController.playShipSound += PlayShip;
    }

    void OnDisable()
    {
        actionsController.playExplosionSound -= PlayExplosion;
        actionsController.playFireSound -= PlayFire;
        actionsController.playInvadersKilledSound -= PlayInvadersKilled;
        actionsController.playUfoSound -= PlayUfo;
        actionsController.playShipSound -= PlayShip;
        
    }

    private void PlayShip()
    {
        int selectedClip = (int)AUDIOCLIPS.SHIP;
        PlaySelectedAudioClip(selectedClip);
    }


    private void PlayUfo()
    {
        int selectedClip = (int)AUDIOCLIPS.UFO;
        PlaySelectedAudioClip(selectedClip);
    }


    private void PlayInvadersKilled()
    {
        int selectedClip = (int)AUDIOCLIPS.INVADERLILLED;
        PlaySelectedAudioClip(selectedClip);
    }


    private void PlayFire()
    {
        int selectedClip = (int)AUDIOCLIPS.FIRE;
        PlaySelectedAudioClip(selectedClip);
    }


    private void PlayExplosion()
    {
        int selectedClip = (int)AUDIOCLIPS.EXPLOSION;
        PlaySelectedAudioClip(selectedClip);
    }

    private void PlaySelectedAudioClip(int clip) 
    {
        audioSource.clip = audioClips[clip];
        audioSource.Play();
    }
}

public enum AUDIOCLIPS
{
    SHIP = 0,
    FIRE = 1,
    UFO = 2,
    EXPLOSION = 3,
    INVADERLILLED = 4
}
