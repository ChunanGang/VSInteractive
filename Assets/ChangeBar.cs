using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBar : MonoBehaviour
{
    public float suspicionVal = 0;
    public float productionVal = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
