using UnityEngine;
[CreateAssetMenu(fileName = "Event", menuName = "Room/Event")]

public class RoomType_Event : ScriptableObject, IRoomType
{
    public Incounter Event;
    public void Setup()
    {

    }

    /** �̺�Ʈ �� ó�� ���? 
     *  �̺�Ʈ�� -> ����?
     *  �̺�Ʈ�� -> ��ī����?
     *  ������ ��ī���ͷ� ġ��. "����" ��ȭ�� Ŭ�� �� ���� START?
     *  ��ī���͵� ��������?
     *  �ϴ°� ����������?
     *  �ᱹ �� Ŭ������ �Ű�ü...EVENT�� ��������..
     *  
     *  ��ī���� �¾� -> ��ī���� �׼� -> ��ī���� ��ȭ�� ��� -> ~~~ �ᱹ ��ī���ʹ� �ϵ��ڵ�?
     *  ��ī���� ��ȭ��(�̱���) ����ؼ�...  ��ó�� ������ ������ ������ UI�� ����..
     *  Ŭ���� Event �ۼ� -> ����ȭ�� Ŭ���� ( ����, ���� ���. ) �ۼ�.
     *  �׼ǽ�  Event.Open(). ����ȭ�� Ŭ�������� 1ȸ�� ����.
     */
    public void Action()
    {
        Event.Open();
    }
}
