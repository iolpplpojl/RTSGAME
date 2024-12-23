using UnityEngine;
using UnityEngine.UI;
public class FlexLayoutGroup : LayoutGroup
{

    public int row;
    public int col;
    public Vector2 cell;

    public enum fit
    {
        ����,
        ����,
        �׸���,
        ������,
        ������
    }
    public fit type;

    public bool ����X;
    public bool ����Y;
    public Vector2 spacing;
    // ���̾ƿ��� ���� ���� ���
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        // �ʿ信 ���� ���̾ƿ� ��� �߰�
        if (type == fit.���� || type == fit.���� || type == fit.�׸���)
        {
            float sqrRt = Mathf.Sqrt(transform.childCount);
            row = Mathf.CeilToInt(sqrRt);
            col = Mathf.CeilToInt(sqrRt);
        }

        if (type == fit.������)
        {
            row = Mathf.CeilToInt(transform.childCount / (float)col);
        }
        if (type == fit.������)
        {
            col = Mathf.CeilToInt(transform.childCount / (float)row);
        }
        float parentWidth = rectTransform.rect.width;

        float parentHeight = rectTransform.rect.height;
        float cellwid = (parentWidth / col) - ((spacing.x / (float)col * (col-1) ) - (padding.left / (float)col) - (padding.right/(float)col));
        float cellhei = (parentHeight / row) - ((spacing.y / (float)row * (row-1)) - (padding.top / (float)row) - (padding.bottom / (float)row));
        cell.x = ����X ? cellwid : cell.x;
        cell.y = ����Y ? cellhei : cell.y;
        int colCount = 0;
        int rowCount = 0;
        for(int i = 0; i<rectChildren.Count; i++){
            rowCount = i / col;
            colCount = i % col;
            var item = rectChildren[i];
            var x = (cell.x * colCount) + (spacing.x * colCount) + padding.left;
            var y = (cell.y * rowCount) + (spacing.x * rowCount) + padding.top;
            SetChildAlongAxis(item, 0, x, cell.x);
            SetChildAlongAxis(item, 1, y, cell.y);
        }
    }

    // ���̾ƿ��� ���� ���� ���
    public override void CalculateLayoutInputVertical()
    {
        // �ʿ信 ���� ���̾ƿ� ��� �߰�
    }

    // ���� �������� ���̾ƿ��� ��ġ
    public override void SetLayoutHorizontal()
    {
        // �ڽ� ��Ҹ� �������� ��ġ�ϴ� ���� �߰�
    }

    // ���� �������� ���̾ƿ��� ��ġ
    public override void SetLayoutVertical()
    {
        // �ڽ� ��Ҹ� �������� ��ġ�ϴ� ���� �߰�
    }
}
