using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vision : MonoBehaviour
{
    public UnityEvent OnDetectPlayer = new UnityEvent();
    public UnityEvent OnLosePlayer = new UnityEvent();

    [SerializeField] Transform eyePosition;

    bool sawPlayer = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (CanSee(other.gameObject))
            {
                sawPlayer = true;
                OnDetectPlayer.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (sawPlayer)
            {
                sawPlayer = false;
                OnLosePlayer.Invoke();
            }
        }
    }

    bool CanSee(GameObject other)
    {
        return Physics.Raycast(eyePosition.position, other.transform.position);
    }
}
