using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Door : MonoBehaviour
{
    private PlayerController _player;
    private GameObject _door;
    public Sprite DoorOpen;
    //[MenuItem("AssetDatabase/LoadDoorSprite")]
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _door = GameObject.Find("Door");
        //Allow to load assets from an other folder than RESOURCCES!
        DoorOpen = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Environment/DoorOpen.png");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && _player.HasKey)
        {
            _door.GetComponent<BoxCollider2D>().enabled = false;
            _door.GetComponent<SpriteRenderer>().sprite = DoorOpen;
        }
    }
}
