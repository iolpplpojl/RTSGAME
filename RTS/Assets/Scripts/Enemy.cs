using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamage
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Moveable move;
    float AttackRadius = 0.2f;
    bool Attacking = false;

    float AttackTime = 1.0f;
    float AttackTimeNow = 0f;
    float Damage;

    [SerializeField] float _health;
    public float Health { get => _health; set => _health = value; }

    void Start()
    {
        move = GetComponent<Moveable>();
        Damage = Random.Range(1, 8);
        StartCoroutine(MovePattern());
    }

    // Update is called once per frame
    void Update()
    {
        var temp = Physics2D.OverlapCircle(transform.position, AttackRadius,LayerMask.GetMask("Player"));
        if(temp != null)
        {
            Attacking = true;
            Attack(temp.GetComponent<IDamage>());
        }
        else
        {
            Attacking = false;
        }

        move.isMoving = !Attacking;

        CoolDown();
    }
    void CoolDown()
    {
        if(AttackTimeNow >= 0){
            AttackTimeNow -= Time.deltaTime;
        }
    }

    void Attack(IDamage Target)
    {
        if (AttackTimeNow <= 0)
        {
            Target.TakeDamage(Damage);
            AttackTimeNow = AttackTime;
        }
    }
    IEnumerator MovePattern()
    {
        while (true)
        {
            var temp = Physics2D.OverlapCircle(transform.position,5.0f,LayerMask.GetMask("Player"));
            if (temp)
            {
                move.StartMove(temp.gameObject);
            }
            yield return null;
        }
    }

    public void Die()
    {
        GetComponentInParent<IGoons>().memberDie(gameObject);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        Instantiate(GameManager.instance.Popup, transform.position, Quaternion.identity).GetComponentInChildren<Popup>().Damage = Damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void TakeHeal()
    {
        throw new System.NotImplementedException();
    }
}
