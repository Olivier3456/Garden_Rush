using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _gardener;
    private NavMeshAgent _gardenerAgent;
    [Space(20)]
    [SerializeField] IntVariable _waterScriptableObject;
    [SerializeField] TextMeshProUGUI _waterText;
    [SerializeField] private int _water = 50;
    private int _actualWater;
    [Space(20)]
    [SerializeField] IntVariable _plantsGrownSO;
    [SerializeField] TextMeshProUGUI _plantsToGrowthText;
    [SerializeField] private int _plantsToGrowth = 7;
    private int _plantsGrown;

    private List<Vector3> _destinationsList; 

    void Start()
    {
        _gardenerAgent = _gardener.GetComponent<NavMeshAgent>();
        _destinationsList = new List<Vector3>();

        _waterScriptableObject.Value = _water;
        _actualWater = _water;

        _plantsGrownSO.Value = 0;
        _plantsGrown = 0;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) AddDestination();

        if (Vector3.Distance(_gardener.position, _gardenerAgent.destination) < 2f && _destinationsList.Count > 0) GoToNextDestination();

        RefreshWaterUI();
        RefreshPlantsGrownUI();
    }

    private void RefreshPlantsGrownUI()
    {
        if (_plantsGrown != _plantsGrownSO.Value)
        {
            _plantsGrown = _plantsGrownSO.Value;
            _plantsToGrowthText.text = _plantsGrown + " plant(s) / " + _plantsToGrowth;
        }
    }

    private void RefreshWaterUI()
    {
        if (_actualWater != _waterScriptableObject.Value)
        {
            _actualWater = _waterScriptableObject.Value;
            _waterText.text = "Water : " + _actualWater;
        }
    }

    private void GoToNextDestination()
    {
        _gardenerAgent.destination = _destinationsList[0];
        _destinationsList.Remove(_destinationsList[0]);
        Debug.Log("Nouvelle destination : " + _gardenerAgent.destination);
    }


    private void AddDestination()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            _destinationsList.Add(hit.point);
            Debug.Log("Destination ajoutée à la liste : " + hit.point);
        }
    }
}
