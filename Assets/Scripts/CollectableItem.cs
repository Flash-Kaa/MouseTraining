using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public static int CountItemsCollect = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Игрок подбирает коллекционный предмет
            CountItemsCollect++;
            Destroy(this.gameObject);
        }
    }
}