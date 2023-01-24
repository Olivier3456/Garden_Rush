using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] float _spawnRate;
    [Space(20)]
    [SerializeField] float _xMin;
    [SerializeField] float _xMax;
    [Space(10)]
    [SerializeField] float _zMin;
    [SerializeField] float _zMax;

    private GameObject _ground;
    private float _timer;

    void Start()
    {
        _ground = GameObject.Find("Ground");
    }


    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnRate)
        {
            SpawnObject();
            _timer = 0f;
        }
    }



    private void SpawnObject()
    {
        
        Instantiate(_prefabToSpawn, RandomPosition(), Quaternion.identity);
    }

    private Vector3 RandomPosition()
    {
        NavMeshHit hit;
        Vector3 position = new Vector3(-404,-404, -404);
        
        while (!NavMesh.SamplePosition(position, out hit, 1.0f, NavMesh.AllAreas))
        {
            position = new Vector3(Random.Range(_xMin, _xMax), _ground.transform.position.y + 0.5f, Random.Range(_zMin, _zMax));           
        }     
            return position;       
    }

}
