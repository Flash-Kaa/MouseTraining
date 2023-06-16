using UnityEngine;

public class ButtonAdd : MonoBehaviour
{
    [SerializeField] private GameObject _flowChartContent;
    [SerializeField] private GameObject _cell;

    public void AddCell()
    {
        // Получаем копию блока "конец" из блок-схемы
        var end = _flowChartContent.transform.GetChild(_flowChartContent.transform.childCount - 1).gameObject;
        
        // Добавляем новую ячейку и копию блока "конец"
        Instantiate(_cell, _flowChartContent.transform);
        Instantiate(end, _flowChartContent.transform);

        // Удаляем предыдущий блок "конец"
        Destroy(end);
    }
}
