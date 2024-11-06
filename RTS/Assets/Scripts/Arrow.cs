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
        // 타겟이 없으면 이동하지 않도록 처리
        if (Target == null)
        {
            Destroy(gameObject);
        }


        // 타겟 방향 계산
        Vector3 direction = Target.transform.position - transform.position;

        // 타겟을 향해 회전 (목표 방향으로 회전)
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Target.transform.position - transform.position);

        // 타겟을 향해 전진 (MoveTowards 사용)
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(Target.transform.position, transform.position) <= 0.0f)
        {
            Target.GetComponent<IDamage>().TakeAttack(Damage, GameManager.instance.Dice(1, 20) + Power);
            Destroy(gameObject);
        }
    }
}
