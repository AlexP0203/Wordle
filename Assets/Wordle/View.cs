using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class View : MonoBehaviour
{
    [SerializeField] Transform[] rows;
    [SerializeField] TMP_Text header;
    string guess;
    // Start is called before the first frame update
    public void Setup()
    {
        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 5; c++)
            {
                rows[r].GetChild(c).GetComponent<CellVisual>().updateLetter(' ');
            }
        }
    }

    public void showPlayerGuess(int r, string playerGuess)
    {
        string guess = playerGuess;
        Debug.Log(guess);

        for (int c = 0; c < 5; c++)
        {
            rows[r].GetChild(c).GetComponent<CellVisual>().updateLetter(guess[c]);
        }
        
    }

    public void tileState(int r, int c, int state)
    {
        if(state == 1)
        {
            rows[r].GetChild(c).GetComponent<CellVisual>().correctPosition();
        }

        if (state == 2)
        {
            rows[r].GetChild(c).GetComponent<CellVisual>().appearsInWord();
        }

        if (state == 3)
        {
            rows[r].GetChild(c).GetComponent<CellVisual>().notInWord();
        }
    }

    public void correct()
    {
        header.text = "Correct you win.";
    }

    public void lose(string guess)
    {
        header.text = "Sorry. The word is " + guess.ToUpper() +  ". You Lose.";
    }

    public void wordLengthCheck()
    {
        header.text = "Please enter a 5 letter word.";
    }

    public void checkIfRealWord()
    {
        header.text = "Not a real word.";
    }

    public void wordAlreadyUsed()
    {
        header.text = "Already tried this word.";
    }

    public void realWord()
    {
        header.text = "";
    }
}
