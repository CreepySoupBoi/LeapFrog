using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGUI : MonoBehaviour
{
    public Trigger trigger;
    // Start is called before the first frame update
    void OnGUI()
    {
        int posX = 10;
        int posY = 300;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Managers.Inventory.GetItemList();
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");
        }
        foreach (string item in itemList)
        {
            int count = Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>($"Icons/{item}");
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent($"( {count} )", image));
            posX += width + buffer;
        }

        string equipped = Managers.Inventory.equippedItem;
        if (equipped != null)
        {
            posX = Screen.width - (width + buffer * 2);
            Texture2D image = Resources.Load($"Icons/{equipped}") as Texture2D;
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("Equipped", image));
        }

        posX = 10;
        posY += height + buffer;

        foreach (string item in itemList)
        {
            if (GUI.Button(new Rect(posX, posY, width, height), $"Equip {item}"))
            {
                Managers.Inventory.EquipItem(item);
            }
            if (item == "sprite")
            {
                if (GUI.Button(new Rect(posX, posY + height + buffer, width, height), "Use Sprite"))
                {
                    Managers.Inventory.ConsumeItem("sprite");
                    trigger.score1 = trigger.score1 + 5;
                }
            }
            if (item == "potato")
            {
                if (GUI.Button(new Rect(posX, posY + height * 2 + buffer * 2, width, height), "Use Potato"))
                {
                    Managers.Inventory.ConsumeItem("potato");
                    trigger.score2 = trigger.score2 + 5;
                }
            }
            posX += width + buffer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
