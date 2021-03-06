﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBranch : MonoBehaviour
{
    public GameObject MC;
    CharacterController cc;
    Animator animator;
    public Slider suspicionSlider;
    public Slider producionSlider;

    private float runSpeed = 12f;
    private float walkSpeed = 1f;
    private float producctionBarIncrement = 0f;
    private float suspicionBarIncrement = 0f;
    private bool walking;
    private bool running;
    private ChangeBar _changeBar;
    private bool secondScene;

    private void Start()
    {
        _changeBar = FindObjectOfType<ChangeBar>();
        animator = MC.GetComponent<Animator>();
        cc = MC.GetComponent<CharacterController>();
        // float susVal = GameObject.Find("singletonVal").GetComponent

        suspicionSlider.value = 0;
        producionSlider.value = 0.2f;

    }

    private void Update()
    {
        secondScene = ToShopping.secondScene;
        if (!secondScene)
        {
            if (walking)
            {
                cc.Move(new Vector3(0, 0, -walkSpeed * Time.deltaTime));
            }
            if (running)
            {
                cc.Move(new Vector3(0, 0, -runSpeed * Time.deltaTime));
            }
            suspicionSlider.value += (suspicionBarIncrement * Time.deltaTime);
            producionSlider.value += (producctionBarIncrement * Time.deltaTime);
            _changeBar.suspicionVal = suspicionSlider.value * 100;
            _changeBar.productionVal = producionSlider.value * 100;
        }
        else
        {
            Debug.Log("true");
            animator.SetBool("toShop", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }

    public void Option1()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
        walking = true;
        running = false;
        suspicionBarIncrement = -0.005f;
        producctionBarIncrement = -0.005f;
    }

    public void Option2()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isWalking", false);
        running = true;
        walking = false;
        suspicionBarIncrement = 0.018f;
        producctionBarIncrement = 0.008f;
    }


}
