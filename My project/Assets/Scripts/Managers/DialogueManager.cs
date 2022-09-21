using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public GameObject dialogueUI;

    //public TextMeshProUGUI text;
    //private List<string> sentences;
    //private int index;
    //private bool isSentenceComplete = false;

    //public float textSpeed = 0.05f;
    //public float waitTimer = 1;

    //public float nextSentenceTimer = 5;
    //private float timer;

    //IEnumerator StartDialogue()
    //{
    //    foreach (char c in sentences[index].ToCharArray())
    //    {
    //        dialogueUI.SetActive(true);
    //        text.text += c;
    //        yield return new WaitForSeconds(textSpeed);
    //        isSentenceComplete = true;
    //    }
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    text.text = string.Empty;
    //    sentences = new List<string>();
    //    sentences.Add("Welcome Test Subject");
    //    sentences.Add("This is the Test Center");

    //    timer = nextSentenceTimer;

    //    dialogueUI.SetActive(false);
    //    isSentenceComplete = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Debug.Log(sentences[index]);
    //    if (isSentenceComplete)
    //    {
    //        timer -= Time.deltaTime;
    //        //Debug.Log(timer);

    //        if (timer <= 0 && text.text == sentences[index])
    //        {
    //            timer = nextSentenceTimer;
    //            NextSentence();
    //        }
    //    }
    //}
    //void NextSentence()
    //{
    //    isSentenceComplete = false;
    //    if (index < sentences.Count - 1)
    //    {
    //        index++;
    //        text.text = string.Empty;
    //        StartCoroutine(StartDialogue());
    //    }
    //    else
    //    {
    //        dialogueUI.SetActive(false);
    //    }
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    StartCoroutine(StartDialogue());
    //    Debug.Log("Entered");
    //}

    static private DialogueManager instance;
    static public DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is no DialogueManager instance in the scene");
            }
            return instance;
        }
    }

    private Queue<string> sentences;

    public TextMeshProUGUI dialogueText;

    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    } 

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("Sentence over");
    }
}
