using UnityEngine;

public abstract class Incounter : ScriptableObject
{
    /// <summary>
    /// �⺻ ���� : Open(), Close().
    /// Close�� ��湮 �Ұ��� ����ȭ ó��.
    /// Open()�� UI ȣ��.. UI�� ��ư��. ����ȭ �ڵ忡�� ��ư �߰��ϴ� �ڵ� �ۼ�.
    /// "�ȳ��ϼ�" ��ư Ŭ�� -> ��ȭ��1() �ϰ� ���� ��ȭ ��ư�� "������" -> ��ȭ��2() "�߰���" -> ��ȭ��3() ��ư ����Ʈ�� ���,
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
