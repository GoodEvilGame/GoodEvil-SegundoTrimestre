using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{

    public class DialogueLine : DialogueBase
    {

        private Text textHolder;
        [Header("TextOptions")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        private void Awake()
        {
            textHolder = GetComponent<Text>();

            StartCoroutine(WriteText(input, textHolder, textColor, textFont));
        }
    }
}
