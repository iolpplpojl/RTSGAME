using UnityEngine;
[CreateAssetMenu(fileName = "Event", menuName = "Room/Event")]

public class RoomType_Event : ScriptableObject, IRoomType
{

    public Incounter Event;
    public Incounter _event;
    public void Setup()
    {
        _event = Instantiate(Event);
        _event.Setup();
    }

    /** 이벤트 룸 처리 어떻게? 
     *  이벤트룸 -> 상점?
     *  이벤트룸 -> 인카운터?
     *  상점을 인카운터로 치고. "상점" 대화록 클릭 시 상인 START?
     *  인카운터도 전략패턴?
     *  하는게 좋지않을까?
     *  결국 이 클래스는 매개체...EVENT를 전략패턴..
     *  
     *  인카운터 셋업 -> 인카운터 액션 -> 인카운터 대화문 출력 -> ~~~ 결국 인카운터는 하드코딩?
     *  인카운터 대화문(싱글턴) 사용해서...  어처피 상점도 주인은 별개고 UI는 공용..
     *  클래스 Event 작성 -> 세분화된 클래스 ( 상인, 함정 등등. ) 작성.
     *  액션시  Event.Open(). 세분화된 클래스에서 1회용 설정.
     */
    public void Action()
    {
        _event.Open();
    }
}
