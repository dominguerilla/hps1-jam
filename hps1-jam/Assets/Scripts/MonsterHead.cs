using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterHead : MonsterBody
{
    /*
     * TODO: Make MonsterHead and MonsterBody inherit from Monster.
     * 
     */

    public override void Attack()
    {
        Debug.Log("ATTACK!");
    }
}
