using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBranch2 : MonoBehaviour
{

    public GameObject pplInLine;
    public Transform MC;
    public Image blackScreen;
    public Text timeText;
    public Animator anim;
    public GameObject mindControlLight;
    public Slider suspicionSlider;
    public Slider productionSlider;

    public static int madeDecision = 0;


    private ChangeBar _changeBar;
    // Start is called before the first frame update
    void Start()
    {

        _changeBar = FindObjectOfType<ChangeBar>();
        productionSlider.value = _changeBar.productionVal / 100;
        suspicionSlider.value = _changeBar.suspicionVal / 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Option1()
    {
        blackScreen.enabled = true;
        timeText.enabled = true;
        StartCoroutine(FadeOut());
        _changeBar.productionVal += 10;
        productionSlider.value = _changeBar.productionVal / 100;
    }

    public void Option2()
    {
        StartCoroutine(MindControl());
        _changeBar.productionVal += 20;
        _changeBar.suspicionVal += 20;
        productionSlider.value = _changeBar.productionVal / 100;
        suspicionSlider.value = _changeBar.suspicionVal / 100;
    }

    IEnumerator MindControl()
    {
        mindControlLight.SetActive(true);
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("mindControl");
        madeDecision = 2;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2f);
        blackScreen.enabled = false;
        timeText.enabled = false;
        // blackScreen.enabled = false;
        pplInLine.SetActive(false);
        MC.position = new Vector3(-4.6f, 1.2f, -4f);
        MC.eulerAngles = new Vector3(0, 10.51f, 0);
        madeDecision = 1;
    }
}
