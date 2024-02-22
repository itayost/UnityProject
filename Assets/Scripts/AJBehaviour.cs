using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJBehaviour : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetInteger("State", 1);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("State", 0);
        }
    }
}
