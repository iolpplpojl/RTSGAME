using UnityEngine;

public class FireGround : NonTargetMagic, IMagic
{
    public GameObject child;    

    override protected void Update()
    {
        base.Update();
    }
    public override void execute()
    {

        Debug.Log("파이어볼");
        base.execute();
    }
}
