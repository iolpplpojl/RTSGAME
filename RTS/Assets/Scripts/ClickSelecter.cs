using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelecter : MonoBehaviour
{
    Vector3 start;
    Vector3 current;
    RectTransform rect;
    float clicktime = 0;

    void Start()
    {
        rect = transform.GetChild(0).GetComponent<RectTransform>();
        rect.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!InventoryUI.Instance.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 temp = Input.mousePosition;
                start = temp;
                clicktime = 0;
            }
            if (Input.GetMouseButton(0))
            {
                if (clicktime > 0.1f)
                {
                    rect.gameObject.SetActive(true);
                    float screenRatio = (float)Screen.width / 1920;
                    float screenRatioy = (float)Screen.height / 1080;
                    current = Input.mousePosition;

                    rect.sizeDelta = new Vector2(Mathf.Abs(current.x - start.x) / screenRatio, Mathf.Abs(current.y - start.y) / screenRatioy); // 박스 크기 설정
                                                                                                                                               // rect.localScale = (rightup - leftlow);
                    Vector3 temp = (start + current) / 2;
                    temp.x /= screenRatio;
                    temp.y /= screenRatioy;
                    rect.anchoredPosition = temp;
                }
                clicktime += Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (clicktime > 0.1f)
                {
                    DoSelect();
                    rect.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            rect.gameObject.SetActive(false);
        }
    }

    public void DoSelect()
    {
        Vector2 min = Camera.main.ScreenToWorldPoint(start);
        Vector2 max = Camera.main.ScreenToWorldPoint(current);
        var temp = Physics2D.OverlapAreaAll(min, max, LayerMask.GetMask("Player"));
        if (temp.Length != 0)
        {
            List<Goons> lol = new List<Goons>();
            foreach (var kek in temp)
            {
                Debug.Log(kek.transform.parent);
                lol.Add(kek.transform.parent.parent.GetComponent<Goons>());
            }
            temp[0].transform.parent.parent.parent.GetComponent<GoonsManager>().Select(lol);
        }

    }
}
