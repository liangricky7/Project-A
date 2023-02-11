using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AllyFollow : MonoBehaviour
{
    private Transform player;
    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = PlayerManager.instance.Player.transform;
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
