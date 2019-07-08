using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockShiftSound : MonoBehaviour
{
    [SerializeField] AudioClip[] shiftSounds;

    private void Start()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType<BlockShiftSound>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShiftSound()
    {
        AudioSource myAudioSource = GetComponent<AudioSource>();

        int randomClipNumber = new System.Random().Next(0, shiftSounds.Length);
        //myAudioSource.clip = shiftSounds[randomClipNumber];
        if(!myAudioSource.isPlaying)
        {
            myAudioSource.PlayOneShot(shiftSounds[randomClipNumber]);
        }

    }
}
