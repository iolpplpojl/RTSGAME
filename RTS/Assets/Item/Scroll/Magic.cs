using UnityEngine;
public abstract class Magic : MonoBehaviour, IMagic
{
    public GameObject action;
    protected MagicParameter para;

    public int slotNum;

    void Start()
    {
        InventoryUI.Instance.gameObject.SetActive(false);
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            execute();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            close();
        }
    }

    public virtual void execute() 
    {
        GameManager.instance.storage[slotNum] = null;

        close();
    }
    public void close()
    {
        Destroy(gameObject);
    }
}
