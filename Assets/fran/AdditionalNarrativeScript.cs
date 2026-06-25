using System.Collections;
using TMPro;
using UnityEngine;

public class AdditionalNarrativeScript : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.03f;

    public IEnumerator TypeText(TMP_Text textComponent, string text)
    {
        textComponent.text = "";

        foreach (char character in text)
        {
            textComponent.text += character;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}