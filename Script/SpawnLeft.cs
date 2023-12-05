using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeft : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPointsLeft;
    [SerializeField] private GameObject _sword;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float nextSpawn = 2f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            Spawn();
        
    }

    public void Spawn()
    {
        if(Time.timeSinceLevelLoad > nextSpawn){
            if(Time.timeSinceLevelLoad > 10){
                nextSpawn = Time.timeSinceLevelLoad + spawnRate;
                Transform randomSpawnPoint = _spawnPointsLeft[Random.Range(0, _spawnPointsLeft.Length)];
                float spawnPointPositionY = randomSpawnPoint.position.y;
                randomSpawnPoint.position = new Vector3(randomSpawnPoint.position.x, spawnPointPositionY, randomSpawnPoint.position.z);
                Instantiate(_sword, randomSpawnPoint.position, Quaternion.identity);
            }
        } 
    }
}
