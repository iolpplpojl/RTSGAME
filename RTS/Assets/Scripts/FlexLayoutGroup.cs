using UnityEngine;
using UnityEngine.UI;
public class FlexLayoutGroup : LayoutGroup
{

    public int row;
    public int col;
    public Vector2 cell;

    public enum fit
    {
        세로,
        가로,
        그리드,
        고정열,
        고정행
    }
    public fit type;

    public bool 고정X;
    public bool 고정Y;
    public Vector2 spacing;
    // 레이아웃의 수평 방향 계산
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        // 필요에 따라 레이아웃 계산 추가
        if (type == fit.세로 || type == fit.가로 || type == fit.그리드)
        {
            float sqrRt = Mathf.Sqrt(transform.childCount);
            row = Mathf.CeilToInt(sqrRt);
            col = Mathf.CeilToInt(sqrRt);
        }

        if (type == fit.고정행)
        {
            row = Mathf.CeilToInt(transform.childCount / (float)col);
        }
        if (type == fit.고정열)
        {
            col = Mathf.CeilToInt(transform.childCount / (float)row);
        }
        float parentWidth = rectTransform.rect.width;

        float parentHeight = rectTransform.rect.height;
        float cellwid = (parentWidth / col) - ((spacing.x / (float)col * (col-1) ) - (padding.left / (float)col) - (padding.right/(float)col));
        float cellhei = (parentHeight / row) - ((spacing.y / (float)row * (row-1)) - (padding.top / (float)row) - (padding.bottom / (float)row));
        cell.x = 고정X ? cellwid : cell.x;
        cell.y = 고정Y ? cellhei : cell.y;
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

    // 레이아웃의 수직 방향 계산
    public override void CalculateLayoutInputVertical()
    {
        // 필요에 따라 레이아웃 계산 추가
    }

    // 수평 방향으로 레이아웃을 배치
    public override void SetLayoutHorizontal()
    {
        // 자식 요소를 수평으로 배치하는 로직 추가
    }

    // 수직 방향으로 레이아웃을 배치
    public override void SetLayoutVertical()
    {
        // 자식 요소를 수직으로 배치하는 로직 추가
    }
}
