using System.Collections;
using UnityEngine;

public class DeathCircle_Execute : MonoBehaviour
{

    public int damage;
    Animator anim;
    public void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Execute());
            
    }

    IEnumerator Execute()
    {
        anim.Play("MagicCircle_Prepare");
        yield return new WaitForSeconds(1.0f);
        anim.Play("MagicCircle_Execute");
        var temp = Physics2D.OverlapCircleAll(transform.position, 2.5f, LayerMask.GetMask("Enemy"));
        foreach (var lol in temp)
        {
            lol.GetComponent<IDamage>().TakeDamage(GameManager.instance.Dice(1, damage));
        }
        yield return null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;  // 구체의 색상 설정
        Gizmos.DrawWireSphere(transform.position, 2.5f);  // 구체 그리기
    }
}
