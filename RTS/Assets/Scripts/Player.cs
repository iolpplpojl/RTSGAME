using System;
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
    private void OnMouseUpAsButton()
    {
        // Runs when button is released
        transform.parent.parent.parent.GetComponent<GoonsManager>().Select(transform.parent.parent.GetComponent<Goons>()) ;
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
                    Attack(move.Target);
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
                    Attack(temp.gameObject);
                }
            }
            else
            {
                Attacking = false;
            }
        }
        move.isMoving = !Attacking;
    }

    public void TakeAttack(float Damage, int Power)
    {
        if (Power > 10 + Defence)
        {
            TakeDamage(GameManager.instance.Dice(1, (int)Damage));
        }
        else
        {
            Instantiate(GameManager.instance.Popup, transform.position, Quaternion.identity).GetComponentInChildren<Popup>().Damage = -1;
            Debug.Log("������ ! : " + Health);
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
        _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" �ִϸ��̼����� 0�� ��ȯ

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
                _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" �ִϸ��̼����� 0�� ��ȯ

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            Target.GetComponent<IDamage>().TakeAttack(Damage, GameManager.instance.Dice(1, 20) + Power);
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
