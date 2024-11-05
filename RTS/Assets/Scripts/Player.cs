using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour,IDamage
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Moveable move;
    float AttackRadius = 0.4f;
    [SerializeField]
    private float _health;
    bool Attacking = false;
    float Damage = 5;
    float AttackTime = 0.5f;
    public float AttackTimeNow = 0;
    public float Health { get => _health; set => _health = value; }
    public Transform sprite;
    Animator anim;


    public void Die()
    {
        GetComponentInParent<Goons>().memberDie(transform.parent.gameObject);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        Instantiate(GameManager.instance.Popup, transform.position, Quaternion.identity).GetComponentInChildren<Popup>().Damage = Damage;
        Debug.Log(Damage + "Ouch");
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
        anim = GetComponent <Animator>();
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
        if(move.Targeting == true) {
            if (transform.position.x - move.Target.transform.position.x > 0)
            {
                sprite.localScale = new Vector3(0.8f, 0.8f, 1f);
            }
            else
            {
                sprite.localScale = new Vector3(-0.8f, 0.8f, 1f);
            }
        }
        else
        {
            if (transform.position.x - move.TargetPos.x > 0)
            {
                sprite.localScale = new Vector3(0.8f, 0.8f, 1f);
            }
            else
            {
                sprite.localScale = new Vector3(-0.8f, 0.8f, 1f);
            }
        }
        if(move.PosArrive == false)
        {
            anim.SetBool("1_Move", true);
        }
        else
        {
            anim.SetBool("1_Move", false);

        }

    }

    // 적 클릭했을때는 따라가면서 공격해야함.
    // 땅 클릭했을때는 이동이 우선. 도착하면 가만히 있는 상태가 됨.
    // 가만히 있는 상태에서는 주변 적을 공격함..

    //우선순위 : 적 상대 = 바닥 이동 > 주변 공격
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
                else
                {
                    Attacking = false;
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
        move.isMoving = !Attacking;
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
        anim.Play("ATTACK");
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
        anim.Play("ATTACK");

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }
}
