using UnityEngine;
using System.Collections;
using TMPro;

public class ShowTextForDuration : MonoBehaviour
{
    public TextMeshPro proximityText; // Référence au composant TextMeshPro
    public float displayDuration = 5f; // Durée pendant laquelle le texte reste affiché


    private void Start()
    {
        if (proximityText != null)
        {
            proximityText.gameObject.SetActive(false); // Assurez-vous que le texte est désactivé au début
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ShowText();
        }
    }

    void ShowText()
    {
        proximityText.gameObject.SetActive(true);
        Invoke("HideText", displayDuration);
    }

    void HideText()
    {
        proximityText.gameObject.SetActive(false);
    }
}