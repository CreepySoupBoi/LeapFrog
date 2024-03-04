using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Text player1Text;
    public Text player2Text;
    public GameObject playerOneWin;
    public GameObject playerTwoWin;
    public int score1;
    public int score2;
     public GameObject player1; // Player 1 game object
    public GameObject player2; // Player 2 game object
    private BoxCollider player1Collider; // Player 1 box collider
    private BoxCollider player2Collider; // Player 2 box collider
 
 public int winScore =15;
 
    // Use this for initialization
    void Start () 
    {
   
        player1Text.text = "";
        player2Text.text = "";
        playerOneWin.SetActive(false);
        playerTwoWin.SetActive(false);
        player1Collider = player1.GetComponent<BoxCollider>();
        player2Collider = player2.GetComponent<BoxCollider>();
 
    }
 
 
    // Update is called once per frame
    void Update ()
    {
   
        player1Text.text = "" + score1;
        player2Text.text = "" + score2;

        if (score1 >= winScore)
        {
            playerOneWin.SetActive(true); 
        }
        else if (score2 >= winScore)
        {
            playerTwoWin.SetActive(true);
        }
 
    }
 
 
    void OnTriggerEnter(Collider coll) {
 
        if (coll == player1Collider)
        {
            score1 = score1 + 1;
        }
        else if (coll == player2Collider)
        {
            score2 = score2 + 1;
        }
 
    }
 
 
}
