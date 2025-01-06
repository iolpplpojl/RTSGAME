using UnityEngine;

public class DeathCircle : NonTargetMagic, IMagic
{
    public GameObject child;
    public float width = 1;
    public float height = 1;
    override protected void Start()
    {
        base.Start();
        InventoryUI.Instance.gameObject.SetActive(false);
        transform.localScale = new Vector3(width, height, 1);

    }
    override protected void Update()
    {
        base.Update();

    }
    public override void execute()
    {
        Instantiate(child, value, Quaternion.identity, GameManager.instance.nowDungeon.transform);
        Debug.Log("파이어볼");
        base.execute();
    }
}
