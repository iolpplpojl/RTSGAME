using UnityEngine;
[CreateAssetMenu(fileName = "BaseScroll", menuName = "Scrolls/BaseScroll")]

public class Scroll : ScriptableObject, Iitem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field: SerializeField] public Sprite sprite { get; set; }
    [field: SerializeField] public string itemname { get; set; }
    public string description;
    //public GameObject magic;

    public string getDesc()
    {
        return description;
    }

    public void use()
    { 
        //Instantiate(magic);
    }


}


/** 
 * 인터페이스 매직타겟팅, 인터페이스 매직논타겟팅 
 * 매직
 *  
 *  업데이트{
 *  포지션 : 마우스
 *  만약(왼클릭){
            시행.
    }
    만약(오른클릭){
            취소.(자살)
    }
 *  }
 *  
 *  예시 : 체인힐 : 매직, 매직아군타겟팅 {
 *  
 *  }
 *  
 *  예시 : 파이어볼 : 매직, 매직논타겟팅
 *  오브젝트 : 불
 *  
 *  시행(){
 *      생성(불,마우스포지션);
 *  }
 * 
 */