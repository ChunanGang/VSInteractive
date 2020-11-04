using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum StoryState
{
    WaitForPlayerInput,
    FirstScene,
    FirstChoice,
    SneakingInEarly,
    TakingFirstAlienPhoto,
    NotSneakingEarly,
    DialogBeforeSecondChoice,
    SecondChoice,
    NotStay,
    Stay,
    End
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


    [Header("FirstScene")]
    public GameObject DirectorCam;


    [Header("SneakingStaff")]
    public GameObject flashLight;
    public GameObject flashLight2;
    public GameObject alienBackyard;
    public GameObject presidentHimSelf;
    public GameObject alienInRoom;

    [Header("StayingDialog")]
    public GameObject dialogBackground;
    public GameObject workers;
    public AudioSource backgroundNoise;
    public GameObject sunLight;

    private int nextLine = 0;
    private List<string> story = new List<string>();

    private StoryState _currState;
    private int mouseEventIndex;


    private void Start()
    {
        mouseEventIndex = 0;
        GenerateStoryBlock1();
        storyUI.SetActive(true);
        statusUI.SetActive(false);
        optionUI.SetActive(false);
        storyText.fontStyle = FontStyle.BoldAndItalic;
        storyText.text = story[nextLine++].ToString();
        _currState = StoryState.WaitForPlayerInput;

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


            case StoryState.NotSneakingEarly:

                optionUI.SetActive(false);
                statusUI.SetActive(false);
                //storyUI.SetActive(true);
                //storyText.text = "......";
                storyUI.SetActive(false);
                _currState = StoryState.DialogBeforeSecondChoice;
                StartCoroutine(StayAndListenDialog());
                break;


            case StoryState.NotStay:

                _currState = StoryState.End;


                //GONEXTSCENE
                SceneManager.LoadScene("Transition2TO3");

                break;


            case StoryState.Stay:
                _currState = StoryState.End;
                StartCoroutine(LastSceneToSeeAlien());
                break;


            case StoryState.WaitForPlayerInput:
                if(Input.GetMouseButtonDown(0))
                {

                    // First sentence, WhiteHouse .....
                    if(mouseEventIndex == 0)
                    {
                        mouseEventIndex++;
                        _currState = StoryState.FirstScene;
                        StartCoroutine(WaitForCamMoveAndPrintText(cameraMoveTime1));

                    }

                    // Second sentence, juciy news .....
                    else if (mouseEventIndex == 1)
                    {
                        mouseEventIndex++;
                        FirstMouseEvent();
                    }

                    // For early sneak in, Oh no the flashlight
                    else if (mouseEventIndex == 2)
                    {
                        storyText.text = "I forgot to shut it off!";
                        mouseEventIndex++;
                    }

                    // I forgot to turn it off
                    else if (mouseEventIndex == 3)
                    {
                        storyText.text = "At least I still got the scoop.";
                        mouseEventIndex = 99;
                    }

                    // President talks to an Alien
                    else if(mouseEventIndex == 99)
                    {
                        storyText.text = "The president's visitor is an alien? My boss is going to love this!";
                        mouseEventIndex = 4;
                    }

                    // But this is a great photo
                    else if (mouseEventIndex == 4)
                    {
                        //StartCoroutine(BlackScreenFadeIn(0.05f));
                        // GONEXTSCENE
                        _currState = StoryState.NotSneakingEarly;

                    }

                    // In the middle of the press the ...
                    else if(mouseEventIndex == 50)
                    {
                        backgroundNoise.Stop();
                        //sunLight.GetComponent<Light>().color = new Color(0.97f,0.8f,0.3f, 1.0f);
                        sunLight.transform.rotation = new Quaternion(0.83256495f, -0.255243957f, -0.0428712703f, 0.489742935f);
                        _currState = StoryState.DialogBeforeSecondChoice;
                        StartCoroutine(StayAndListenDialog2());
                    }

                    // That is a pretty plain conference
                    else if(mouseEventIndex == 51)
                    {
                        storyText.text = "Will this impress my boss?";
                        mouseEventIndex++;
                    }

                    // Will the boss be happy about this
                    else if(mouseEventIndex == 52)
                    {
                        storyText.text = "Maybe I should try for something more interesting.";
                        mouseEventIndex++;
                    }

                    // Maybe I should try harder?
                    else if(mouseEventIndex == 53)
                    {
                        optionUIBox1Text.text = "Leave";
                        optionUIBox2Text.text = "Go Invisible";
                        storyUI.SetActive(false);
                        optionUI.SetActive(true);
                        statusUI.SetActive(true);
                        _currState = StoryState.SecondChoice;
                    }


                    // Oh man! No one would believe this
                    else if(mouseEventIndex == 70)
                    {
                        storyText.text = "What a great shot to impress my boss!";
                        mouseEventIndex++;
                    }

                    // Boss would be happy about this
                    else if(mouseEventIndex == 71)
                    {
                        StartCoroutine(BlackScreenFadeIn(0.05f));
                        // GONEXTSCENE
                        SceneManager.LoadScene("Transition2TO3");
                    }
                }

                break;
        }
            


    }


    IEnumerator LastSceneToSeeAlien()
    {
        StartCoroutine(BlackScreenFadeIn(0.05f));
        yield return new WaitForSeconds(0.5f);

        //Reset camera
        SetActiveVirtualCamera(3);


        // WaitForCamToSet
        yield return new WaitForSeconds(2.0f);


        // Hide UI
        HideAllUI();


        StartCoroutine(BlackScreenFadeOut(0.05f));
        yield return new WaitForSeconds(0.5f);

        /*
                // WaitFewSecondsAndShootPhoto
                yield return new WaitForSeconds(3.0f);
                StartCoroutine(TakePhotoFlashingEffect(2));
                yield return new WaitForSeconds(3.3f);*/

        yield return new WaitForSeconds(3.0f);
        alienBackyard.GetComponent<Animator>().SetBool("startWalking", true);

        yield return new WaitForSeconds(30.0f);

        // Text appears
        storyUI.SetActive(true);
        storyText.text = "Oh, man! My boss is not gonna believe this! A real spaceship!";

        mouseEventIndex = 70;
        _currState = StoryState.WaitForPlayerInput;

        //yield return new WaitForSeconds(3.0f);
        //StartCoroutine(BlackScreenFadeIn(0.05f));
    }



    IEnumerator StayAndListenDialog()
    {
        //Bring up the black screen
        StartCoroutine(BlackScreenFadeIn(0.05f));
        yield return new WaitForSeconds(0.5f);
        storyUI.SetActive(false);

        dialogBackground.SetActive(true);
        SetActiveVirtualCamera(1);

        StartCoroutine(BlackScreenFadeOut(0.005f));
        yield return new WaitForSeconds(0.05f);


        yield return new WaitForSeconds(1.0f);


        // Bring up some noise/sound here
        storyText.text = "......";
        storyUI.SetActive(true);
        backgroundNoise.Play();

        mouseEventIndex = 50;
        _currState = StoryState.WaitForPlayerInput;
        // the length of it is according to the sound length
        //yield return new WaitForSeconds(2.0f);
    }

    IEnumerator StayAndListenDialog2() { 
        // Prepare to get out of the black scene
        storyUI.SetActive(false);
        StartCoroutine(BlackScreenFadeIn(0.005f));
        yield return new WaitForSeconds(0.05f);
        dialogBackground.SetActive(false);
        workers.SetActive(false);
        StartCoroutine(BlackScreenFadeOut(0.05f));
        yield return new WaitForSeconds(0.5f);




        // Dialog after the press conference
        yield return new WaitForSeconds(1.0f);
        storyText.text = "That was a pretty boring conference.";
        storyUI.SetActive(true);

        mouseEventIndex = 51;
        _currState = StoryState.WaitForPlayerInput;

/*        yield return new WaitForSeconds(2.0f);
        yield return new WaitForSeconds(2.0f);
        yield return new WaitForSeconds(2.0f);
        optionUIBox1Text.text = "Leaving";
        optionUIBox2Text.text = "Sneaking";
        storyUI.SetActive(false);
        optionUI.SetActive(true);
        statusUI.SetActive(true);
        _currState = StoryState.SecondChoice;*/
    }

  


    private void GenerateStoryBlock1()
    {
        story.Add("-=[White House, Before Press Conference]=-");
        story.Add("There must be some juicy news somewhere.");
    }


    IEnumerator WaitForCamMoveAndPrintText(float cameraMoveTime)
    {
        SetActiveVirtualCamera(1);
        //DirectorCam.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds(cameraMoveTime);
        storyText.fontStyle = FontStyle.Normal;
        storyText.text = story[nextLine++].ToString();
        //yield return new WaitForSeconds(autoNextLineTime);
        _currState = StoryState.WaitForPlayerInput;

    }


    private void FirstMouseEvent()
    {
        storyUI.SetActive(false);
        SetUpFirstChoice();
        optionUI.SetActive(true);
        statusUI.SetActive(true);
        _currState = StoryState.FirstChoice;

    }


    private void SetUpFirstChoice()
    {
        optionUIBox1Text.text = "Attend Conference";
        optionUIBox2Text.text = "Go Invisible";
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

        alienInRoom.GetComponent<Animator>().SetBool("isLooking", true);
        presidentHimSelf.transform.rotation = Quaternion.Euler(new Vector3(0, 163.246f, 0));
        presidentHimSelf.GetComponent<Animator>().SetBool("isLooking", true);

        yield return new WaitForSeconds(1.0f);

        // Text appears
        storyUI.SetActive(true);
        storyText.text = "Oh, shoot. The flash!";

        mouseEventIndex = 2;
        _currState = StoryState.WaitForPlayerInput;
/*        yield return new WaitForSeconds(3.0f);
        StartCoroutine(BlackScreenFadeIn(0.05f));*/


        // Go Next Scene maybe?
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
        if(index == 1) 
        {
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
        else if(index == 2)
        {
            flashLight2.GetComponent<Light>().intensity = 10;
            yield return new WaitForSeconds(0.7f);
            for (int i = 0; i < 5; i++)
            {
                flashLight2.GetComponent<Light>().intensity = 0;
                yield return new WaitForSeconds(0.05f);
                flashLight2.GetComponent<Light>().intensity = 100;
                yield return new WaitForSeconds(0.05f);
            }
            flashLight2.GetComponent<Light>().intensity = 0;
        }
    }


    IEnumerator SneakingFirstToActualPress()
    {
        StartCoroutine(BlackScreenFadeIn(0.05f));
        yield return new WaitForSeconds(0.5f);

        //backgroundNoise.Stop();
        //sunLight.GetComponent<Light>().color = new Color(0.97f, 0.8f, 0.3f, 1.0f);
        sunLight.transform.rotation = new Quaternion(0.83256495f, -0.255243957f, -0.0428712703f, 0.489742935f);
        _currState = StoryState.DialogBeforeSecondChoice;
        StartCoroutine(StayAndListenDialog2());
    }

}
