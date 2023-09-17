using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    void SaveData();

    void LoadData();

    void UpdateData();

    void DeleteData();
}
