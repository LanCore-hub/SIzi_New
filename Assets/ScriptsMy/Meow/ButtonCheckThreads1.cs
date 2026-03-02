using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

[System.Serializable]
public class ItemGroup1
{
    public string[] requiredTags;
}

public static class WorkProgress
{
    public static HashSet<WorkType> CompletedWorks = new HashSet<WorkType>();
    public static WorkType CurrentWorkType;

    public static bool IsAllWorksCompleted => CompletedWorks.Count == 7;

    public static void ResetProgress()
    {
        CompletedWorks.Clear();
        CurrentWorkType = WorkType.WorkType1;
    }
}

public class ButtonCheckThreads1 : MonoBehaviour
{
    public HoverButton hoverButton;
    [SerializeField] private AudioSource StartSound;
    [SerializeField] private AudioSource WrongSound;
    [SerializeField] private AudioSource CorrectSound;
    [SerializeField] private AudioSource ZachetSound;

    [SerializeField] private GameObject picture;

    [SerializeField] private Texture2D spetsObuvTexture;
    [SerializeField] private Texture2D kaskaTexture;
    [SerializeField] private Texture2D respiratorTexture;
    [SerializeField] private Texture2D trapglovesTexture;
    [SerializeField] private Texture2D glovesHardRedTexture;
    [SerializeField] private Texture2D glovesHardTexture;
    [SerializeField] private Texture2D EasyKostumTexture;
    [SerializeField] private Texture2D HardKostumTexture;
    [SerializeField] private Texture2D glassesTexture;
    [SerializeField] private Texture2D kaskaglassnaushTexture;
    [SerializeField] private Texture2D naushniki2MTexture;
    [SerializeField] private Texture2D naushniki3MTexture;
    [SerializeField] private Texture2D kaskaglassTexture;
    [SerializeField] private Texture2D GlovesRezinTexture;

    [System.Serializable]
    public class WorkRequirements
    {
        public WorkType workType;
        public ItemGroup1[] requiredItemGroups;
    }

    public WorkRequirements[] workRequirements;
    public GameObject table;
    public TextMeshPro TextObject;
    [SerializeField] private string nameScene;

    private Dictionary<WorkType, WorkRequirements> workRequirementsDict;

    void Start()
    {
        StartSound.Play();
        hoverButton.onButtonDown.AddListener(OnButtonDown);

        // Инициализация словаря требований
        workRequirementsDict = new Dictionary<WorkType, WorkRequirements>();
        foreach (var req in workRequirements)
        {
            workRequirementsDict[req.workType] = req;
        }

        // Установка текущей работы
        if (WorkProgress.CurrentWorkType == default)
        {
            SetRandomUncompletedWorkType();
        }
        else
        {
            UpdateWorkDescription(WorkProgress.CurrentWorkType);
        }
    }

    private void SetRandomUncompletedWorkType()
    {
        List<WorkType> availableWorks = new List<WorkType>();
        foreach (WorkType type in System.Enum.GetValues(typeof(WorkType)))
        {
            if (!WorkProgress.CompletedWorks.Contains(type))
            {
                availableWorks.Add(type);
            }
        }

        if (availableWorks.Count == 0)
        {
            AllWorksCompleted();
            return;
        }

        WorkProgress.CurrentWorkType = availableWorks[Random.Range(0, availableWorks.Count)];
        UpdateWorkDescription(WorkProgress.CurrentWorkType);
    }

    public void UpdateWorkDescription(WorkType workType)
    {
        switch (workType)
        {
            case WorkType.WorkType1:
                TextObject.SetText("Подготовка шихтовых материалов. Пиление материалов");
                break;
            case WorkType.WorkType2:
                TextObject.SetText("Работа с малым объёмом расплава");
                break;
            case WorkType.WorkType3:
                TextObject.SetText("Работа с большим объёмом расплава");
                break;
            case WorkType.WorkType4:
                TextObject.SetText("Работа с малым объёмом расплава при обработке флюсом");
                break;
            case WorkType.WorkType5:
                TextObject.SetText("Отбор проб расплава из печи выдержки");
                break;
            case WorkType.WorkType6:
                TextObject.SetText("Пескоструйная обработка кокиля");
                break;
            case WorkType.WorkType7:
                TextObject.SetText("Подготовка навесок порошковых реагентов");
                break;
        }
    }

