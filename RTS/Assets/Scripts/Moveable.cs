using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Moveable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    NavMeshAgent agent;
    public GameObject Target;
    public Vector2 TargetPos;
    public bool isMoving = false;
    public bool Targeting = false;
    [TextArea(3, 20)]
    public string least;
    public bool PosArrive = false; //위치 지정시
    public bool CanArrive;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        TargetPos = transform.position;
        agent.radius = transform.parent.localScale.x * 0.25f;
        agent.stoppingDistance = 0.03f * (agent.radius * 10);
    }

    // Update is called once per frame
    void Update()
    {
        agent.isStopped = !isMoving;
        if (isMoving)
        {
            if(Target == null)
            {
                if (Targeting == true)
                {
                    Targeting = false;
                    TargetPos = transform.position;
                }
            }
            if (Targeting && Target != null)
            {
                agent.SetDestination(Target.transform.position);
            }
            else
            {
                agent.SetDestination(TargetPos);
                least = string.Format("남은거리 {0}\n속도 {1}", agent.remainingDistance,agent.velocity.sqrMagnitude);
                if (agent.remainingDistance <= agent.stoppingDistance && PosArrive == false)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude <= 0.00f)
                    {
                        if (CanArrive == true)
                        {
                            PosArrive = true;
                            isMoving = false;
                            Debug.Log("Arrive" + agent.transform.name);
                        }
                    }
                }
            }
        }
        else
        {
        }
    }

    IEnumerator CanArriveTime()
    {
        CanArrive = false;
        yield return new WaitForSeconds(0.1f);
        CanArrive = true;
    }

    public void StartMove(GameObject Target)
    {
        this.Target = Target;
        Targeting = true;
        isMoving = true;
    }
    public void StartMove(Vector2 TargetPos)
    {
        this.TargetPos = TargetPos;
        StartCoroutine(CanArriveTime());
        PosArrive = false;
        Targeting = false;
        isMoving = true;

    }
}
