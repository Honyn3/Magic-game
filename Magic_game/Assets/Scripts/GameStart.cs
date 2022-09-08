using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public Animator anim;

    public AsyncOperation oper;

    public void StartButton()
    {
        anim.SetTrigger("Jump");
        this.oper = SceneManager.LoadSceneAsync(1);
        this.oper.allowSceneActivation = false;
        StartCoroutine(LoadScene());
        
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        this.oper.allowSceneActivation = true;
    }
}
