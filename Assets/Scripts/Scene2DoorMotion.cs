using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2DoorMotion : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    public Text keysText;
    //AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //connect to Unity component
        //sound = GetComponent<AudioSource>();
        //prefabName = gameObject.name;

    }

    // Update is called once per frame
    void Update()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if(distance < 3)
            {
                int x = KeyBehaviour.getNumOfKeys();
                int doorNumber;

                try
                {
                    doorNumber = int.Parse(gameObject.name.Substring(4));
                }
                catch (System.Exception ex)
                {               
                    Debug.LogError("Failed to parse door number: " + ex.Message);
                    doorNumber = -1; // Assign a default value or handle the error case as needed
                }
                if ( x == doorNumber){
                    animator.SetBool("isOpen", true);
                }
            }
        }
}
