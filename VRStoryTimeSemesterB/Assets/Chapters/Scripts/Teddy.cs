using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teddy : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent agent;
    private float walkingVal;
    private Animator animator;
    private Vector3 playerTeddyOffset = Vector3.zero;
    private bool walkingStarted = false;
    private bool stoppingStarted = true;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerTeddyOffset.z = Player.transform.position.z - transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if(dist > 3.5f)
        {
            if (!walkingStarted)
            {
                walkingStarted= true;
                stoppingStarted = false;
                StopAllCoroutines();
                StartCoroutine(startWalking());
            }
            agent.SetDestination(Player.transform.position + Player.transform.forward *1.5f);    
        }
        else
        {
            if (!stoppingStarted)
            {
                stoppingStarted= true;
                walkingStarted = false;
                StopAllCoroutines();
                StartCoroutine(stopWalking());
                Debug.Log("stopped walking");
            }
        }
    }
    private IEnumerator startWalking()
    {
        walkingVal = animator.GetFloat("Walk");
        while (walkingVal < 1)
        {
            walkingVal += Time.deltaTime;
            walkingVal = walkingVal > 1 ? 1 : walkingVal;
            animator.SetFloat("Walk", walkingVal);
            yield return null;
        }
    }
    private IEnumerator stopWalking()
    {
        walkingVal = animator.GetFloat("Walk");
        while (walkingVal > 0 )
        {
            walkingVal -= Time.deltaTime;
            walkingVal = walkingVal < 0 ? 0 : walkingVal;
            animator.SetFloat("Walk", walkingVal);
            yield return null;
        }
    }
}
