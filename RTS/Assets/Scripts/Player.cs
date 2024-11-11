using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour,IDamage
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected Moveable move;
    [SerializeField] float AttackRadius = 0.4f;
    [SerializeField]
    private float _health;
    protected bool Attacking = false;
    public float Damage = 12;
    public float AttackTime = 0.5f;
    protected float AttackTimeNow = 0;
    public float Health { get => _health; set => _health = value; }
    public float MaxHealth;
    public Transform sprite;
    protected  Animator anim;
    public SPUM_Prefabs _prefabs;
    public Dictionary<PlayerState, int> IndexPair = new();



    public int Power;
    public int Defence;


    public void Die()
    {
        GetComponentInParent<Goons>().memberDie(transform.parent.gameObject);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    //    Instantiate(GameManager.instance.Popup, transform.position, Quaternion.identity).GetComponentInChildren<Popup>().Damage = Damage;
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
        _prefabs = GetComponentInParent<SPUM_Prefabs>();
            if (!_prefabs.allListsHaveItemsExist())
            {
                _prefabs.PopulateAnimationLists();
            }
        _prefabs.OverrideControllerInit();
        foreach (PlayerState state in Enum.GetValues(typeof(PlayerState)))
        {
            IndexPair[state] = 0;
        }
        _prefabs._anim.SetFloat("AttackTime", 1 / AttackTime);
        StartCoroutine(onUpdater());
        MaxHealth = Health;
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
        if(move.isMoving == true)
        {
            anim.SetBool("1_Move", true);
        }
        else
        {
            anim.SetBool("1_Move", false);

        }

    }

    IEnumerator onUpdater()
    {
        while (true) {
            foreach (var temp in transform.parent.parent.GetComponent<Goons>().items)   
            {
                temp.onUpdate(this);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnMouseUpAsButton()
    {
        // Runs when button is released
        transform.parent.parent.parent.GetComponent<GoonsManager>().Select(transform.parent.parent.GetComponent<Goons>()) ;
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
                    Attack(move.Target);
                }
                else
                {
                    Attacking = false;
                    move.isMoving = true;
                }

                var temp = Physics2D.OverlapCircleAll(transform.position, 3.0f, LayerMask.GetMask("Enemy"));
                if (temp.Length != 0)
                {
                    GameObject near = null;
                    foreach (var lol in temp)
                    {
                        var kek = lol.gameObject;
                        if(near == null)
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
                        move.Target = near;
                    }
                }
            }
            else
            {
                var temp = Physics2D.OverlapCircleAll(transform.position, 3.0f, LayerMask.GetMask("Enemy"));
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
                        move.Target = near;
                    }
                }
                else
                {
                    Attacking = false;
                    SetMoveDirection(transform.position);

                }
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
                    Attack(temp.gameObject);
                }
            }
            else
            {
                Attacking = false;
            }
        }
        if (Attacking == true)
        {
            move.isMoving = !Attacking;
        }
    }

    public bool TakeAttack(float Damage, int Power)
    {
        if (Power > 10 + Defence)
        {
            TakeDamage(GameManager.instance.Dice(1, (int)Damage));
            return true;

        }
        else
        {
            Instantiate(GameManager.instance.Popup, transform.position, Quaternion.identity).GetComponentInChildren<Popup>().Damage = -1;
            Debug.Log("빗나감 ! : " + Health);
            return false;
        }
    }

    public void Cooldown()
    {
        if(AttackTimeNow >= 0)
        {
            AttackTimeNow -= Time.deltaTime;
        }
    }
    public virtual void Attack()
    {
        Debug.Log("Attack");
        _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" 애니메이션으로 0초 전환

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            move.Target.GetComponent<IDamage>().TakeAttack(Damage, GameManager.instance.Dice(1,20) + Power);
            AttackTimeNow = AttackTime;
        }
        anim.Play("ATTACK");
    }

    public virtual void Attack(GameObject Target)
    {
        Debug.Log("ArriveAttack");
        _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" 애니메이션으로 0초 전환

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            if (Target.GetComponent<IDamage>().TakeAttack(Damage, GameManager.instance.Dice(1, 20) + Power))
            {
                foreach (var temp in transform.parent.parent.GetComponent<Goons>().items)
                {
                    temp.onAttack(this, Target.GetComponent<IDamage>());
                }
            }
            AttackTimeNow = AttackTime;
        }
        anim.Play("ATTACK");

    }

    public void Heal(int amount)
    {
        if(MaxHealth < Health + amount)
        {
            Health = MaxHealth;
            Debug.Log("최대체력 회복");
        }
        else
        {
            Health += amount;
            Debug.Log(" 회복");

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }
}