    private void OnButtonDown(Hand hand)
    {
        if (!workRequirementsDict.TryGetValue(WorkProgress.CurrentWorkType, out var currentRequirements))
        {
            Debug.LogError($"Требования для работы {WorkProgress.CurrentWorkType} не найдены");
            return;
        }

        var itemsTagsOnTable = table.GetComponent<CheckObjectsOnTable>().objectTagsOnTable;
        var itemsNamesOnTable = table.GetComponent<CheckObjectsOnTable>().objectNamesOnTable;
        var allObjects = table.GetComponent<CheckObjectsOnTable>().allObjectsOnTable;

        Vector3 position = new Vector3(8.28100014f, 5.28000021f, 3.98000002f);

        // Собираем все необходимые теги для быстрой проверки
        HashSet<string> requiredTags = new HashSet<string>();
        foreach (ItemGroup1 group in currentRequirements.requiredItemGroups)
        {
            foreach (string tag in group.requiredTags)
            {
                requiredTags.Add(tag);
            }
        }

        // Проверяем каждый предмет на столе
        foreach (GameObject item in allObjects)
        {
            string itemTag = item.tag;
            string itemName = item.name;

            // Создаем экземпляр картинки для каждого предмета
            GameObject pictureInstance = Instantiate(picture, position, Quaternion.identity);
            Renderer pictureRenderer = pictureInstance.transform.Find("picture").GetComponent<Renderer>();
            Renderer borderRenderer = pictureInstance.transform.Find("boarder").GetComponent<Renderer>();

            Material tempMaterial = new Material(pictureRenderer.material);

            // Устанавливаем текстуру в зависимости от имени предмета
            if (itemName == "spetsobuv")
            {
                tempMaterial.mainTexture = spetsObuvTexture;
            }
            else if (itemName == "kaska")
            {
                tempMaterial.mainTexture = kaskaTexture;
            }
            else if (itemName == "respirator")
            {
                tempMaterial.mainTexture = respiratorTexture;
            }
            else if (itemName == "trapgloves")
            {
                tempMaterial.mainTexture = trapglovesTexture;
            }
            else if (itemName == "glovesHardRed")
            {
                tempMaterial.mainTexture = glovesHardRedTexture;
            }
            else if (itemName == "glovesHard")
            {
                tempMaterial.mainTexture = glovesHardTexture;
            }
            else if (itemName == "EasyKostum")
            {
                tempMaterial.mainTexture = EasyKostumTexture;
            }
            else if (itemName == "HardKostum")
            {
                tempMaterial.mainTexture = HardKostumTexture;
            }
            else if (itemName == "glasses")
            {
                tempMaterial.mainTexture = glassesTexture;
            }
            else if (itemName == "kaskaglassnaush")
            {
                tempMaterial.mainTexture = kaskaglassnaushTexture;
            }
            else if (itemName == "naushniki2M")
            {
                tempMaterial.mainTexture = naushniki2MTexture;
            }
            else if (itemName == "naushniki3M")
            {
                tempMaterial.mainTexture = naushniki3MTexture;
            }
            else if (itemName == "kaskaglass")
            {
                tempMaterial.mainTexture = kaskaglassTexture;
            }
            else if (itemName == "GlovesRezin")
            {
                tempMaterial.mainTexture = GlovesRezinTexture;
            }

            pictureRenderer.material = tempMaterial;

            // Проверяем, подходит ли предмет для текущего задания
            if (requiredTags.Contains(itemTag))
            {
                borderRenderer.material.color = Color.green; // Подходящий предмет
                Debug.Log($"Предмет {itemName} с тегом {itemTag} подходит для задания");
            }
            else
            {
                borderRenderer.material.color = Color.red; // Неподходящий предмет
                Debug.Log($"Предмет {itemName} с тегом {itemTag} НЕ подходит для задания");
            }

            position = position - new Vector3(0, 0, 1.1f);
        }

        bool isWorkCorrect = CheckWorkCorrect(currentRequirements, itemsTagsOnTable);

        if (isWorkCorrect)
        {
            HandleCorrectWork();
        }
        else
        {
            HandleIncorrectWork();
        }
    }

    private bool CheckWorkCorrect(WorkRequirements requirements, List<string> itemsOnTable)
    {
        foreach (ItemGroup1 group in requirements.requiredItemGroups)
        {
            bool tagFound = false;
            foreach (string tag in group.requiredTags)
            {
                if (itemsOnTable.Contains(tag))
                {
                    tagFound = true;
                    break;
                }
            }

            if (!tagFound) return false;
        }
        return true;
    }

    private void HandleCorrectWork()
    {
        WorkProgress.CompletedWorks.Add(WorkProgress.CurrentWorkType);

        if (WorkProgress.IsAllWorksCompleted)
        {
            AllWorksCompleted();
        }
        else
        {
            CorrectSound.Play();
            SetRandomUncompletedWorkType();
            Invoke("ReloadScene", 4f);
        }
    }

    private void HandleIncorrectWork()
    {
        WrongSound.Play();
        SetRandomUncompletedWorkType();
        Invoke("ReloadScene", 4f);
    }

    private void AllWorksCompleted()
    {
        ZachetSound.Play();
        StartCoroutine(QuitAfterDelay(4f));
    }

    private void ReloadScene()
    {
        LoadScene(nameScene);
    }

    IEnumerator QuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }

    private void LoadScene(string nameScene)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null) Destroy(Player);

        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.transform.parent == null && obj.scene.isLoaded)
            {
                Destroy(obj);
            }
        }
        SceneManager.LoadScene(nameScene);
    }
}