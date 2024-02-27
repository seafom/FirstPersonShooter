using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private Text damageText;

    private void Awake()
    {
        damageText = GetComponent<Text>();
    }

    public void DisplayDamageText(float damageAmount)
    {
        damageText.text = "-" + damageAmount.ToString(); // Display the damage amount as text
        Destroy(gameObject, 1f); // Destroy the text object after 1 second (adjust as needed)
    }
}