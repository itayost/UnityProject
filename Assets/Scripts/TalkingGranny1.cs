using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingGranny1 : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    public Text talkText;
    public GameObject talkBackground;
    RawImage background;
    int ansCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        background = talkBackground.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < 3)
        {
            // rotate the npc towards the player
            Vector3 target_dir = player.transform.position - transform.position;
            target_dir.y = 0; // stay in x-z plane
            Vector3 temp_dir = Vector3.RotateTowards(transform.forward, target_dir, Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(temp_dir);
            animator.SetBool("isTalking", true); // start talking
            StartQuestions();
        }
        else
        {
            animator.SetBool("isTalking", false); // stop talking
            EndQuestions();
        }
    }

    private void StartQuestions(){
        background.enabled = true;
        talkText.enabled = true;

        StartCoroutine(AskQuestions());
    }

    private void EndQuestions(){
        background.enabled = false;
        talkText.enabled = false;
    }

 private IEnumerator AskQuestions()
{
    while (ansCount < 3)
    {
        talkText.text = "Hello World!";

        if (ansCount == 0)
        {
            talkText.text = "Is Victor the best lecturer in Afeka? Y/N";
            yield return StartCoroutine(GetAnswer(answer =>
            {
                if (answer)
                {
                    // Player answered "Yes"
                    talkText.text = "Correct";
                    Debug.Log("Player thinks Victor is the best lecturer!");
                    StartCoroutine(WaitAndContinue(1f));
                    ansCount++;
                }
                else
                {
                    // Player answered "No"
                    talkText.text = "Wrong";
                    Debug.Log("Player doesn't think Victor is the best lecturer.");
                    StartCoroutine(WaitAndContinue(1f));
                }

                ansCount++;
            }));
        }

        // Add more questions and handling logic for other values of ansCount

        // Wait for a short delay before moving to the next question
        yield return new WaitForSeconds(2f); // Adjust the delay as needed
    }
}

private IEnumerator GetAnswer(System.Action<bool> callback)
{
    bool waitingForInput = true;

    while (waitingForInput)
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            waitingForInput = false;
            callback(true);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            waitingForInput = false;
            callback(false);
        }

        yield return null;
    }
}

private IEnumerator WaitAndContinue(float delay)
{
    yield return new WaitForSeconds(delay);
}
}
