using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheker : MonoBehaviour
{
    Player _player;
    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.Find("Idle1").GetComponent<Player>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        _player.isGrounded = true;
        _player._animator.SetBool("Jumping", false);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _player.isGrounded = false;
    }
}