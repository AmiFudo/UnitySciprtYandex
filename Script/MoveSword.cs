using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSword : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;

    private GameObject _player;
    private int _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * _moveDirection * _moveSpeed * Time.deltaTime;
    }

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _moveDirection = transform.position.x < _player.transform.position.x ? 1 : -1;

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
