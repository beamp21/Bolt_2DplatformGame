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

    private Scene _currentScene;
    // Start is called before the first frame update
    void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
        if(_currentScene.name == "Level1")
        {
            _scene = "Level2";
        }
        else if(_currentScene.name == "Level2")
        {
            _scene = "Level3";
        }
        else if (_currentScene.name == "Level3")
        {
            _scene = "Level4";
        }
        else
        {
            Debug.Log("Gagné");
        }
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
