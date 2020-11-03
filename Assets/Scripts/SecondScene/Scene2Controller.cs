using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum StoryState
{
    FirstChoice,
    SneakingInEarly,
    TakingFirstAlienPhoto,
    NotSneakingEarly,
    SecondChoice,
    NotStay,
    Stay
}
public class Scene2Controller : MonoBehaviour
{

    [Header("UI")]
    public GameObject storyUI;
    public GameObject optionUI;
    public Text optionUIBox1Text;
    public Text optionUIBox2Text;
    public Slider suspicionSlider;
    public Slider productionSlider;
    public RawImage BlackScreen;
    public Text storyText;
    public GameObject statusUI;



    [Header("Parameters")]
    public float cameraMoveTime1;
    public float autoNextLineTime;
    public GameObject[] CameraList;
    public GameObject MC;



    [Header("SneakingStaff")]
    public GameObject flashLight;

    private int nextLine = 0;
    private List<string> story = new List<string>();

    private StoryState _currState;

    private void Start()
    {
        GenerateStoryBlock1();
        storyUI.SetActive(true);
        statusUI.SetActive(false);
        optionUI.SetActive(false);
        storyText.fontStyle = FontStyle.BoldAndItalic;
        storyText.text = story[nextLine++].ToString();
        StartCoroutine(WaitForCamMoveAndPrintText(cameraMoveTime1));
        _currState = StoryState.FirstChoice;

    }

    // Update is called once per frame
    void Update() 
    {
        switch (_currState) 
        {
            case StoryState.SneakingInEarly:
                
                //Set State Flag
                _currState = StoryState.TakingFirstAlienPhoto;

                StartCoroutine(SetupSneakingState());
                break;
        }
            


    }

    private void GenerateStoryBlock1()
    {
        story.Add("White House. Before press conference.");
        story.Add("There must be some juicy news somewhere.");
    }


    IEnumerator WaitForCamMoveAndPrintText(float cameraMoveTime)
    {
        yield return new WaitForSeconds(cameraMoveTime);
        storyText.fontStyle = FontStyle.Normal;
        storyText.text = story[nextLine++].ToString();
        yield return new WaitForSeconds(autoNextLineTime);
        storyUI.SetActive(false);
        SetUpFirstChoice();
        optionUI.SetActive(true);
        statusUI.SetActive(true);
    }


    private void SetUpFirstChoice()
    {
        optionUIBox1Text.text = "Staying";
        optionUIBox2Text.text = "Sneaking";
    }



    IEnumerator BlackScreenFadeIn(float FadeSpeed)
    {
        BlackScreen.color = new Color(0, 0, 0, 0);
        BlackScreen.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            BlackScreen.color = new Color(0, 0, 0, BlackScreen.color.a + 0.1f);
            yield return new WaitForSeconds(FadeSpeed);
        }
    }


    IEnumerator BlackScreenFadeOut(float FadeSpeed)
    {
        BlackScreen.color = new Color(0, 0, 0, 1);
        for (int i = 0; i < 10; i++)
        {
            BlackScreen.color = new Color(0, 0, 0, BlackScreen.color.a - 0.1f);
            yield return new WaitForSeconds(FadeSpeed);
        }
        BlackScreen.gameObject.SetActive(false);
    }


    IEnumerator SetupSneakingState()
    {

        // Increase the bar here!


        StartCoroutine(BlackScreenFadeIn(0.05f));
        yield return new WaitForSeconds(0.5f);

        //Reset camera
        SetActiveVirtualCamera(2);


        // WaitForCamToSet
        yield return new WaitForSeconds(2.0f);


        // Hide UI
        HideAllUI();


        StartCoroutine(BlackScreenFadeOut(0.05f));
        yield return new WaitForSeconds(0.5f);


        // WaitFewSecondsAndShootPhoto
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(TakePhotoFlashingEffect(1));
        yield return new WaitForSeconds(3.3f);


        // Text appears
        storyUI.SetActive(true);
        storyText.text = "Great! I bet no one would expect this!";

        yield return new WaitForSeconds(3.0f);
        StartCoroutine(BlackScreenFadeIn(0.05f));
    }


    private void SetActiveVirtualCamera(int index)
    {
        for (int i = 0; i < CameraList.Length; i++)
        {
            if (i == index)
            {
                CameraList[i].SetActive(true);
            }
            else
            {
                CameraList[i].SetActive(false);
            }
        }
    }


    public StoryState GetStoryState()
    {
        return _currState;
    }

    public void SetStoryState(StoryState desiredState)
    {
        _currState = desiredState;
    }


    private void HideAllUI()
    {
        storyUI.SetActive(false);
        statusUI.SetActive(false);
        optionUI.SetActive(false);
    }


    IEnumerator TakePhotoFlashingEffect(int index)
    {
        if(index == 1) {
            flashLight.GetComponent<Light>().intensity = 10;
            yield return new WaitForSeconds(0.7f);
            for(int i=0; i<5; i++)
            {
                flashLight.GetComponent<Light>().intensity = 0;
                yield return new WaitForSeconds(0.05f);
                flashLight.GetComponent<Light>().intensity = 20;
                yield return new WaitForSeconds(0.05f);
            }
            flashLight.GetComponent<Light>().intensity = 0;
        }
    }

}
