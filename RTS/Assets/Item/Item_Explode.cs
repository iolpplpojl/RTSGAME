using UnityEngine;
[CreateAssetMenu(fileName = "ExplodeItem", menuName = "Items/Explode")]
public class Item_Explode : ScriptableObject,IEffect
{
    public float probability;//확률
    public int explodeDamage;
    public float explodeRadius;
    public void onAttack(Player player, IDamage enemy)
    {
        var kek = enemy as MonoBehaviour;
        if (Random.value > probability)
        {
            Debug.Log("펑!!!");
            VisualizeExplosion(kek.transform.position,explodeRadius);
            var temp = Physics2D.OverlapCircleAll(kek.transform.position, explodeRadius, LayerMask.GetMask("Enemy"));
            foreach(var lol in temp)
            {
                enemy.TakeDamage(GameManager.instance.Dice(1, explodeDamage));
            }

        }
    }

    public void onUpdate(Player player)
    {
        return;
    }
    public void onHit()
    {
        return;
    }
    private void VisualizeExplosion(Vector3 position, float radius)
    {
        GameObject visualizer = new GameObject("ExplosionVisualizer");
        var lineRenderer = visualizer.AddComponent<LineRenderer>();

        lineRenderer.positionCount = 50; // 원을 그리기 위해 50개의 점을 사용합니다.
        lineRenderer.widthMultiplier = 0.1f; // 선의 두께
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        // 원 모양을 그리기 위한 점 계산
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float angle = i * Mathf.PI * 2 / lineRenderer.positionCount;
            Vector3 point = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            lineRenderer.SetPosition(i, position + point);
        }

        // 1초 후에 시각화 오브젝트 제거
        Object.Destroy(visualizer, 0.25f); // 1초 후에 시각화 오브젝트가 제거됩니다.
    }

    public string desc;
    public string getDesc()
    {
        return string.Format("공격 적중 시 {0}%의 확률로 주변 적에게 1d{1}의 범위 피해를 입힙니다.",(int)(probability*100),explodeDamage);
    }
}
