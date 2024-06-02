using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, agent.transform.position);

        if (distance < 20)
        {
            agent.SetDestination(player.transform.position);
        }

    }
}
