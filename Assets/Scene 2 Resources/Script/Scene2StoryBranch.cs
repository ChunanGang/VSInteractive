using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2StoryBranch : MonoBehaviour
{


    public GameObject MC;
    Animator animator;
    private Scene2Controller _scene2Controller;



    private void Start()
    {
        _scene2Controller = FindObjectOfType<Scene2Controller>().GetComponent<Scene2Controller>();
        animator = MC.GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void Option2()
    {
        //animator.SetBool("isRunning", true);
        Debug.Log("isRunning");
        Debug.Log(animator.GetBool("isRunning"));

        if (_scene2Controller.GetStoryState() == StoryState.FirstChoice)
        {
            _scene2Controller.SetStoryState(StoryState.SneakingInEarly);
        }
        else if(_scene2Controller.GetStoryState() == StoryState.SecondChoice)
        {
            _scene2Controller.SetStoryState(StoryState.Stay);
        }
    }

    public void Option1()
    {
        //animator.SetBool("isWalking", true);
        Debug.Log("isWalking");
        Debug.Log(animator.GetBool("isWalking"));

        if (_scene2Controller.GetStoryState() == StoryState.FirstChoice)
        {
            _scene2Controller.SetStoryState(StoryState.NotSneakingEarly);
        }
        else if(_scene2Controller.GetStoryState() == StoryState.SecondChoice)
        {
            _scene2Controller.SetStoryState(StoryState.NotStay);
        }
    }


}
