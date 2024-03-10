using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2DoorMotion : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    //AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //connect to Unity component
        //sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if(distance < 3)
            {
                animator.SetBool("isOpen", true);
            }
            else
            {
                animator.SetBool("isOpen", false);
            }
        }
}
