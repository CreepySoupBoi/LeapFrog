using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger2 : MonoBehaviour
{
    public Text player2;
    public GameObject playerTwoWin;
    private int score;
 
 public int winScore =15;
 
    // Use this for initialization
    void Start () 
    {
   
        player2.text = "";
        playerTwoWin.SetActive(false);
 
    }
 
 
    // Update is called once per frame
    void Update ()
    {
   
        player2.text = "" + score;

        if (score >= winScore)
        {
            playerTwoWin.SetActive(true); 
        }
 
    }
 
 
    void OnTriggerEnter(Collider coll) {
 
        score = score + 1;
 
    }
 
 
}
