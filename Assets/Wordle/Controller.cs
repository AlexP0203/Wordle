using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] TextAsset myTextAsset;
    public Button newButton;
    Model model;
    View view;
    string[] guessArray = new string[6];
    string[] importWords;
    string guess;
    int row;

    // Start is called before the first frame update
    void Start()
    {
        importWords = myTextAsset.ToString().Trim().Split('\n');
        importWords.ToString().Trim();
        model = FindAnyObjectByType<Model>();
        view = FindAnyObjectByType<View>();
        newButton.interactable = true;
        gameSetup();
    }

    void gameSetup()
    {
        input.text = "";
        model.Setup();
        view.Setup();
    }

    public void submitGuess()
    {
        guess = input.text.ToString().Trim();

        


        for (int i = 0; i < importWords.Length; i++)
        {
            importWords[i] = importWords[i].Trim();
        }

        if (guess.Length < 5)
        {
            view.wordLengthCheck();
        }

        else if (importWords.Contains(guess))
        {
            view.realWord();
            if(row > 0)
            {
                if (guessArray.Contains(guess))
                {
                    view.wordAlreadyUsed();
                }

                else
                {
                    model.playerGuess(guess);
                    view.showPlayerGuess(row, guess);
                    guessArray[row] = guess;
                    row++;
                    
                }
            }
            else
            {
                model.playerGuess(guess);
                view.showPlayerGuess(row, guess);
                guessArray[row] = guess;
                    row++;
            }
        }
        else
        {
            view.checkIfRealWord();
        }
    }

    public void deactivateButton()
    {
        newButton.interactable = false;
    }
    
}
