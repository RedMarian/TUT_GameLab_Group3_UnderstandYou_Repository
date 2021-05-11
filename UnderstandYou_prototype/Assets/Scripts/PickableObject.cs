using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform playerHand;
    public bool isDown;
    public InputManager inputManager;

    public void HoldUp()
    {
        isDown = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = playerHand.position;
        this.transform.parent = GameObject.Find("ClickHitBox").transform;
    }

    public void LetItGo()
    {
        isDown = false;
        GetComponent<BoxCollider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        inputManager.objectInHand = null;
    }


}
