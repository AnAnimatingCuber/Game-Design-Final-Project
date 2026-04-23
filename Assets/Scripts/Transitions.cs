using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Transitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void trigger(){
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene(){
          transitionAnim.SetTrigger("endTransition");
          yield return new WaitForSeconds(2f);
          SceneManager.LoadScene(sceneName);
    }

    public void quit(){
        Application.Quit();
    }
}
