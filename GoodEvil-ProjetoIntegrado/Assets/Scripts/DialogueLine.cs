using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{

    public class DialogueLine : DialogueBase
    {

        private Text textHolder;
        [SerializeField] private string input;

        private void Awake()
        {
            textHolder = GetComponent<Text>();

            StartCoroutine(WriteText(input, textHolder));
        }
    }
}
