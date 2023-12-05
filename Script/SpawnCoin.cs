using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float RandX;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    float nextSpawn = 0.0f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.timeSinceLevelLoad > nextSpawn)
        {
            TimeSpawn();
            nextSpawn = Time.timeSinceLevelLoad + spawnRate;
            RandX = Random.Range(-8.07f, 8.07f);
            whereToSpawn = new Vector2(RandX, transform.position.y);
            Instantiate(obj, whereToSpawn, Quaternion.identity);
        }
    }

    public void TimeSpawn(){
        if(Time.timeSinceLevelLoad > 30){
            spawnRate = 1f;
        }
        if(Time.timeSinceLevelLoad > 60){
            spawnRate = 0.8f;
        }
        if(Time.timeSinceLevelLoad > 80){
            spawnRate = 0.6f;
        }
        if(Time.timeSinceLevelLoad > 120){
            spawnRate = 0.4f;
        }
    }
}
