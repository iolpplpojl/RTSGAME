using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TMP_Text m_Text;
    public float Damage;

    private void Start()
    {
        m_Text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
       m_Text.text = Damage.ToString();
    }

}
