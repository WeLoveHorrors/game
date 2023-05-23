using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animations : MonoBehaviour
{

    public Animator animator;
    NavMeshAgent agent;
    private int rand;
    private int lastrand;
    private bool inRoll;
    private float force = 0.5f;
    private float timeout = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(GetRandom());
        //animator.SetTrigger("Run");
        //AnimateRun();
        //AnimateAtack();
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.velocity.magnitude != 0f && lastrand!= rand)
        {
            AnimateRun(rand);
        }
        else if(agent.velocity.magnitude == 0f){
            //AnimateAtack(rand);
        }

    }

    public void AnimateAtack(int rand)
    {
        if (rand % 2 == 0)
        {
            AnimateJump(rand);
            animator.SetTrigger("Attack1");
        }
        if (rand % 2 == 1)
        {
            AnimateJump(rand);
            animator.SetTrigger("Attack2");
        }
    }

    public void AnimateJump(int rand)
    {
        if (rand <= 50)
        {
            animator.SetTrigger("Jump");
            animator.SetTrigger("Land");
        }
    }
    public void AnimateRun(int rand)
    {
        lastrand = rand;
        animator.SetTrigger("Run");
        AnimateRoll(rand);
        inRoll = false;
    }
    public void AnimateRoll(int rand)
    {
        if (rand <= 50)
        {
            inRoll = true;
            if (rand % 2 == 0)
            {
                StartCoroutine(Roll(rand));
                animator.SetTrigger("RollRight");
            }
            else
            {
                StartCoroutine(Roll(rand));
                animator.SetTrigger("RollLeft");
            }
        }
    }

    public IEnumerator GetRandom()
    {
        while (true)
        {
            rand = Random.Range(1, 100);
            yield return new WaitForSeconds(2);
        }
    }
    public IEnumerator Roll(int rand)
    {
        Vector3 forwardDirection = gameObject.transform.forward;
        Vector3 rightDirection = Quaternion.Euler(0f, 90f, 0f) * forwardDirection;
        Vector3 leftDirection = Quaternion.Euler(0f, -90f, 0f) * forwardDirection;
        while (inRoll == true)
        {
            if (rand % 2 == 0)
            {
                yield return new WaitForSeconds(0.5f);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += rightDirection * force;
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
                yield return new WaitForSeconds(timeout);
                transform.position += leftDirection * force;
            }
        }
    }



}
