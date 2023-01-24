using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _gardener;
    private NavMeshAgent _gardenerAgent;
    [Space(20)]
    [SerializeField] IntVariable _waterScriptableObject;  // Game Manager ne récupère ce ScriptableGameObject que pour initialiser sa valeur.
    [SerializeField] private int _water;

    private List<Vector3> _destinationsList; 

    void Start()
    {
        _gardenerAgent = _gardener.GetComponent<NavMeshAgent>();
        _destinationsList = new List<Vector3>();
        _waterScriptableObject.Value = 50;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) AddDestination();

        if (Vector3.Distance(_gardener.position, _gardenerAgent.destination) < 2f && _destinationsList.Count > 0) GoToNextDestination();       
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
