using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    private NavMeshAgent botagent; 
    private Animator animbot; 
    [SerializeField] private GameObject[] points;
    private float weight = 0;
    public AudioSource _source;

    private enum states
    {
        waiting, 
        going,
    }

    states state = states.waiting; 

    private void Start()
    {
        animbot = GetComponent<Animator>(); 
        botagent = GetComponent<NavMeshAgent>();
        StartCoroutine(Wait()); 
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case states.going:
            {
                if ((Vector3.Distance(transform.position, botagent.destination)) < 3)
                {
                    StartCoroutine(Wait()); 
                }

                break;
            }
        }
    }

    private IEnumerator Wait()
    {
        botagent.SetDestination(transform.position);
        animbot.SetBool("action", false);
        _source.Stop();
        state = states.waiting; 
        yield return new WaitForSeconds(4f);
        botagent.SetDestination(points[Random.Range(0, points.Length)].transform.position);
        animbot.SetBool("action", true);
        _source.Play();
        state = states.going; 
    }
}