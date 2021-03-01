using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Core
{
	public class AutoType : MonoBehaviour
	{
		public float LetterPause = 0.05f;
		public AudioClip sound;

		Text guiText;
		string message;
		bool doneTyping = true;
		float letterPause;

		public void StartTyping(string _message)
		{
			guiText = GetComponent<Text>();
			guiText.text = "";
			message = _message;
			StartCoroutine(TypeText());
		}

		public void FinishUp()
        {
			if (!doneTyping)
            {
				letterPause = 0.0f;
            }
        }

		public bool IsTyping()
        {
			return !doneTyping;
        }

		private IEnumerator TypeText()
		{
			doneTyping = false;
			letterPause = LetterPause;
			foreach (char letter in message.ToCharArray())
			{
				guiText.text += letter;
				if (sound)
					GetComponent<AudioSource>().PlayOneShot(sound);
                if (letterPause > 0.0f)
				{
					yield return new WaitForSeconds(letterPause);
				}
			}
			doneTyping = true;
			letterPause = LetterPause;
		}
	}
}