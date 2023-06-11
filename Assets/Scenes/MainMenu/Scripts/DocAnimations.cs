using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocAnimations : MonoBehaviour
{
    public Animator animator;
    private int rand;
    private bool isAnim;
    // Start is called before the first frame update
    void Start()
    {
        isAnim=true;
        animator = GetComponent<Animator>();
        StartCoroutine(GetRandom());
        StartCoroutine(SetAnimations());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAnim==false){
            SetIdle();
        }
        
    }

    public void SetIdle(){
        animator.SetInteger("AnimNum",0);
    }
    public IEnumerator SetAnimations(){
        while (true)
        {
            if (isAnim==true)
            {
                animator.SetInteger("AnimNum",rand);
                Debug.Log("AnimStart");
                //isAnim=false;
            }
            Debug.Log("AnimStop");
            yield return new WaitForSeconds(20);
            Debug.Log("AnimStop2");
        }
    }

    public IEnumerator GetRandom()
    {
        while (true)
        {
            rand = Random.Range(0, 17);
            yield return new WaitForSeconds(10);
        }
    }
}
