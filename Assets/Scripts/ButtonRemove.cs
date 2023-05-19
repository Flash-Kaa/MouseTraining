using UnityEngine;

public class ButtonRemove : MonoBehaviour
{
    [SerializeField] private GameObject _flowChartContent;

    public void RemoveMoving()
    {
        for (int i = 1; i < _flowChartContent.transform.childCount - 1; i++)
        {
            try
            {
                Destroy(_flowChartContent.transform.GetChild(i).GetChild(1).GetChild(0).gameObject);
            }
            catch { }
        }
    }
}
