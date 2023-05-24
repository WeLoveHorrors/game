using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animations : MonoBehaviour
{

    public Animator animator;
    NavMeshAgent agent;
    public GameObject palyer;
    private int rand;
    private int lastrand;
    private bool inRoll;
    private float force = 0.5f;
    private float timeout = 0.03f;
    private bool inJumpUp;
    private bool inJumpDown;
    private bool inJump;
    private float JumpUpforce = 0.03f;
    private float Jumptimeout = 0.03f;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        palyer = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(GetRandom());
        inJump = true;
        inJumpUp = true;
        inJumpDown = true;

        animator.SetTrigger("Run");
        //animator.SetTrigger("Run");
        //AnimateRun();
        //AnimateAtack();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, palyer.transform.position);
        if (agent.velocity.magnitude != 0f && lastrand != rand && distance > 5)
        {
            AnimateRun(rand);
        }
        else if (lastrand != rand && distance <= 5)
        {
            AnimateAtack(rand);
        }

    }

    public void AnimateAtack(int rand)
    {
        if (rand % 2 == 0)
        {
            //StartCoroutine(AnimateJump(rand));
            animator.SetTrigger("Attack1");
        }
        if (rand % 2 == 1)
        {
            //StartCoroutine(AnimateJump(rand));
            animator.SetTrigger("Attack2");
        }
    }

    public IEnumerator AnimateJump(int rand)
    {
        if (rand <= 50)
        {
            animator.SetTrigger("Jump");
            animator.SetTrigger("Land");
            yield return new WaitForSeconds(0.1f);
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
    // public IEnumerator JumpUp()
    // {
    //     while (inJumpUp == true)
    //     {
    //         yield return new WaitForSeconds(0.5f);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position += new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         inJumpUp = false;
    //         inJumpDown = true;
    //     }
    // }
    // public IEnumerator JumpDown()
    // {
    //     while (inJumpDown == true)
    //     {

    //         yield return new WaitForSeconds(0.5f);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);
    //         transform.position -= new Vector3(0, JumpUpforce, 0);
    //         yield return new WaitForSeconds(Jumptimeout);

    //     }
    // }
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
