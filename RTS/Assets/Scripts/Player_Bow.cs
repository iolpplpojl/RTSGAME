using UnityEngine;

public class Player_Bow : Player
{

    public GameObject Arrow;
    override public void Attack()
    {
        Debug.Log("Attack");
        _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" 애니메이션으로 0초 전환

        Attacking = true;
        if (AttackTimeNow <= 0)
        {
            foreach (var kek in transform.parent.parent.GetComponent<Goons>().items)
            {
                kek.onAttack(this, move.Target.GetComponent<IDamage>());
            }
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
        _prefabs._anim.CrossFade("ATTACK", 0f, 0); // "EVENT" 애니메이션으로 0초 전환

        if (AttackTimeNow <= 0)
        {
            var temp = Instantiate(Arrow, transform.position, Quaternion.LookRotation(Vector3.forward, Target.transform.position - transform.position)) ;
            temp.GetComponent<Arrow>().items = transform.parent.parent.GetComponent<Goons>().items;
            temp.GetComponent<Arrow>().owner = this;
            temp.GetComponent<Arrow>().Damage = Damage;
            temp.GetComponent<Arrow>().Target = Target;
            temp.GetComponent<Arrow>().Power = Power;

            AttackTimeNow = AttackTime;
        }
        _prefabs.PlayAnimation(PlayerState.ATTACK, 0);
    

    }
}
