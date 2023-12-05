using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRight : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
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
            if(Time.timeSinceLevelLoad > 20){
                nextSpawn = Time.timeSinceLevelLoad + spawnRate;
                Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                float spawnPointPositionY = randomSpawnPoint.position.y;
                randomSpawnPoint.position = new Vector3(randomSpawnPoint.position.x, spawnPointPositionY, randomSpawnPoint.position.z);
                Instantiate(_sword, randomSpawnPoint.position, Quaternion.identity);
            }
        }
    }
}
