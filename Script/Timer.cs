using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 0;
    private float starttime;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.timeSinceLevelLoad;
    }
}
