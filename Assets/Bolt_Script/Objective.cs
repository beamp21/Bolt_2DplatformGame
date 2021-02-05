using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    [SerializeField]
    private string _scene;
    private string _unlocked;
    private string _level;
    // Start is called before the first frame update
    void Start()
    {
        _scene = "Level2";
        _unlocked = "_Unlocked";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //IL FAUDRA FAIRE UNE SAVE
            //PlayerPrefs.SetString(_level, "true");
            _level = _scene + _unlocked;
            Debug.Log(_level);
            SceneManager.LoadScene(_scene);
        }
    }
}
