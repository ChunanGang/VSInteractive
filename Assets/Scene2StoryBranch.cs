using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2StoryBranch : MonoBehaviour
{
    public GameObject MC;
    Animator animator;
    public Slider suspicionSlider;
    public Slider producionSlider;

    private void Start()
    {
        animator = MC.GetComponent<Animator>();
    }
    public void Option2()
    {
        //animator.SetBool("isRunning", true);
        Debug.Log("isRunning");
        Debug.Log(animator.GetBool("isRunning"));
    }

    public void Option1()
    {
        //animator.SetBool("isWalking", true);
        Debug.Log("isWalking");
        Debug.Log(animator.GetBool("isWalking"));
    }
}
