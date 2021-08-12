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

	 [Header("Character Image")]
	[SerializeField] private Sprite CharacterSprite;
	[SerializeField] private Image ImageHolder;
	
        private void Awake()
        {
            textHolder = GetComponent<Text>();
	    textHolder.text = "";

            StartCoroutine(WriteText(input, textHolder));
		
	    ImageHolder.sprite = CharacterSprite;
	    ImageHolder.preserveAspect = true;	
        }
    }
}
