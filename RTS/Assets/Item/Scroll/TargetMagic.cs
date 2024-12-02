using UnityEngine;

public class TargetMagic : Magic
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Target;
    public LayerMask TargetLayer;



    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity,TargetLayer.value);
        Debug.Log(TargetLayer.value);
        if (hit.collider != null)
        {
            Target = hit.collider.gameObject;
        }
        else
        {
            Target = null;
        }
    }
}
