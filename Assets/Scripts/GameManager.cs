using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SnapController controller;
    
    public int totalMoves;
    public Text MovesText;
    public static GameManager singleton;
    public int scores;
    public bool win = false;
    public bool lose = false;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject LoseText;

    private void Start()
    {
        if(singleton == null)
        {
            singleton = this;
        }
    }
    private void Update()
    {
        int moves = controller.Moves;
        MovesText.text = "Moves  " + moves + "/" + totalMoves;
        Debug.Log("Scores = " + scores);
        if(scores>=18)
        {
            win = true;
            

        }
        if (moves >= 30)
        {
            lose = true;
            

        }
        if(win)
        { winText.SetActive(true); }
        else if(lose)
        { LoseText.SetActive(true); ; }
        if (win || lose)
        {
            controller.enabled = false;
        }

        
    }

    
}
