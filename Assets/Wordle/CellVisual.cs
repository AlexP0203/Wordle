using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System.Drawing;

public class CellVisual : MonoBehaviour
{
    [SerializeField] TMP_Text letterText;
    public Button button;
    
    public void updateLetter(char letter)
    {
        letterText.text = letter.ToString();
    }

    public void correctPosition()
    {
        button.GetComponent<Image>().color = new UnityEngine.Color(0.0f, 0.49f, 0.03f, 1f);
    }

    public void appearsInWord()
    {
        button.GetComponent<Image>().color = new UnityEngine.Color(0.83f, 0.85f, 0.00f, 1f);
    }

    public void notInWord()
    {
        button.GetComponent<Image>().color = new UnityEngine.Color(0.43f, 0.43f, 0.47f, 1f);
    }
}
