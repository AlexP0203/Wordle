using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class Model : MonoBehaviour
{
    [SerializeField] TextAsset myTextAsset;
    Controller controller;
    View view;
    string[] importWords;
    char[] wordArray;
    char[] guessArray;
    string word;
    string guess;
    int numGuesses = 6;
    int row;

    

    // Start is called before the first frame update
    void Start()
    {
        controller = FindAnyObjectByType<Controller>();
        view = FindAnyObjectByType<View>();
    }

    public void Setup()
    {
        importWords = myTextAsset.ToString().Trim().Split('\n');
        word = (importWords[Random.Range(0, importWords.Length)]).Trim();
        wordArray = word.ToCharArray();
        Debug.Log(word);
    }

    public void playerGuess(string playerGuess)
    {

        guess = playerGuess;
        guessArray = guess.ToCharArray();
        if (guess.Equals(word))
        {
           view.correct();
           controller.deactivateButton();
        }
        else
        {
            numGuesses--;
            if (numGuesses == 0)
            {
               view.lose(word);
               controller.deactivateButton();
            }
        }

        for (int i = row; i < row+1;i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if (wordArray[j] == guessArray[j])
                {
                    view.tileState(i, j, 1);
                }
                else if (wordArray.Contains(guessArray[j]))
                {
                    view.tileState(i, j, 2);
                }
                else
                {
                    view.tileState(i, j, 3);
                }

            } 
        }
        row++;
    }
}
