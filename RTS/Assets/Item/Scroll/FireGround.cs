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

        Debug.Log("���̾");
        base.execute();
    }
}
