using UnityEngine;

public class ButtonRemove : MonoBehaviour
{
    [SerializeField] private GameObject _flowChartContent;

    public void RemoveMoving()
    {
        // ѕеребираем все €чейки нашей блок схемы
        for (int i = 1; i < _flowChartContent.transform.childCount - 1; i++)
        {
            // ≈сли в €чейке есть команда, то удал€ем еЄ
            try
            {
                Destroy(_flowChartContent.transform.GetChild(i).GetChild(1).GetChild(0).gameObject);
            }
            catch { }
        }
    }
}
