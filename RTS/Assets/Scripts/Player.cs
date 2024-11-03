using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour,IDamage
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Moveable move;
    float AttackRadius = 1.5f;
    [SerializeField]
    private float _health;
    bool Attacking = false;
    float Damage = 5;
    float AttackTime = 0.5f;
    public float AttackTimeNow = 0;
    public float Health { get => _health; set => _health = value; }


    public void Die()
    {
        GetComponentInParent<Goons>().memberDie(gameObject);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void TakeHeal()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        move= GetComponent<Moveable>();
    }


    public void SetMoveDirection(GameObject Target)
    {
        move.StartMove(Target);
    }
    public void SetMoveDirection(Vector2 Position)
    {
        move.StartMove(Position);

    }
    // Update is called once per frame
    void Update()
    {
        Health = _health;

        Cooldown();
        MovePattern();
    }

    // �� Ŭ���������� ���󰡸鼭 �����ؾ���.
    // �� Ŭ���������� �̵��� �켱. �����ϸ� ������ �ִ� ���°� ��.
    // ������ �ִ� ���¿����� �ֺ� ���� ������..

    //�켱���� : �� ��� = �ٴ� �̵� > �ֺ� ����
    public void MovePattern()
    {
        if(move.Targeting == true)
        {
            if (move.Target != null)
            {
                if (Vector2.Distance(transform.position, move.Target.transform.position) < AttackRadius)
                {
                    Attack(move.Target.GetComponent<IDamage>());
                }
            }
            else
            {
                Attacking = false;
            }
        }
        else
        {
            if(move.PosArrive == true)
            {
                var temp = Physics2D.OverlapCircle(transform.position, AttackRadius, LayerMask.GetMask("Enemy"));
                if (temp != null)
                {
                    Attacking = true;
                    Attack(temp.GetComponent<IDamage>());
                }
            }
            else
            {
                Attacking = false;
            }
        }
    }

    public void Cooldown()
    {
        if(AttackTimeNow >= 0)
        {
            AttackTimeNow -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        Debug.Log("Attack");

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            move.Target.GetComponent<IDamage>().TakeDamage(Damage);
            AttackTimeNow = AttackTime;
        }
    }

    public void Attack(IDamage Target)
    {
        Debug.Log("ArriveAttack");

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            Target.TakeDamage(Damage);
            AttackTimeNow = AttackTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }
}
