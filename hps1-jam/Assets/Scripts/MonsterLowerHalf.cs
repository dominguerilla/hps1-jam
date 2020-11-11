using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterLowerHalf : Monster
{
    [SerializeField] MonsterHead head;
    public UnityEvent onDetach = new UnityEvent();

    bool isHeadDetached = false;
    public override void Attack()
    {
        Detach();
    }

    public override void OnSalted()
    {
        if (isHeadDetached)
        {
            Debug.Log("Body has been salted!");
        }
        else
        {
            base.OnSalted();
        }
    }

    public void Detach()
    {
        if (!isHeadDetached)
        {
            Debug.Log("BODY DETACH!");
            isHeadDetached = true;
            DisableMonster();
            StopAlternatingLights();
            head.Detach();
            onDetach.Invoke();
        }
    }

    public void Attach(MonsterHead head)
    {
        if (head == null) throw new System.Exception("No head given!");
        isHeadDetached = false;
        this.head = head;
        EnableMonster();
    }
}
