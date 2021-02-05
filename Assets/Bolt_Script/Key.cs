using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private GameObject _key;
    // Start is called before the first frame update
    void Start()
    {
        _key = GameObject.Find("Key");
        // for some reason we can't just change _player.HasKey
        //we need to attach PlayerController to a PlayerControler Object soo we can't use a find(name) like a gameobject
        //_player = (PlayerController)FindObjectOfType(typeof(PlayerController));
        _player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// when player collide with the key
    /// 1:Set player:HasKey = true
    /// 2: Destroy the Key
    /// </summary>
    /// <param name="collision">What collide with our Key?</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _player.HasKey = true;
            Destroy(_key);
        }
    }
}
