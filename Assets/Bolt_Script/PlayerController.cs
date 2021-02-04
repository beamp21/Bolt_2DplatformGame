using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    private float _baseSpeed = 0;
    private float _mouvementSpeed = 0;
    private GameObject _player;
    private Rigidbody2D _playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();

        //WTF IS THAT?
        _playerRigidBody.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        _baseSpeed = 0;
        if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.RightArrow))
        {
            _baseSpeed = Input.GetAxis("Horizontal");
        }
        _mouvementSpeed = _baseSpeed * Speed;
        _playerRigidBody.velocity = new Vector2(_mouvementSpeed, _player.GetComponent<Rigidbody2D>().velocity.y);

    }
}
