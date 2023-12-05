using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text nameText;
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void getName();

    [DllImport("__Internal")]
    private static extern void Load();

    void Update(){
        LoadTime();
    }

    private void LoadTime(){
        if(Time.timeSinceLevelLoad = 5){
            Load();
        }
    }
    
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCoin(string value){
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        coinText.text = PlayerInfo.Coins.ToString();
    }

}
