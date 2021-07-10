using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;

    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content = "", string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        } else
        {
            headerField.text = header;
            headerField.gameObject.SetActive(true);
        }

        if (string.IsNullOrEmpty(content))
        {
            contentField.gameObject.SetActive(false);
        }
        else
        {
            contentField.text = content;
            contentField.gameObject.SetActive(true);
        }
        
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = Mathf.Max(headerField.preferredWidth, contentField.preferredWidth) >= layoutElement.preferredWidth;
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = Mathf.Max(headerField.preferredWidth, contentField.preferredWidth) >= layoutElement.preferredWidth;
        }

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);

        transform.position = position;
    }
}
