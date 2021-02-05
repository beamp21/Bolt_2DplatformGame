using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float Jump = 12f;
    public bool HasKey;
    private float _baseSpeed;
    private float _mouvementSpeed;
    private GameObject _player;
    private Rigidbody2D _playerRigidBody;
    private Vector3 _flipPlayer;
    private Animator _playerAnimator;
    private RaycastHit2D _playerRaycast;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _baseSpeed = 0;
        _mouvementSpeed = 0;
        HasKey = false;
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _flipPlayer = new Vector3(1,1,1);
        _playerRigidBody.bodyType = RigidbodyType2D.Dynamic;
        _playerAnimator = _player.GetComponent<Animator>();
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
        _playerRaycast = Physics2D.CircleCast(_player.transform.position, 0.3f, new Vector2(0, -1), 1.1f, LayerMask.GetMask("Platforms"));
        bool _playerGrounded = _playerRaycast.collider != null ? true : false;
        if(Input.GetButtonDown("Jump") && _playerGrounded)
        {
            //Add instant force to Y for the jump
            _playerRigidBody.AddForce(new Vector2(0,Jump), ForceMode2D.Impulse);
        }
        _mouvementSpeed = _baseSpeed * Speed;
        _playerRigidBody.velocity = new Vector2(_mouvementSpeed, _player.GetComponent<Rigidbody2D>().velocity.y);

        // condition ? valeur si vrai : valeur si faux;
        _flipPlayer.x = _mouvementSpeed < 0 ? -1 : 1;
        if (_mouvementSpeed != 0)
        {
            _player.transform.localScale = _flipPlayer;
        }
        _playerAnimator.SetFloat("Speed", Mathf.Abs(_mouvementSpeed));
        _playerAnimator.SetBool("Grounded", _playerGrounded);
    }
}
