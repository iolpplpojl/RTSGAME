using UnityEngine;

public abstract class Incounter : ScriptableObject
{
    /// <summary>
    /// 기본 구조 : Open(), Close().
    /// Close시 재방문 불가는 세분화 처리.
    /// Open()시 UI 호출.. UI에 버튼란. 세분화 코드에서 버튼 추가하는 코드 작성.
    /// "안녕하쇼" 버튼 클릭 -> 대화문1() 하고 다음 대화 버튼인 "꺼지쇼" -> 대화문2() "잘가쇼" -> 대화문3() 버튼 리스트에 등록,
    /// </summary>
    /// 


    public virtual void Open()
    {
        IncounterUI.instance.OpenIncounter();
    }
    public virtual void Setup()
    {
        //
    }
    public virtual void Close()
    {
        IncounterUI.instance.CloseIncounter();

    }
}
