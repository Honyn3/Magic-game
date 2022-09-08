using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public Animator anim;

    public void StartButton()
    {
        anim.SetTrigger("Jump");
    }
}
