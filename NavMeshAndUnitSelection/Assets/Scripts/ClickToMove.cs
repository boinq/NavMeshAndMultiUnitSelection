using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private UnitSelectable unitSelectable;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        unitSelectable = GetComponent<UnitSelectable>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (unitSelectable.IsSelected == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    navMeshAgent.SetDestination(hit.point);
                }
            }
        }

    }
}
