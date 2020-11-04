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
    private ChangeBar _changeBar;
    public Slider suspicionSlider;
    public Slider productionSlider;


    private void Start()
    {
        _changeBar = FindObjectOfType<ChangeBar>();
        productionSlider.value = _changeBar.productionVal / 100;
        suspicionSlider.value = _changeBar.suspicionVal / 100;
        _scene2Controller = FindObjectOfType<Scene2Controller>().GetComponent<Scene2Controller>();
        animator = MC.GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void Option2()
    {
        //animator.SetBool("isRunning", true);
        //Debug.Log("isRunning");
        //Debug.Log(animator.GetBool("isRunning"));

        if (_scene2Controller.GetStoryState() == StoryState.FirstChoice)
        {
            _scene2Controller.SetStoryState(StoryState.SneakingInEarly);
            _changeBar.productionVal += 25;
            _changeBar.suspicionVal += 30;
            suspicionSlider.value = _changeBar.suspicionVal / 100;
            productionSlider.value = _changeBar.productionVal / 100;
        }
        else if(_scene2Controller.GetStoryState() == StoryState.SecondChoice)
        {
            _scene2Controller.SetStoryState(StoryState.Stay);
            _changeBar.productionVal += 25;
            _changeBar.suspicionVal += 30;
            suspicionSlider.value = _changeBar.suspicionVal / 100;
            productionSlider.value = _changeBar.productionVal / 100;
        }
    }

    public void Option1()
    {
        //animator.SetBool("isWalking", true);
        //Debug.Log("isWalking");
        //Debug.Log(animator.GetBool("isWalking"));

        if (_scene2Controller.GetStoryState() == StoryState.FirstChoice)
        {
            _scene2Controller.SetStoryState(StoryState.NotSneakingEarly);
            _changeBar.productionVal += 15;
        }
        else if(_scene2Controller.GetStoryState() == StoryState.SecondChoice)
        {
            _scene2Controller.SetStoryState(StoryState.NotStay);
            _changeBar.productionVal += 15;
        }
    }


}
