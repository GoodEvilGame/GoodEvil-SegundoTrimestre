using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{

    public class DialogueLine : DialogueBase
    {

        private Text textHolder;
        [Header("TextOptions")]
        [SerializeField] private string input;
        [SerializeField] private Font textFont;

        [Header("Character Image")]
        [SerializeField] private Sprite CharacterSprite;
        [SerializeField] private Image ImageHolder;

        [Header("Text Sound")]
        [SerializeField] private AudioClip txtSound;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            StartCoroutine(WriteText(input, textHolder, textFont, txtSound));

            ImageHolder.sprite = CharacterSprite;
            ImageHolder.preserveAspect = true;
        }
    }
}
