using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using static UnityEngine.Rendering.DebugUI;

[System.Serializable]
public class ItemGroup
{
    public string[] requiredTags; // Теги, из которых нужен хотя бы один
}

public class ButtonCheckThreads : MonoBehaviour
{
    public HoverButton hoverButton; // Кнопка, которая запускает проверку
    public ItemGroup[] requiredItemGroups; // Группы тегов для проверки
    public GameObject table;

    public List<string> itemsOnTable = new List<string>();

    void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    // Проверка при нажатии кнопки
    private void OnButtonDown(Hand hand)
    {
        itemsOnTable = table.GetComponent<CheckObjectsOnTable>().objectTagsOnTable;

        Debug.Log("=== Проверка предметов ===");
        bool allGroupsValid = true;

        foreach (ItemGroup group in requiredItemGroups)
        {
            bool tagFound = false;

            // Проверяем, есть ли на столе хотя бы 1 предмет с нужным тегом из группы
            foreach (string tag in group.requiredTags)
            {
                foreach (string item in itemsOnTable)
                {
                    if (item == tag)
                    {
                        tagFound = true;
                        Debug.Log($"Найден предмет с тегом [{tag}]: {item}");
                        break;
                    }
                }
                if (tagFound) break;
            }

            if (!tagFound)
            {
                allGroupsValid = false;
                Debug.Log($"Не найден предмет с тегом: {string.Join(" или ", group.requiredTags)}");
                return;
            }
        }

        if (allGroupsValid)
        {
            Debug.Log("Все условия выполнены!");
            return;
        }
        else
        {
            Debug.Log("Чего-то не хватает!");
            return;
        }
    }
}