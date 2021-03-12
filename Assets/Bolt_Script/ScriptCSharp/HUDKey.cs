using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class HUDKey : MonoBehaviour
{
    private SpriteRenderer _hudKeySprite;
    [SerializeField]
    private GameObject _sceneKey;
    [SerializeField]
    private PlayerController _scenePlayer;
    [SerializeField]
    private GameObject _hudKey;

    public Sprite Keyfull;
    public Sprite KeyEmpty;
    // Start is called before the first frame update
    void Start()
    {
        _hudKey = this.gameObject;
        Keyfull = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/HUD/HudKeyFull.png");
        KeyEmpty = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/HUD/HudKeyEmpty.png");
        _scenePlayer = FindObjectOfType<PlayerController>();
        _sceneKey = GameObject.FindGameObjectWithTag("Key");
        if(_sceneKey == null)
        {
            _hudKey.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _hudKey.GetComponent<Image>().sprite = _scenePlayer.HasKey ? Keyfull : KeyEmpty;
    }
}
