using System;
using EnumData;
using UnityEngine;
using UnityEngine.AI;

public class TraceCharacter : MonoBehaviour
{
    public SightColor[] ActiveColors;
    private Vector3 fixedPosition;
    private NavMeshAgent agent;

    private void Awake()
    {
        fixedPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    //플레이어를 쫓아가도록 설정해야함
    private void FixedUpdate()
    {
        if (Array.Exists(ActiveColors, x => x == GameManager.Instance.sightColor)) agent.SetDestination(GameManager.Instance.MainCharacter.transform.position);
        else agent.SetDestination(fixedPosition);
    }
}