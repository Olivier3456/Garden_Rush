using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;

    private GameObject _ground;

    [SerializeField] float _spawnRate;


    [SerializeField] float _xMin;
    [SerializeField] float _xMax;
    [SerializeField] float _zMin;
    [SerializeField] float _zMax;

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
        return new Vector3(Random.Range(_xMin, _xMax), _ground.transform.position.y + 0.5f, Random.Range(_zMin, _zMax));
    }

}
