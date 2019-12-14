using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class ButtonSelection<T> : MonoBehaviour
{
    public T defaultSelection;
    public Vector2 buttonDimensions;
    public Vector2 buttonStartPosition;
    public Sprite buttonImage;
    public float spaceBetween;
    public List<T> selections;

    protected T selectedItem;

    public T SelectedItem
    {
        get { return selectedItem; }
    }

    protected virtual void Awake()
    {
        var x = buttonStartPosition.x;
        var y = buttonStartPosition.y;

        foreach(var item in selections)
        {
            var button = CreateButton(item);
            button.transform.position = new Vector3(x, y, transform.position.z);
            button.transform.SetParent(this.transform, false);

            button.GetComponent<Button>().onClick.AddListener(() => SelectItem(item));

            y -= spaceBetween;
        }

        SelectItem(defaultSelection);
    }

    protected virtual GameObject CreateButton(T item)
    {
        var obj = new GameObject();
        obj.layer = 5;

        var image = obj.AddComponent<Image>();
        image.sprite = buttonImage;
        image.type = Image.Type.Sliced;

        obj.AddComponent<Button>();

        var textGameObject = new GameObject();
        textGameObject.layer = 5;
        var textUI = textGameObject.AddComponent<Text>();
        textUI.color = Color.black;
        textUI.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        textUI.alignment = TextAnchor.MiddleCenter;
        textGameObject.GetComponent<RectTransform>().sizeDelta = buttonDimensions;

        textGameObject.transform.SetParent(obj.transform, false);
        obj.GetComponent<RectTransform>().sizeDelta = buttonDimensions;

        return obj;
    }

    public virtual void SelectItem(T item)
    {
        selectedItem = item;
    }
}
