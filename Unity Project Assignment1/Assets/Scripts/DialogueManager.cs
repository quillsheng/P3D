using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;
    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

 
    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 2.5f)
        {
            if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                curResponseTracker++;
                if(curResponseTracker >= npc.playerdialogue.Length - 1)
                {
                    curResponseTracker = npc.playerdialogue.Length - 1;
                }
            }
            else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if(curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }
            //trigger dialogue
            if(Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            if(curResponseTracker == 0 && npc.playerdialogue.Length >= 0)
            {
                playerResponse.text = npc.playerdialogue[0];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }
            else if(curResponseTracker == 1 && npc.playerdialogue.Length >= 1)
            {
                playerResponse.text = npc.playerdialogue[1];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
            else if (curResponseTracker == 2 && npc.playerdialogue.Length >= 2)
            {
                playerResponse.text = npc.playerdialogue[2];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[3];
                }
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }
}
