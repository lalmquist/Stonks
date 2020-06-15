using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel(string name)
    {
        StartCoroutine(LoadLevel(name));
    }

    IEnumerator LoadLevel(string levelName)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelName);
    }
}
