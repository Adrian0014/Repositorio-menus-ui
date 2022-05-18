using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //clip de audio para la muerte de rock
    public AudioClip deathSFX;
    //clip de audio para musica de victori
    public AudioClip victoriaSFX;
    //clip de audio muerte enemy
    public AudioClip enemySFX;
    //clip de audio tocar bandera
    public AudioClip metaSFX;
    //clip de audio conseguir moneda
    public AudioClip jumpSFX;
    //clip de audio golpear
    public AudioClip hitSFX;
    //variable del audio source
    private AudioSource _audioSource;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    public void DeathSound()
    {
        _audioSource.PlayOneShot(deathSFX);
    }

    public void VictoriaMusicSound()
    {
        _audioSource.PlayOneShot(victoriaSFX);
    }

    public void EnemySound()
    {
        _audioSource.PlayOneShot(enemySFX);
    }

    public void MetaSound()
    {
        _audioSource.PlayOneShot(metaSFX);
    }

    public void JumpSound()
    {
        _audioSource.PlayOneShot(jumpSFX);
    }

    public void HitSound()
    {
        _audioSource.PlayOneShot(hitSFX);
    }


   
}
