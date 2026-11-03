using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [Header("Панели формул")]
    [SerializeField] private GameObject[] _panels;

    [Header("Менеджер вычислений")]
    [SerializeField] private Resolve _resolve;

    [Header("Поля ввода для формул")]
    [SerializeField] protected TextMeshProUGUI m1Txt;
    [SerializeField] protected TextMeshProUGUI m2Txt;
    [SerializeField] protected TextMeshProUGUI rTxt;
    [SerializeField] protected TextMeshProUGUI mTxt;
    [SerializeField] protected TextMeshProUGUI vTxt;
    [SerializeField] protected TextMeshProUGUI pTxt;
    [SerializeField] protected TextMeshProUGUI UTxt;

    private int _currentPanelIndex = -1;

    void Start()
    {
        CloseAllPanels();
    }

    public void OpenPanel(GameObject panelToOpen)
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(_panels[i] == panelToOpen);

            if (_panels[i] == panelToOpen)
            {
                _currentPanelIndex = i;
            }
        }
    }

    public void CloseAllPanels()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }

        _currentPanelIndex = -1;
    }

    public void Calculate()
    {
        if (_currentPanelIndex == -1)
        {
            Debug.LogWarning("Сначала откройте панель формулы!");
            return;
        }

        _resolve.OnButtonClick(_currentPanelIndex);
    }
}