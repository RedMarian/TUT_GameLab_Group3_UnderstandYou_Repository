using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickManager : MonoBehaviour
{
    bool computerAvailable = false;
    bool NPCSAvailable = false;
    bool NPCCAvailable = false;

    [SerializeField] GameObject ActionPrompt;

    [SerializeField] GameObject ContextMenu;
    [SerializeField] GameObject computerMenu;
    [SerializeField] GameObject TempUI; //TODO: Has to be replaced with appropriate gameplay session
    [SerializeField] TextMeshProUGUI TempUI_Text;
    [SerializeField] string currentTalkingTarget;

    

    public void ClickEvent()
    {
        if (computerAvailable)
        {
            ContextMenu.SetActive(true);
            TempUI.SetActive(false);
            computerMenu.SetActive(true);
        } else
        if (NPCCAvailable)
        {
            ContextMenu.SetActive(true);
            TempUI.SetActive(true);
            computerMenu.SetActive(false);
            TempUI_Text.text = "You are studying " + currentTalkingTarget;

        } else
        if (NPCSAvailable)
        {
            ContextMenu.SetActive(true);
            TempUI.SetActive(true);
            computerMenu.SetActive(false);
            TempUI_Text.text = "You are having a conversation with " + currentTalkingTarget;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("The tag of this object is: "+ col.tag);
        if (col.tag == null)
        {
            Debug.Log("There is no tag associated");
        }
        /*else if (col.tag == "Untagged")
        {
            Debug.Log("");
        }*/
        else if (col.tag == "ComputerMoniteur")
        {
            computerAvailable = true;
            ActionPrompt.SetActive(true);
            
        }
        else if (col.tag == "NPC-Creature")
        {
            NPCCAvailable = true;
            ActionPrompt.SetActive(true);
        }
        else if (col.tag == "NPC-Scientist")
        {
            NPCSAvailable = true;
            ActionPrompt.SetActive(true);
        }
        /*else if (col.tag == "") -------------------------IN CASE WE NEED MORE
        {
            Debug.Log("");
        }
        else if (col.tag == "")
        {
            Debug.Log("");
        }*/
        currentTalkingTarget = col.name;

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "ComputerMonitor"|| col.tag == "NPC-Creature"|| col.tag == "NPC-Scientist")
        {
            computerAvailable = false;
            NPCSAvailable = false;
            NPCCAvailable = false;
            ActionPrompt.SetActive(false);
        }
    }

}
