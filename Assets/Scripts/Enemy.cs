using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    //variable para controlar la velocidad del goomba
    public float movementSpeed = 4.5f;
    //variable para saber en que direccion se mueve en el eje x
    private int directionX = 1;
    //variable para almacenar el rigidbody del enemigo
    private Rigidbody2D rigidBody;
  
    //variable para saber si el goomba esta muerto
    public bool isAlive = true;

    float dirx;

    private SFXManager sfxManager;
    private BGMManager bgmManager;

    

    public SpriteRenderer renderer;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }
    


    void FixedUpdate()
    {
        if(isAlive)
        {
            //añade celocidad en el eje x
            rigidBody.velocity = new Vector2(directionX * movementSpeed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }

        
    }



    private void OnCollisionEnter2D(Collision2D hit)
    {
        //si detecta colision con un objeto con tag Pared
        if(hit.gameObject.tag == "Pared" || hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "Caida") 
        {
            Debug.Log("me he chocado");
            
            //si nos movemos a la derecha cambiara la direccion de movimiento a la izquierda
            if(directionX == 1)
            {
                directionX = -1;
                renderer.flipX = true;
            }
            //si nos movemos a la izquierda la cambia a la derecha
            else
            {
                directionX = 1;
                renderer.flipX = false;
            }

        }
        //si choca con el mario lo destruye
        else if(hit.gameObject.tag == "MuereRock")
        {
            Destroy(hit.gameObject);
            sfxManager.DeathSound();
            bgmManager.StopBGM();
            Invoke("LoadDeathScreen", 1);
        }
        
    }

    private void LoadDeathScreen()
    {
        SceneManager.LoadScene("GameOver");
    }
}
