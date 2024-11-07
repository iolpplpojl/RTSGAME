using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TMP_Text m_Text;
    public float Damage;
    Vector2 RandomDirec;
    private void Start()
    {
         m_Text = GetComponent<TMP_Text>();
         RandomDirec = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
         RandomDirec.Normalize();
         transform.position = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

    }
    private void Update()
    {
        if (Damage != -1)
        {
            m_Text.text = Damage.ToString();
        }
        else
        {
            m_Text.text = "ºø³ª°¨!";
            m_Text.color = Color.gray;
        }
        transform.Translate(RandomDirec * 0.4f * Time.deltaTime);

    }

}
