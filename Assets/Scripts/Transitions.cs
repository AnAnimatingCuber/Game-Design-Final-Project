using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Transitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    public string loseScene;
    public GameObject startScreen;
    public GameObject instructionsScreen;
    public GameObject timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void trigger(){
        DontDestroyOnLoad(Instantiate(timer));
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene(){
          transitionAnim.SetTrigger("endTransition");
          yield return new WaitForSeconds(.5f);
          SceneManager.LoadScene(sceneName);
    }


    public void quit(){
        Application.Quit();
    }

    public void instructions(){
        startScreen.SetActive(false);
        instructionsScreen.SetActive(true);
    }

    public void back(){
        instructionsScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
