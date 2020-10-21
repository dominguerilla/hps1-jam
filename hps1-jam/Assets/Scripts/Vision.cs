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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} entered collider.");
        if (other.gameObject.tag == "Player")
        {
            RaycastHit hit;
            if (CanSee(other.gameObject, out hit))
            {
                sawPlayer = true;
                OnDetectPlayer.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.gameObject.name} exited collider.");
        if (other.gameObject.tag == "Player")
        {
            if (sawPlayer)
            {
                sawPlayer = false;
                OnLosePlayer.Invoke();
            }
        }
    }

    bool CanSee(GameObject other, out RaycastHit hit)
    {
        return Physics.Raycast(eyePosition.position, other.transform.position, out hit);
    }
}
