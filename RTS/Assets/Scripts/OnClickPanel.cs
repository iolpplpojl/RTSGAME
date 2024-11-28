using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class OnClickPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static OnClickPanel instance;
    public GameObject parent;
    public GameObject prefab;
    public int slotNum;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void setUp(int num)
    {
        foreach(Transform kek in parent.transform)
        {
            Destroy(kek.gameObject);
        }
        GameObject temp;
        Button buttn;
        slotNum = num;
        if (GameManager.instance.storage[slotNum] is Item)
        {
            temp = Instantiate(prefab, parent.transform);
            buttn = temp.GetComponent<Button>();
            buttn.onClick.AddListener(Equip);
            temp.GetComponentInChildren<TMP_Text>().text = "장착";
            temp.GetComponent<Image>().color = new Color(0.9790583f, 0.5333334f, 1f);

        }
        else if (GameManager.instance.storage[slotNum] is Potion)
        {
            temp = Instantiate(prefab, parent.transform);
            buttn = temp.GetComponent<Button>();
            buttn.onClick.AddListener(UsePotion);
            temp.GetComponent<Image>().color = new Color(0.9790583f, 0.5333334f, 1f);
            temp.GetComponentInChildren<TMP_Text>().text = "마시기";
        }
        else if (GameManager.instance.storage[slotNum] is Scroll)
        {
            temp = Instantiate(prefab, parent.transform);
            buttn = temp.GetComponent<Button>();
            buttn.onClick.AddListener(UseScroll);
            temp.GetComponent<Image>().color = new Color(0.9790583f, 0.5333334f, 1f);
            temp.GetComponentInChildren<TMP_Text>().text = "사용";
        }
        temp = Instantiate(prefab, parent.transform);
        buttn = temp.GetComponent<Button>();
        buttn.onClick.AddListener(Discard);
        temp.GetComponentInChildren<TMP_Text>().text = "버리기";
        temp.GetComponent<Image>().color = new Color(1f, 0.3632075f, 0.3632075f);


        temp = Instantiate(prefab, parent.transform);
        buttn = temp.GetComponent<Button>();
        buttn.onClick.AddListener(Close);
        temp.GetComponentInChildren<TMP_Text>().text = "닫기";

        Open();
    }

    public IEnumerator next()
    {
        yield return null;
        transform.localPosition = new Vector3(transform.localPosition.x, (transform.localPosition.y - (parent.GetComponent<RectTransform>().rect.height / 2)), 0);

    }

    public void Open()
    {


        gameObject.SetActive(true);
        StartCoroutine(next());

        //transform.localPosition = new Vector3(transform.localPosition.x, (transform.localPosition.y - (parent.GetComponent<RectTransform>().rect.height / 2)), 0);

    }

    public void Equip()
    {
        if (!GameManager.instance.inFight)
        {
            if (GameManager.instance.storage[slotNum] as Item != null)
            {
                Debug.Log("장착");
                if (InventoryUI.Instance.goons != null)
                {
                    if (InventoryUI.Instance.goons.EquipItem(GameManager.instance.storage[slotNum] as Item))
                    {
                        GameManager.instance.storage[slotNum] = null;
                    }
                }
                else
                {
                    AlertManager.instance.Append("사용할 대상이 없습니다.");
                }
            }
        }
        else
        {
            AlertManager.instance.Append("전투 중에는 할 수 없습니다.");
        }
        Close();
    }

    public void UseScroll()
    {
        (GameManager.instance.storage[slotNum] as Scroll).use(slotNum);
        Close();
    }
    public void UsePotion()
    {
        Debug.Log("사용");
        if (!GameManager.instance.inFight)
        {
            if (GameManager.instance.storage[slotNum] as Potion != null)
            {
                Debug.Log("포션");
                if (InventoryUI.Instance.goons != null)
                {
                    InventoryUI.Instance.goons.usePotion(GameManager.instance.storage[slotNum] as Potion);
                    GameManager.instance.storage[slotNum] = null;
                }
                else
                {
                    AlertManager.instance.Append("사용할 대상이 없습니다.");
                }
            }
        }
        else
        {
            AlertManager.instance.Append("전투 중에는 할 수 없습니다.");
        }
        Close();
    }
    public void Discard()
    {
        Debug.Log("버리기");
        GameManager.instance.storage[slotNum] = null;
        Close();
    }
    public void Close() {
        gameObject.SetActive(false);
    }

}
