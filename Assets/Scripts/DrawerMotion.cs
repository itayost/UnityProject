using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerMotion : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    public Text popText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject == player.gameObject)
        {
            if(!animator.GetBool("isOpen"))
            {
                popText.text = "Press 'O' to open the Drawer";
                popText.enabled = true;
                if (Input.GetKeyDown(KeyCode.O))
                {
                    popText.text = "O pressed";
                    animator.SetBool("isOpen", true);
                }
            }
            else
            {
                popText.text = "Press 'C' to close the Drawer";
                popText.enabled = true;
                if (Input.GetKeyDown(KeyCode.C))
                {
                    animator.SetBool("isOpen", false);
                }
            }
        }*/
        StartCoroutine(WaitForPlayerInput());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            popText.enabled = false;
        }
    }

    private IEnumerator WaitForPlayerInput()
    {
        while (true)
        {
            if (!animator.GetBool("isOpen"))
            {
                popText.text = "Press 'O' to open the Drawer";
                popText.enabled = true;

                if (Input.GetKeyDown(KeyCode.O))
                {
                    popText.text = "O pressed";
                    animator.SetBool("isOpen", true);
                    break;
                }
            }
            else
            {
                popText.text = "Press 'C' to close the Drawer";
                popText.enabled = true;

                if (Input.GetKeyDown(KeyCode.C))
                {
                    animator.SetBool("isOpen", false);
                    break;
                }
            }

            yield return null;
        }

        popText.enabled = false;
}
}
