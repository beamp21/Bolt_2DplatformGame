using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float Jump = 12f;
    public int Health = 3;
    [SerializeField]
    private int _currentHealth;
    public bool HasKey;
    private bool _hurt;
    private float _baseSpeed;
    private float _mouvementSpeed;
    private GameObject _player;
    private Rigidbody2D _playerRigidBody;
    private Vector3 _flipPlayer;
    private Animator _playerAnimator;
    private RaycastHit2D _playerRaycast;

    public bool previousState = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _currentHealth = Health;
        _baseSpeed = 0;
        _hurt = false;
        _mouvementSpeed = 0;
        HasKey = false;
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _flipPlayer = new Vector3(1,1,1);
        _playerRigidBody.bodyType = RigidbodyType2D.Dynamic;
        _playerAnimator = _player.GetComponent<Animator>();
    }

    /// <summary>
    /// Change player Health regarding the damage value
    /// </summary>
    /// <param name="damage">damage recieve by the player</param>
    public void PlayerHealthDamage(int damage)
    {
        Health = Health - damage;
        _playerAnimator.SetTrigger("Hurt");
        _player.layer = LayerMask.NameToLayer("PlayerInvincible");
    }

    public bool trigger()
    {
        if (_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            Debug.Log("YES");
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        #region STATE
        if (trigger()==true && previousState ==false)
        {
            //_playerAnimator.SetTrigger("Hurt");
            //_player.layer = LayerMask.NameToLayer("PlayerInvincible");
            StartCoroutine(Wait());
        }
        else if(trigger() == false && previousState == true)
        {
            _player.layer = LayerMask.NameToLayer("Player");
            _currentHealth = Health;
            previousState = false;
        }
        #endregion STATE

        #region ***** PLAYER CONTROL ******

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

        if (Input.GetButtonDown("Jump") && _playerGrounded)
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

        #endregion ****** PLAYER CONTROL ******
        
        #region ****** PLAYER DEATH ******
        if(Health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }
        #endregion ****** PLAYER DEATH ******


    }

    /// <summary>
    /// time when the player is invulnerable
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        _currentHealth = Health;
        yield return new WaitForSeconds(1f);
        previousState = true;
    }

}
