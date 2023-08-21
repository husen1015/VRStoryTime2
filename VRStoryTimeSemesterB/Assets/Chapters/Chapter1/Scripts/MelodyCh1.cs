using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MelodyCh1 : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public GameObject market;
    private StoryCanvas storyCanvas;
    private string ch1_2_path = "event:/ch1_2";

    enum CurrState
    {
        goingToMarket,
        withParrot
    }
    CurrState currState = CurrState.goingToMarket;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        animator.SetBool("Walk", true);
        agent = GetComponent<NavMeshAgent>();
        storyCanvas = StoryCanvas.Instance;
        GoToMarket();
    }

    // Update is called once per frame
    void Update()
    {
        if(currState== CurrState.goingToMarket)
        {
            if(Vector3.Distance(transform.position, market.transform.position) > 0.4f)
            {
                GoToMarket();
            }
            else
            {
                Ch1AudioManager.Instance.PlayOneTimeSound(ch1_2_path);
                currState= CurrState.withParrot;
                animator.SetBool("Walk", false);
                storyCanvas.ChangeText(1);
            }

        }
    }
    public void GoToMarket()
    {
        agent.SetDestination(market.transform.position);
    }
}
