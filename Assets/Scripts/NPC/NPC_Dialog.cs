using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{




    public float dialogRange;
    public LayerMask playerLayer;
    public DialogSettings dialogSettings;
    bool playerHit;
    private List<string> sentences = new List<string> ();

    // Start is called before the first frame update
    void Start()
    {
        GetNPCSentences();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogControl.Instance.Speech(sentences.ToArray());
        }
    }

    private void FixedUpdate()
    {
        ShowDialog();
    }

    void ShowDialog()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogRange, playerLayer);

    if (hit != null)
        {
            playerHit = true;
        }
    else
        {
            playerHit = false;
            
        }
    }

    void GetNPCSentences()
    {
        for(int i =0; i < dialogSettings.dialogs.Count; i++)
        {
            string text = "";
            switch (DialogControl.Instance.selectedLang)
            {
                case DialogControl.idiom.pt:
                    text = dialogSettings.dialogs[i].sentence.portuguese;
                    break;
                case DialogControl.idiom.eng:
                    text = dialogSettings.dialogs[i].sentence.english;
                    break;
                case DialogControl.idiom.spa:
                    text = dialogSettings.dialogs[i].sentence.spanish;
                    break;
            }
            sentences.Add(text);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogRange);
    }
}
