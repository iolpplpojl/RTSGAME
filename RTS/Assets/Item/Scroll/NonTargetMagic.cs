using UnityEngine;

public class NonTargetMagic : Magic
{
    protected Vector3 value;

    override protected void Update()
    {
        base.Update();
        value = Camera.main.ScreenToWorldPoint
                (Input.mousePosition);
        value.z = 0;
        transform.position = value;
    }
    public override void execute()
    {
        base.execute();
    }
}
