using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    bool canClick = false;




    void OnTriggerEnter(Collider col)
    {
        Debug.Log("The tag of this object is: "+ col.tag);
        if (col.tag == null)
        {
            Debug.Log("There is no tag associated");
        }
        else if (col.tag == "Default")
        {
            Debug.Log("");
        }
        else if (col.tag == "ComputerMonitor")
        {
            Debug.Log("");
        }
        else if (col.tag == "NPC-Creature")
        {
            Debug.Log("");
        }
        else if (col.tag == "NPC-Scientist")
        {
            Debug.Log("");
        }
        else if (col.tag == "")
        {
            Debug.Log("");
        }
        else if (col.tag == "")
        {
            Debug.Log("");
        }

    }
}
