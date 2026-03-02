using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkTypeButton : MonoBehaviour
{
    public WorkType workType;
    public ButtonCheckThreads1 checker;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        // Обновляем состояние кнопки
        UpdateButtonState();
    }

    void OnClick()
    {
        // Устанавливаем выбранную работу только если она ещё не выполнена
        if (!WorkProgress.CompletedWorks.Contains(workType))
        {
            WorkProgress.CurrentWorkType = workType;
            checker.UpdateWorkDescription(workType);
        }
    }

    // Метод для обновления состояния кнопки
    private void UpdateButtonState()
    {
        // Кнопка активна только если работа не выполнена
        button.interactable = !WorkProgress.CompletedWorks.Contains(workType);

        // Можно также визуально выделить текущую выбранную работу
        // Например, изменив цвет кнопки
        var colors = button.colors;
        colors.normalColor = (WorkProgress.CurrentWorkType == workType) ? Color.green : Color.white;
        button.colors = colors;
    }

    // Обновляем состояние кнопки при каждом включении объекта
    void OnEnable()
    {
        if (button != null)
        {
            UpdateButtonState();
        }
    }
}