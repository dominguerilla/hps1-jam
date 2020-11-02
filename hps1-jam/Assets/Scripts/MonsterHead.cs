using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterHead : Monster
{
    [SerializeField] MonsterLowerHalf attachedBody;
    public UnityEvent onDetach = new UnityEvent();

    public override void Attack()
    {
        Debug.Log("BITE!");
    }

    public bool isAttached()
    {
        return attachedBody != null;
    }

    public void Detach()
    {
        Debug.Log("HEAD DETACH!");
        attachedBody = null;
        this.transform.parent = null;
        EnableMonster();
        onDetach.Invoke();
    }

    public void Attach(MonsterLowerHalf lowerHalf)
    {
        DisableMonster();
        StopAlternatingLights();
        attachedBody = lowerHalf;
        this.transform.parent = attachedBody.transform;
    }
}
