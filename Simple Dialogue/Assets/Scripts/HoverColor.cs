using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text text;
    private Color initialColor;

    // Start is called before the first frame update
    void Start()
    {
        initialColor = text.color;
    }

    // When the mouse enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    // When the mouse exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = initialColor;
    }
}
