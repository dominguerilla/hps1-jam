using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterHead : Monster
{
    public override void Attack()
    {
        Debug.Log("BITE!");
    }
}
