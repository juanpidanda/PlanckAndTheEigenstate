using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Saving", menuName = "ScriptableObjects/SavingSystem", order = 1)]
public class SavingSystem : ScriptableObject
{
    [SerializeField] bool shouldDeleteData = false;
    Dictionary<int, Dictionary<int, object>> data = new Dictionary<int, Dictionary<int, object>>();

    private void DeleteData() => data = new ();

    public void Save(int levelId, int id, object newData)
    {
        if (shouldDeleteData) DeleteData();

        if (!data.ContainsKey(levelId))
        {
            data.Add(levelId, new Dictionary<int, object>());

            if (!data[levelId].ContainsKey(id))
                data[levelId].Add(id, newData);
        }
        else 
            data[levelId][id] = newData;
    }

    public object Load(int levelId, int id)
    {
        if (shouldDeleteData) DeleteData();

        if (!data.ContainsKey(id)) return null;

        return data[levelId][id];
    }

    internal void Delete(int levelId, int id)
    {
        if (shouldDeleteData) DeleteData();

        data[levelId].Remove(id);
    }
}
