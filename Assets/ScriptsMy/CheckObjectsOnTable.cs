using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectsOnTable : MonoBehaviour
{
    public List<string> objectTagsOnTable = new List<string>();
    public List<string> objectNamesOnTable = new List<string>();
    public List<GameObject> allObjectsOnTable = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && !string.IsNullOrEmpty(other.tag))
        {
            if (!objectTagsOnTable.Contains(other.tag) && other.tag != "Untagged")
            {
                objectTagsOnTable.Add(other.tag);
                Debug.Log($"Object with tag '{other.tag}' placed on table");
            }

            if (!objectNamesOnTable.Contains(other.name) && other.tag != "Untagged")
            {
                objectNamesOnTable.Add(other.name);
                Debug.Log($"Object with name '{other.name}' placed on table");
            }

            if (other.tag != "Untagged")
            {
                allObjectsOnTable.Add(other.gameObject);
                Debug.Log($"Name this object successfully added in the list of all objects.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && !string.IsNullOrEmpty(other.tag))
        {
            if (objectTagsOnTable.Contains(other.tag))
            {
                objectTagsOnTable.Remove(other.tag);
                Debug.Log($"Object with tag '{other.tag}' removed from table");
            }

            if (!objectNamesOnTable.Contains(other.name))
            {
                objectNamesOnTable.Remove(other.name);
                Debug.Log($"Object with name '{other.name}' removed from table");
            }

            if (other.tag != "Untagged")
            {
                allObjectsOnTable.Remove(other.gameObject);
                Debug.Log($"Name this object successfully removed from the list of all objects.");
            }
        }
    }

    public bool HasTagOnTable(string tag)
    {
        return objectTagsOnTable.Contains(tag);
    }

    public List<string> GetAllTagsOnTable()
    {
        return new List<string>(objectTagsOnTable);
    }

    public bool HasAnyObjects()
    {
        return objectTagsOnTable.Count > 0;
    }

    public int GetUniqueTagsCount()
    {
        return objectTagsOnTable.Count;
    }

    public void ClearTableTags()
    {
        objectTagsOnTable.Clear();
        Debug.Log("Table tags cleared");
    }
}