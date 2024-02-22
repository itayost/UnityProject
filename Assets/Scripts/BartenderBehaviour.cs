using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderBehaviour : MonoBehaviour
{
    Animator animator;
    public GameObject player; // connect to player in unity
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // connect to property in unity
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < 5)
        {
            animator.SetInteger("State", 1);
        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }
}
