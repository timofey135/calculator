using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : PanelManager
{
    [Header("Ссылка на менеджер")]
    

    [Header("Кнопки цифр")]
    [SerializeField] private Button[] numberButtons;

    [Header("Текстовые поля")]
    [SerializeField] private TextMeshProUGUI[] _testTxt;

    private string[] storedValues;

    private string currentInput = "";
    private int _currentIndex = 0;

    void Start()
    {

        for (int i = 0; i < numberButtons.Length; i++)
        {
            int index = i;
            numberButtons[i].onClick.AddListener(() => OnButtonClick(index));
        }


        if (_testTxt != null)
        {
            storedValues = new string[_testTxt.Length];
            for (int i = 0; i < storedValues.Length; i++)
            {
                storedValues[i] = "0"; 
            }
        }
    }
    private void Update()
    {
        currentInput = storedValues[_currentIndex];
        UpdateDisplay();
    }
    void OnButtonClick(int id)
    {
        switch (id)
        {
            case 0: AppendDigit("0"); break;
            case 1: AppendDigit("1"); break;
            case 2: AppendDigit("2"); break;
            case 3: AppendDigit("3"); break;
            case 4: AppendDigit("4"); break;
            case 5: AppendDigit("5"); break;
            case 6: AppendDigit("6"); break;
            case 7: AppendDigit("7"); break;
            case 8: AppendDigit("8"); break;
            case 9: AppendDigit("9"); break;
            case 10: AppendDigit("."); break;
        }
    }

    public void AppendDigit(string digit)
    {

        if (_testTxt == null || _currentIndex < 0 || _currentIndex >= _testTxt.Length) return;

        
        if (storedValues[_currentIndex] == "0" && digit != ".")
        {
            storedValues[_currentIndex] = digit;
        }
        else
        {
            storedValues[_currentIndex] += digit;
        }

    }

    private void UpdateDisplay()
    {
        if (_testTxt != null && _currentIndex < _testTxt.Length && _testTxt[_currentIndex] != null)
        {
            _testTxt[_currentIndex].text = storedValues[_currentIndex];
        }
    }

    public void ClearInput()
    {
        if (_testTxt == null || _currentIndex < 0 || _currentIndex >= _testTxt.Length) return;

        
        storedValues[_currentIndex] = "0";
        currentInput = "0";
        UpdateDisplay();
    }

    public void EditingValue(TextMeshProUGUI text)
    {
        if (_testTxt == null) return;

        for (int i = 0; i < _testTxt.Length; i++)
        {
            if (_testTxt[i] != null)
            {
                bool isActive = (_testTxt[i] == text);
                _testTxt[i].enabled = isActive;

                if (isActive)
                {
                    
                    _currentIndex = i;

                    currentInput = storedValues[_currentIndex];

                    _testTxt[i].text = currentInput;
                }
            }
        }
    }
}