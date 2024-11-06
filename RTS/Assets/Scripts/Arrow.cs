using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Target;
    public float Damage;
    float speed = 24.0f;
    public int Power;
    // Update is called once per frame

    void Update()
    {
        // Ÿ���� ������ �̵����� �ʵ��� ó��
        if (Target == null)
        {
            Destroy(gameObject);
        }


        // Ÿ�� ���� ���
        Vector3 direction = Target.transform.position - transform.position;

        // Ÿ���� ���� ȸ�� (��ǥ �������� ȸ��)
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Target.transform.position - transform.position);

        // Ÿ���� ���� ���� (MoveTowards ���)
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(Target.transform.position, transform.position) <= 0.0f)
        {
            Target.GetComponent<IDamage>().TakeAttack(Damage, GameManager.instance.Dice(1, 20) + Power);
            Destroy(gameObject);
        }
    }
}
