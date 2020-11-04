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
    public UnityEvent onAttach = new UnityEvent();

    Vector3 originalPosition;
    Quaternion originalRotation;

    bool _isAttached = false;

    protected override void Awake()
    {
        base.Awake();
        _isAttached = attachedBody != null;
    }

    public override void Attack()
    {
        Debug.Log("BITE!");
    }

    public bool isAttached()
    {
        return _isAttached;
    }

    public void Detach()
    {
        if (!_isAttached) throw new System.Exception("Head already detached!");
        originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;
        Debug.Log("HEAD DETACH!");
        _isAttached = false;
        this.transform.parent = null;
        EnableMonster();
        onDetach.Invoke();
    }

    public void Attach(MonsterLowerHalf lowerHalf)
    {
        if (_isAttached) throw new System.Exception("Head already attached!");
        if (lowerHalf == null) throw new System.Exception("No lowerHalf given!");
        StopAlternatingLights();
        attachedBody = lowerHalf;
        _isAttached = true;
        this.transform.parent = attachedBody.transform;
        this.transform.position = originalPosition;
        this.transform.rotation = originalRotation;
        DisableMonster();
        lowerHalf.Attach(this);
        onAttach.Invoke();
    }

    public MonsterLowerHalf GetBody()
    {
        return attachedBody;
    }

    public void ReAttach()
    {
        Attach(attachedBody);
    }
}
