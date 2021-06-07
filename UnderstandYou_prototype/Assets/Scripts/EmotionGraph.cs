using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionGraph : MonoBehaviour
{
    [SerializeField] Slider[] emotionValues;
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
        emoValue = emoValue + addvalue;
    }
}
