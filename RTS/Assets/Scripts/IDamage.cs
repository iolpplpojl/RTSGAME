using UnityEngine;

public interface IDamage
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float Health {  get; set; }
    void Die();
    public void TakeDamage(float Damage);
    public bool TakeAttack(float Damage, int Power); // 대미지, 명중률
    public void TakeHeal();
}
