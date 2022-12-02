using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ScorerUI : MonoBehaviour
{
    Innings innings;

    [SerializeField] TMP_Dropdown deliveryTypeDropdown;
    [SerializeField] TMP_Dropdown inputRunsDropdown;
    [SerializeField] Button addDeliveryButton;

    [SerializeField] DisplayScore displayScore;

    Delivery.DeliveryTypeEnum deliveryType;
    int runs;

    void Awake()
    {
        innings = new Innings();
        deliveryTypeDropdown.onValueChanged.AddListener(delegate { DeliveryTypeChanged(deliveryTypeDropdown); });
        inputRunsDropdown.onValueChanged.AddListener(delegate { RunsChanged(inputRunsDropdown); });
        addDeliveryButton.onClick.AddListener(delegate { AddNewDelivery(); });
    }

    public void DeliveryTypeChanged(TMP_Dropdown changed)
    {
        deliveryType = (Delivery.DeliveryTypeEnum)changed.value;
    }

    public void RunsChanged(TMP_Dropdown changed)
    {
        runs = (int)changed.value;
    }

    public void AddNewDelivery()
    {
        innings.AddDelivery(new Delivery(deliveryType, runs));
        if (displayScore != null)
        {
            displayScore.UpdateScore(innings);
        }
    }
}
