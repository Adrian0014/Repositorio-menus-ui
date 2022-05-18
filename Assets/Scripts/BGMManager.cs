using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource _audioSource;

    void Awake()
     {
        //Asignamos la variable
        _audioSource = GetComponent<AudioSource>();
     }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource.Play();
    }

    //Funcion para parar el BMG
    public void StopBGM()
    {
        _audioSource.Stop();
    }
}