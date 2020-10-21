using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Bolt;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{
    public GameObject[] huntingGrounds;
    public float huntingGroundRadius = 5f;
    public float stunTime = 2.5f;

    NavMeshAgent agent;
    bool isStunned = false;
    bool isAlternatingLight = false;

    // TODO: remove this
    [SerializeField] Light monsterDebugLight;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void GoToRandomHuntingGround()
    {
        Vector3 huntingGroundPosition = GetRandomHuntingGroundPosition();
        agent.SetDestination(huntingGroundPosition);
    }

    public void GoTo(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public bool isAtDestination()
    {
        return agent.remainingDistance < 1f;
    }

    Vector3 GetRandomHuntingGroundPosition()
    {
        GameObject randomHuntingGround = GetRandomHuntingGround();
        float randX = Random.Range(0.5f, huntingGroundRadius);
        float randZ = Random.Range(0.5f, huntingGroundRadius);

        Vector3 randomOffset = new Vector3(randX, 0, randZ);
        return randomHuntingGround.transform.position + randomOffset;
    }

    GameObject GetRandomHuntingGround()
    {
        return huntingGrounds[Random.Range(0, huntingGrounds.Length)];
    }

    public void Stun()
    {
        if(!isStunned) StartCoroutine(StunRoutine());
    }

    public void Flee()
    {
        Debug.Log($"{this.gameObject.name} is fleeing!");
    }

    public void OnDetectingPlayer()
    {
        StartCoroutine(AlternateLightColors());
        //GameObject target = vision.GetTarget();
        
        //CustomEvent.Trigger(this.gameObject, "OnSeeingPlayer");
    }

    public void OnLosingPlayer()
    {
        StopAlternatingLights();
        monsterDebugLight.color = Color.yellow;
        //CustomEvent.Trigger(this.gameObject, "OnLosingPlayer");
    }

    IEnumerator AlternateLightColors()
    {
        if (!isAlternatingLight)
        {
            isAlternatingLight = true;
            Color lightColor = Color.red;
            while (isAlternatingLight)
            {
                monsterDebugLight.color = lightColor;
                yield return new WaitForSeconds(0.5f);
                lightColor = lightColor == Color.red ? Color.blue : Color.red;
            }
        }
        yield return null;
    }

    void StopAlternatingLights()
    {
        isAlternatingLight = false;
    }

    IEnumerator StunRoutine()
    {
        isStunned = true;
        bool originalState = agent.isStopped;
        agent.isStopped = true;
        yield return new WaitForSeconds(stunTime);
        agent.isStopped = originalState;
        isStunned = false;
    }
}
