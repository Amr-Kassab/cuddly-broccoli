using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    private float delayTime = 5f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audioo;
 void Start()
{
    audioo = GetComponent<AudioSource>();
}
 void OnCollisionEnter(Collision other)
{
    switch(other.gameObject.tag)
    {
        case "friendly":
            Debug.Log("This object is friendly");
            break;
        case "obstacle":
            startcrashsequences();
            break;
        case "Finish":
            Debug.Log("congrates, yo, you finished!");
            StartSuccessSequences();
            break;
        case "Fuel":
            Debug.Log("you've picked up fuel");
            break;
        default:
            startcrashsequences();
            break;
    }    
}

    private void StartSuccessSequences()
    {
        audioo.PlayOneShot(success);
        GetComponent<Movement>().enabled=false; 
        Invoke("LoadNextLevel", delayTime);
    }

    void ReloadLevel()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

void LoadNextLevel()
{
    int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
    int nextsceneindex = currentsceneindex  + 1;
    if(nextsceneindex == SceneManager.sceneCountInBuildSettings)
    {
        nextsceneindex = 0;
    }
    SceneManager.LoadScene(nextsceneindex);
}

void startcrashsequences()
{
    audioo.PlayOneShot(crash);
    GetComponent<Movement>().enabled=false;
    Invoke("ReloadLevel", delayTime);
}
}
