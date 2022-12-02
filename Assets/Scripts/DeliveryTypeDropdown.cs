using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DeliveryTypeDropdown : MonoBehaviour
{
    TMP_Dropdown dropdown;
    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        if (dropdown != null)
        {
            var types = Enum.GetNames(typeof(Delivery.DeliveryTypeEnum));
            foreach (var type in types)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(type));
            }
        }
    }
}
