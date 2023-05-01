using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zomb : MonoBehaviour
{
    public GameObject pla;
    UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(pla.transform.position);
    }
   
}
