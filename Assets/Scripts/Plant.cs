using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private float maxSize;
    [SerializeField] private float growthSpeed;

    private bool isGrown;

    private float _timer;


    void Update()
    {
        _timer += Time.deltaTime;

        if (isGrown && transform.localScale.y < maxSize)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                               transform.localScale.y + (Time.deltaTime * growthSpeed),
                                               transform.localScale.z);

            transform.position = new Vector3(transform.position.x,
                                             transform.position.y + Time.deltaTime * growthSpeed / 2,
                                             transform.position.z);
        }

        if (_timer >= 15f && !isGrown) gameObject.SetActive(false);
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isGrown = true;
    }
}
