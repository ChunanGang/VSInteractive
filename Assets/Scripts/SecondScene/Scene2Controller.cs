using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2Controller : MonoBehaviour
{

    public GameObject storyUI;
    public GameObject optionUI;
    public Text optionUIBox1Text;
    public Text optionUIBox2Text;
    public GameObject statusUI;
    public float cameraMoveTime1;
    public float autoNextLineTime;
    public Text storyText;

    private int nextLine = 0;
    private List<string> story = new List<string>();


    private void Start()
    {
        GenerateStoryBlock1();
        storyUI.SetActive(true);
        statusUI.SetActive(false);
        optionUI.SetActive(false);
        storyText.fontStyle = FontStyle.BoldAndItalic;
        storyText.text = story[nextLine++].ToString();
        StartCoroutine(WaitForCamMoveAndPrintText(cameraMoveTime1));

    }

    // Update is called once per frame
    void Update() 
    {
        /*try
        {
            if (nextLine == 12)
            {
                storyUI.SetActive(false);
                optionUI.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                storyText.text = story[nextLine].ToString();
                nextLine += 1;
            }
        }
        catch
        {
        }*/

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

}
