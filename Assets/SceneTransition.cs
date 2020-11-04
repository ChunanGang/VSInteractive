using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneName;
    public float sceneLength = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Transition", sceneLength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Transition()
    {
        SceneManager.LoadScene(sceneName);
    }
}
