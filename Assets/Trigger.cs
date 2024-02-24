using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Text player1;
    public GameObject playerOneWin;
    private int score;
 
 public int winScore =15;
 
    // Use this for initialization
    void Start () 
    {
   
        player1.text = "";
        playerOneWin.SetActive(false);
 
    }
 
 
    // Update is called once per frame
    void Update ()
    {
   
        player1.text = "" + score;

        if (score >= winScore)
        {
            playerOneWin.SetActive(true); 
        }
 
    }
 
 
    void OnTriggerEnter(Collider coll) {
 
        score = score + 1;
 
    }
 
 
}
