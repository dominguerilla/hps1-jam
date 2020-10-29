using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterHead : MonoBehaviour
{
    NavMeshAgent agent;

    bool isSeparated = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
