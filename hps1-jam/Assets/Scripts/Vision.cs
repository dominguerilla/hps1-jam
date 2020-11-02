using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vision : MonoBehaviour
{
    public UnityEvent OnDetectPlayer = new UnityEvent();
    public UnityEvent OnLosePlayer = new UnityEvent();

    [SerializeField] Transform eyePosition;
    GameObject seenTarget;

    bool sawPlayer = false;

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log($"{other.gameObject.name} entered field of vision.");
        if (other.gameObject.tag == "Player")
        {
            RaycastHit hit;
            if (CanSee(other.gameObject, out hit))
            {
                seenTarget = other.gameObject;
                sawPlayer = true;
                OnDetectPlayer.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log($"{other.gameObject.name} exited field of vision.");
        if (other.gameObject.tag == "Player")
        {
            if (sawPlayer)
            {
                sawPlayer = false;
                seenTarget = null;
                OnLosePlayer.Invoke();
            }
        }
    }

    bool CanSee(GameObject other, out RaycastHit hit)
    {
        if (Physics.Raycast(eyePosition.position, other.transform.position - eyePosition.position, out hit)) {
            if (hit.transform.tag == "Player")
            {
                return true;
            }
        }
        return false;
        
    }

    public GameObject GetSeenTarget()
    {
        return seenTarget;
    }
}
