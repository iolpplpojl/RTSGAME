using UnityEngine;

public class Player_Bow : Player
{

    public GameObject Arrow;
    override public void Attack()
    {
        Debug.Log("Attack");

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            var temp = Instantiate(Arrow, transform.position, Quaternion.LookRotation(Vector3.forward, move.Target.transform.position - transform.position));
            temp.GetComponent<Arrow>().Damage = Damage;
            temp.GetComponent<Arrow>().Target = move.Target;
            AttackTimeNow = AttackTime;
        }
        anim.Play("ATTACK");
    }

    override public void Attack(GameObject Target)
    {
        Debug.Log("ArriveAttack");

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            var temp = Instantiate(Arrow, transform.position, Quaternion.LookRotation(Vector3.forward, Target.transform.position - transform.position)) ;
            temp.GetComponent<Arrow>().Damage = Damage;
            temp.GetComponent<Arrow>().Target = Target;
            AttackTimeNow = AttackTime;
        }
        anim.Play("ATTACK");

    }
}
