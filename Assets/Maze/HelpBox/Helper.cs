using TMPro;
using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] private GameObject _textBox;
    [SerializeField] private string _message;

    private GameObject _createdTextBox;

    private void OnMouseEnter()
    {
        _createdTextBox = Object.Instantiate(_textBox, transform.position, _textBox.transform.rotation);
        _createdTextBox.GetComponentInChildren<TextMeshPro>().text = _message;
        _createdTextBox.transform.GetChild(0).GetComponent<Renderer>().sortingLayerName = "TextBox";
    }

    private void OnMouseExit()
    {
        Destroy(_createdTextBox);
    }
}