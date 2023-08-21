using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class MelodyCh1 : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    Ch1AudioManager audioManager;
    public GameObject waypoints;
    public Transform[] waypointsArr;
    private StoryCanvas storyCanvas;
    bool startedCoroutine = false;
    bool coroutineRunning = false;
    bool parrotAnswered = false;
    bool melodyWondered= false;

    private string ch1_2_path = "event:/ch1_2";
    private string ch1_3_path = "event:/ch1_3";
    private string ch1_4_path = "event:/ch1_4";
    private string ch1_5_path = "event:/ch1-5";

    List<string> paths;

    enum CurrState
    {
        goingToMarket,
        withParrot
        
    }
    CurrState currState = CurrState.goingToMarket;

    void Start()
    {
        audioManager = Ch1AudioManager.Instance;
        waypointsArr = new Transform[waypoints.transform.childCount];
        for (int i = 0; i < waypoints.transform.childCount; i++)
        {
            waypointsArr[i] = waypoints.transform.GetChild(i);
        }
        paths = new List<string> { ch1_2_path, ch1_3_path,ch1_4_path, ch1_5_path};
        animator= GetComponent<Animator>();
        animator.SetBool("Walk", true);
        agent = GetComponent<NavMeshAgent>();
        storyCanvas = StoryCanvas.Instance;
        GoToMarket();
    }

    void Update()
    {
        //going to market
        if (currState == CurrState.goingToMarket)
        {
            if (Vector3.Distance(transform.position, waypointsArr[0].position) > 0.4f)
            {
                GoToMarket();
            }
            else
            {
                audioManager.PlayOneTimeSound(ch1_2_path);
                currState = CurrState.withParrot;
                animator.SetBool("Walk", false);
                storyCanvas.ChangeText();

            }
        }
        //parrot convo
        else if (currState == CurrState.withParrot)
        {

            if (!startedCoroutine)
            {
                startedCoroutine = true;
                StartCoroutine(waitSecondsAndPlay(9, paths[1]));
                coroutineRunning= true;
            }
            //parrot stops making commotion
            if(!coroutineRunning && !parrotAnswered)
            {
                approachParrot();
                coroutineRunning = true ;
                StartCoroutine(waitSecondsAndPlay(7, paths[2]));
                Parrot.stopMakingCommotion();
                parrotAnswered = true;
            }
            //echo hops from house to house
            else if (!coroutineRunning && !melodyWondered )
            {
                melodyWondered= true;
                Parrot.HopHouseToHouse();
                StartCoroutine(waitSecondsAndPlay(7, paths[3]));
            }

        }
    }
    public void GoToMarket()
    {
        agent.SetDestination(waypointsArr[0].position);
    }
    IEnumerator waitSecondsAndPlay(int seconds, string path)
    {
        yield return new WaitForSeconds(seconds);
        audioManager.PlayOneTimeSound(path);
        storyCanvas.ChangeText();

        coroutineRunning = false;
    }
    private void approachParrot()
    {
        Debug.Log("approach parrot");
        agent.SetDestination(waypointsArr[1].position);
        //Ch1AudioManager.Instance.PlayOneTimeSound(paths[2]);
    }
}
