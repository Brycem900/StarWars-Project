using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : ButtonSelection<GameObject>
{
    public Vector3 defaultCharacterPosition;

    override protected void Awake()
    {
        base.Awake();
        SelectedItem.transform.position = defaultCharacterPosition;
    }

    override protected GameObject CreateButton(GameObject character)
    {
        var obj = base.CreateButton(character);
        obj.transform.GetChild(0).GetComponent<Text>().text = character.tag;
        return obj;
    }

    override public void SelectItem(GameObject player)
    {
        Vector3 previousPosition = new Vector3(0, 0, 0);
        if(selectedItem != null)
        {
            previousPosition = selectedItem.transform.position;
            Destroy(selectedItem);
        }

        selectedItem = Instantiate<GameObject>(player);
        selectedItem.transform.position = previousPosition;
    }
}
