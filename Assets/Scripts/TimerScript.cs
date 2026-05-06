using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    public string loseScene;
    void Awake()
    {
        StartCoroutine(lose());
    }

    IEnumerator lose(){
        Debug.Log("Start Timer");
        yield return new WaitForSeconds(600f);
        SceneManager.LoadScene(loseScene);
    }
}
