using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamage
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Moveable move;
    public float AttackRadius = 0.2f;
    bool Attacking = false;

    float AttackTime = 1.0f;
    float AttackTimeNow = 0f;
    float Damage;
    
    public int Defence;
    public int Power = 4;
    [SerializeField] float _health;
    public float Health { get => _health; set => _health = value; }

    void Start()
    {
        move = GetComponent<Moveable>();
        Damage = 12;    
        StartCoroutine(MovePattern());
    }
    public void SetTarget(GameObject Target)
    {
        move.StartMove(Target);

    }

    public bool TakeAttack(float Damage, int Power)
    {
       if(Power > 10 + Defence)
        {
            TakeDamage(GameManager.instance.Dice(1,(int)Damage)) ;
            return true;
        }
        else
        {
            Instantiate(GameManager.instance.Popup, transform.position, Quaternion.identity).GetComponentInChildren<Popup>().Damage = -1;
            Debug.Log("ºø³ª°¨ ! : " + Health);
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var temp = Physics2D.OverlapCircle(transform.position, AttackRadius,LayerMask.GetMask("Player"));
        if(temp != null)
        {
            Attacking = true;
            Attack(temp.GetComponent<IDamage>());
            Debug.Log("EnemyAttack");

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
            Target.TakeAttack(Damage, GameManager.instance.Dice(1, 20) + Power);
            AttackTimeNow = AttackTime;

        }
    }
    IEnumerator MovePattern()
    {
        while (true)
        {
            var temp = Physics2D.OverlapCircleAll(transform.position, 3.0f, LayerMask.GetMask("Player"));
            if (temp.Length != 0)
            {
                GameObject near = null;
                foreach (var lol in temp)
                {
                    var kek = lol.gameObject;
                    if (near == null)
                    {
                        near = kek;
                    }
                    if (Vector2.Distance(kek.transform.position, transform.position) < Vector2.Distance(near.transform.position, transform.position))
                    {
                        near = kek;
                    }
                }
                if (near != null)
                {
                    move.StartMove(near.gameObject);
                }
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
        if (move.Target == null)
        {
            var temp = Physics2D.OverlapCircle(transform.position, 10000, LayerMask.GetMask("Player"));
            GetComponentInParent<EnemyGoons>().setMove(temp.gameObject);
        }
    }

    public void TakeHeal()
    {
        throw new System.NotImplementedException();
    }
}
