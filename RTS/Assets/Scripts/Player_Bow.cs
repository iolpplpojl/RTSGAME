using UnityEngine;

public class Player_Bow : Player
{

    public GameObject Arrow;
    override public void Attack()
    {
        Debug.Log("Attack");
        _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" �ִϸ��̼����� 0�� ��ȯ

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            var temp = Instantiate(Arrow, transform.position, Quaternion.LookRotation(Vector3.forward, move.Target.transform.position - transform.position));
            temp.GetComponent<Arrow>().Damage = Damage;
            temp.GetComponent<Arrow>().Target = move.Target;
            temp.GetComponent<Arrow>().Power = Power;
            AttackTimeNow = AttackTime;
        }
        _prefabs.PlayAnimation(PlayerState.ATTACK, 0);
    }

    override public void Attack(GameObject Target)
    {
        Debug.Log("ArriveAttack");

        Attacking = true;
        _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" �ִϸ��̼����� 0�� ��ȯ

        if (AttackTimeNow <= 0)
        {
            var temp = Instantiate(Arrow, transform.position, Quaternion.LookRotation(Vector3.forward, Target.transform.position - transform.position)) ;
            temp.GetComponent<Arrow>().Damage = Damage;
            temp.GetComponent<Arrow>().Target = Target;
            temp.GetComponent<Arrow>().Power = Power;

            AttackTimeNow = AttackTime;
        }
        _prefabs.PlayAnimation(PlayerState.ATTACK, 0);
    

    }
}
