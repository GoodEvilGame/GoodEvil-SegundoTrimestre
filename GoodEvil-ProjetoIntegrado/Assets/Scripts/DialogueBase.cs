using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{

    public class DialogueBase : MonoBehaviour
    {
        protected IEnumerator WriteText(string input, Text textHolder, Font textFont, AudioClip sound)
        {
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(0.05f);

            }
        }
        
    }
}