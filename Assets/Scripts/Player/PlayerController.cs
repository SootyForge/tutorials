using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
/*
 * The PlayerController handles player movement & rotation logic
 */
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent; // reference to NavMeshAgent component

    public Vector3 targetPos;

    // Update is called once per frame
    void Update()
    {
        // If the targetPos is valid (is not zero)
        if(targetPos.magnitude > 0)
        {
            // Follow the target!
            agent.SetDestination(targetPos);
        }
    }

    // Call this to tell agent where to go!
    public void SetTarget(Vector3 target)
    {
        // Set the new target
        targetPos = target;
    }
}
