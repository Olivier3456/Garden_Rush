using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private float maxSize;
    [SerializeField] private float growthSpeed;
    [SerializeField] private IntVariable _water;
    [SerializeField] private IntVariable _plantGrown;

    private bool isGrown;

    private float _timer;


    void Update()
    {
        if (isGrown && transform.localScale.y < maxSize)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                               transform.localScale.y + (Time.deltaTime * growthSpeed),
                                               transform.localScale.z);

            transform.position = new Vector3(transform.position.x,
                                             transform.position.y + Time.deltaTime * growthSpeed / 2,
                                             transform.position.z);
        }

        _timer += Time.deltaTime;
        if (_timer >= 15f && !isGrown) gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _water.Value >= 10 && !isGrown)
        {
            isGrown = true;
            _water.Value -= 10;
            _plantGrown.Value ++;
            Debug.Log("La plante pousse. Il reste " + _water.Value + " mesures d'eau.");
        }
    }
}
