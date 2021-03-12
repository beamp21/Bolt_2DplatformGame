using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class HUDRow : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private int _playerHealth;
    public Sprite HeartFull;
    public Sprite HeartEmpty;
    public List<GameObject> Hearts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        HeartFull = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/HUD/HudHeartFull.png");
        HeartEmpty = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/HUD/HudHeartEmpty.png");
        foreach(Transform child in transform)
        {
            if(child.name.Contains("Heart"))
            {
                Hearts.Add(child.gameObject);
            }
        }
        _player = GameObject.Find("Player");
        _playerHealth = _player.GetComponent<PlayerController>().Health;
    }

    // Update is called once per frame
    void Update()
    {
        _playerHealth = _player.GetComponent<PlayerController>().Health;
        foreach (GameObject heart in Hearts)
        {
            heart.GetComponent<Image>().sprite = _playerHealth > Hearts.IndexOf(heart) ? HeartFull : HeartEmpty;
        }
    }
}
