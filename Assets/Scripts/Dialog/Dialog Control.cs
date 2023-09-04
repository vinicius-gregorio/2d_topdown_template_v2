using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt, 
        eng,
        spa,
    }

    [Header("Components")]
    public GameObject dialogObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;
    public idiom selectedLang;

    [Header("Settings")]
    public float typingSpeed;


    public bool isShowing;
    private int index;
    private string[] sentences;


    public static DialogControl Instance;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            } 
            else
            {
                speechText.text = "";
                index = 0;
                dialogObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }

        }
    }
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
