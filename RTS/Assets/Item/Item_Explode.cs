using UnityEngine;
[CreateAssetMenu(fileName = "ExplodeItem", menuName = "Items/Explode")]
public class Item_Explode : ScriptableObject,IEffect
{
    public float probability;//Ȯ��
    public int explodeDamage;
    public float explodeRadius;
    public void onAttack(Player player, IDamage enemy)
    {
        var kek = enemy as MonoBehaviour;
        if (Random.value > probability)
        {
            Debug.Log("��!!!");
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

        lineRenderer.positionCount = 50; // ���� �׸��� ���� 50���� ���� ����մϴ�.
        lineRenderer.widthMultiplier = 0.1f; // ���� �β�
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        // �� ����� �׸��� ���� �� ���
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float angle = i * Mathf.PI * 2 / lineRenderer.positionCount;
            Vector3 point = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            lineRenderer.SetPosition(i, position + point);
        }

        // 1�� �Ŀ� �ð�ȭ ������Ʈ ����
        Object.Destroy(visualizer, 0.25f); // 1�� �Ŀ� �ð�ȭ ������Ʈ�� ���ŵ˴ϴ�.
    }

    public string desc;
    public string getDesc()
    {
        return string.Format("���� ���� �� {0}%�� Ȯ���� �ֺ� ������ 1d{1}�� ���� ���ظ� �����ϴ�.",(int)(probability*100),explodeDamage);
    }
}
