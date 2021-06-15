using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionGraph : MonoBehaviour
{
    [SerializeField] ClickManager cm;
    public int[] emoTankPrint;
    [SerializeField] Slider[] emotionValues;
    [SerializeField] Slider[] ExpectedEmoValues;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmotionAffect(int emoValue, int addvalue)
    {
        //if (addvalue>0)
        //{
        //  Clignotte en vert
        //} else{clignotte en rouge}
        emotionValues[emoValue].value = emotionValues[emoValue].value + addvalue;
        Verification();
    }

    public void Verification()
    {
        //Debug.Log("VERIFICATION PROCESS");
        for (int i = 0; i < emotionValues.Length; i++)
        {
            if(emotionValues[i].value <= ExpectedEmoValues[i].value+2 && emotionValues[i].value >= ExpectedEmoValues[i].value - 2)
            {
                ExpectedEmoValues[i].targetGraphic.gameObject.GetComponent<Image>().color = Color.green;
            } else
            {
                ExpectedEmoValues[i].targetGraphic.gameObject.GetComponent<Image>().color = Color.red;
            }
            //Debug.Log("VERIFICATION PROCESS: DONE FOR "+i.ToString());
        }
    }

    public void LinkOn()
    {
        emoTankPrint = cm.currentTargetEmotion.EmoTank;
        this.gameObject.GetComponent<Animator>().SetBool("TabletIsUp", true);
        for (int i = 0; i < emotionValues.Length; i++)
        {
           emotionValues[i].value = emoTankPrint[i];
        }
    }
    public void LinkOff()
    {
        this.gameObject.GetComponent<Animator>().SetBool("TabletIsUp", false);
        for (int i = 0; i < emotionValues.Length; i++)
        {
            emoTankPrint[i] = Mathf.RoundToInt(emotionValues[i].value);
            emotionValues[i].value = 0;
        }
        cm.currentTargetEmotion.EmoTank = emoTankPrint;
        emoTankPrint = null;
    }
}
