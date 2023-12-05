using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using System;

[System.Serializable]

public class PlayerInfo {
    public int Coins;
}

public class PlayerController : Sound
{
    
    public PlayerInfo PlayerInfo;
    public PlayerInfo PlayerInfoSave;
    public float speed = 1f;
    public Animator animator;
    public float JumpForce = 5;
    float dead = 0;
    float jump = 0;
    float timer = 0;

    Rigidbody2D rb;
    SpriteRenderer sr;
    public UnityEvent Dead;

    [SerializeField] int coin;
    public TMP_Text coinText;
    public TMP_Text coinTextDead;

    [DllImport("__Internal")]
    private static extern void Save(string date);

    [DllImport("__Internal")]
    private static extern void LoadPlayer();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        float movement = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 6;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 3;
        }

        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.1){
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            PlaySound(sounds[0]);
            jump = 1;
        } 
        if(Input.GetKeyUp(KeyCode.Space)){
            jump = 0;
        }

        animator.SetFloat("Shift", Mathf.Abs(speed));

        animator.SetFloat("Jump", Mathf.Abs(jump));

        animator.SetFloat("HorizontalMove", Mathf.Abs(movement));
        

        sr.flipX = movement < 0 ? true : false; 



        // Debug.Log(run);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Sword"))
        {
            Dead?.Invoke();
            dead++;
            if(dead == 1){
                if(int.Parse(coinTextDead.text) < PlayerInfo.Coins){
                    coinTextDead.text = coinText.text;
                    SaveSDK();
                }
            }
        }

        if(collision.CompareTag("Coin"))
        {
            coin++;
            PlayerInfo.Coins++;
            coinText.text = coin.ToString();
        }

    }

    public void SaveSDK(){
        coinText.text = PlayerInfo.Coins.ToString();
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        Save(jsonString);
    }

    public void ProvSave(string value){
        PlayerInfoSave = JsonUtility.FromJson<PlayerInfo>(value);
        coinTextDead.text = PlayerInfoSave.Coins.ToString();
    }
    

}


