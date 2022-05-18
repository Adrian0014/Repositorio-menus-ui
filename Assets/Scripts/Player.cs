using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    float dirx;
    public SpriteRenderer renderer;
    Rigidbody2D _rBody;
    public Animator _animator;
    public Transform attackHitBox;
    public float attackRange;
    public LayerMask enemyLayer;

    private SFXManager sfxManager;
    private BGMManager bgmManager;

    //variable para almacenar cantidad de monedas
    private int monedas;
    //variable para el texto de goombas muertos del canvas
    public Text moneyText;

    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        Debug.Log(dirx);
        if(dirx == -1)
        {
            renderer.flipX = true;
            _animator.SetBool("Run", true);
        }

        else if(dirx == 1)
        {
            renderer.flipX = false;
            _animator.SetBool("Run", true);
        }
        
        else
        {
            _animator.SetBool("Run", false);
        }


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jumping",true);
            sfxManager.JumpSound();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
            _animator.SetBool("Attack2",true);
            sfxManager.HitSound();
        }
    }
    public void Attack()
    {
        Collider2D[] attackedEnemies = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in attackedEnemies)
        {
            Destroy(enemy.gameObject);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirx * speed, _rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Si el objeto que entra en el trigger tiene el tag de Cofre
        if(collider.gameObject.CompareTag("Cofre"))
        {
            Debug.Log("He ganado");
            bgmManager.StopBGM();
            sfxManager.VictoriaMusicSound();
            Invoke("LoadEndScreen", 2.5f);
  
        }

        
        else if(collider.gameObject.CompareTag("Caida"))
        {
            sfxManager.DeathSound();
            Debug.Log("Caiste");
            bgmManager.StopBGM();
            Invoke("LoadDeathScreen", 1);
  
        }

        if(collider.gameObject.CompareTag("Money"))
        {
            Debug.Log("Tengo dinero");
            Destroy(collider.gameObject);
            //sfxManager.CoinSound();
            monedas++;
            moneyText.text = "Money: " + monedas;
            
        }

    }

    /*private void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "Money")
        {
            Debug.Log("Tengo dinero");
            Destroy(hit.gameObject);
            //sfxManager.DeathSound();
            //bgmManager.StopBGM();
            //Invoke("LoadDeathScreen", 1);
            monedas++;
            moneyText.text = "Money: " + monedas;
        }
    }*/



    private void LoadDeathScreen()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void LoadEndScreen()
    {
        SceneManager.LoadScene("LevelComplete");
    }

}

