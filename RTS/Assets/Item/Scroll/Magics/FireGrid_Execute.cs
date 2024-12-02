using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrid_Execute : MonoBehaviour
{
    public float duration = 5;
    public float maxdamage_tick = 6;
    List<IDamage> enemy = new List<IDamage>();
    public void Start()
    {
        StartCoroutine(FireDamage());
    }

    IEnumerator FireDamage()
    {
        for (int i = 0; i < (int)(duration / 0.5f); i++) {
            
            for (int k = enemy.Count -1;k >= 0; k--)
            {
                IDamage enemy = this.enemy[k];
                if (enemy != null)
                {
                    enemy.TakeAttack(maxdamage_tick, GameManager.instance.Dice(10, 20));
                }
            } // for ���������� �ٲٱ�;
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("����");
        enemy.Add(other.GetComponent<IDamage>());
    }

    // �ٸ� ��ü�� Ʈ���ſ��� ���� �� ȣ��˴ϴ�.
    private void OnTriggerExit2D(Collider2D other)
    {
        enemy.Remove(other.GetComponent<IDamage>());
    }
}
