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
    bool isQuestioning = false;

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

        if (distance < 2)
        {
            // rotate the npc towards the player
            Vector3 target_dir = player.transform.position - transform.position;
            target_dir.y = 0; // stay in x-z plane
            Vector3 temp_dir = Vector3.RotateTowards(transform.forward, target_dir, Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(temp_dir);
            animator.SetBool("isTalking", true); // start talking
            if (!isQuestioning)
            {
                isQuestioning = true;
                StartQuestions();
            }
        }
        else
        {
            animator.SetBool("isTalking", false); // stop talking
            isQuestioning = false;
            EndQuestions();
        }
    }

    private void StartQuestions()
    {
        background.enabled = true;
        talkText.enabled = true;

        StartCoroutine(AskQuestions());
    }

    private void EndQuestions()
    {
        StopCoroutine(AskQuestions());
        background.enabled = false;
        talkText.enabled = false;
    }

    private IEnumerator AskQuestions()
    {
        talkText.text = "Answer 3 questions to get your key:";
        yield return new WaitForSeconds(2f);
        while (ansCount < 2)
        {
            switch (ansCount)
            {
                case 0:
                    talkText.text = "Question number 1:";
                    yield return new WaitForSeconds(2f);
                    talkText.text = "Is Victor the best lecturer in Afeka? Y/N";
                    yield return StartCoroutine(GetAnswer(answer =>
                    {
                        if (answer)
                        {
                            // Player answered "Yes"
                            talkText.text = "Correct";
                            ansCount++;
                        }
                        else
                        {
                            // Player answered "No"
                            talkText.text = "Wrong";
                        }
                    }));
                    yield return new WaitForSeconds(2f);
                    break;

                case 1:
                    talkText.text = "Question number 2:";
                    yield return new WaitForSeconds(2f);
                    talkText.text = "Is Yarin the best Student in Afeka? Y/N";
                    yield return StartCoroutine(GetAnswer(answer =>
                    {
                        if (answer)
                        {
                            // Player answered "Yes"
                            talkText.text = "Correct";
                            ansCount++;
                        }
                        else
                        {
                            // Player answered "No"
                            talkText.text = "Wrong";
                        }
                    }));
                    yield return new WaitForSeconds(2f);
                    break;
            }   
        }
        if(ansCount >= 2)
        {
            talkText.text = "You got your key from this room! Good Luck in your journey.";
            yield return new WaitForSeconds(2f);
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

    private IEnumerator ShowMessageAndContinue(string message, float duration)
    {
        talkText.text = message;
        yield return new WaitForSeconds(duration);
    }
}
