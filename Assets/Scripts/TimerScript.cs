using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    public string loseScene;
    public static TimerScript stuffholder;
    void Awake()
    {
        if (stuffholder != null && stuffholder != this)
        {
            StartCoroutine(lose());
             Destroy(this.gameObject);
            return;
        }
                // Otherwise, set this as the instance
        stuffholder = this;

        // Persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator lose(){
        Debug.Log("Start Timer");
        yield return new WaitForSeconds(600f);
        SceneManager.LoadScene(loseScene);
    }
}
