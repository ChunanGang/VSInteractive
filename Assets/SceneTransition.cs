using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Transition", 5.0f);
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
