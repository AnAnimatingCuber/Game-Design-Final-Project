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
        if(Input.GetKeyDown(KeyCode.Space)){
           StartCoroutine(loadScene());
        }
    }

    IEnumerator loadScene(){
        transitionAnim.SetTrigger("endTransition");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
