using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class YandexSDK : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void getName();
    
    
}

