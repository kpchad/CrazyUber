using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 2f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //keep music going into scenes
    }

    // Use this for initialization
    void Start () {
        Invoke("LoadFirstScene", levelLoadDelay);
	}

    private void LoadFirstScene() {
        print("load first scene");
        SceneManager.LoadScene(1);
    }
}
