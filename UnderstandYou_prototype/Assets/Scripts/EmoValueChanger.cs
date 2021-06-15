using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoValueChanger : MonoBehaviour
{
    public int emoID;
    public int addValue;
    PickableObject po;
    public ClickManager cm;
    public EmotionGraph TabletRef;
    // Start is called before the first frame update

    void Start()
    {
        po = this.gameObject.GetComponent<PickableObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC-Creature" && cm.currentTargetEmotion.gameObject.name == other.name)
        {
            TabletRef.EmotionAffect(emoID, addValue);
        } else
        {
            Debug.Log("Not the good Creature");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
