//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class CalculationsManager : MonoBehaviour
//{
//    [Header("Поля ввода для формул")]
//    [SerializeField] private TextMeshProUGUI m1Txt;
//    [SerializeField] private TextMeshProUGUI m2Txt;
//    [SerializeField] private TextMeshProUGUI rTxt;
//    [SerializeField] private TextMeshProUGUI mTxt;
//    [SerializeField] private TextMeshProUGUI vTxt;
//    [SerializeField] private TextMeshProUGUI pTxt;
//    [SerializeField] private TextMeshProUGUI UTxt;

//    [Header("Ссылки на другие компоненты")]
//    [SerializeField] private Keypad keypad;
//    [SerializeField] private PanelManager panelManager;

//    private TextMeshProUGUI activeInput;

//    void Start()
//    {
//        if (keypad != null)
//        {
//            keypad.SetInteractable(false);
//        }
//        ClearAllFields();
//    }

//    public void SelectM1() => SetActiveField(m1Txt, "m1");
//    public void SelectM2() => SetActiveField(m2Txt, "m2");
//    public void SelectR() => SetActiveField(rTxt, "r");
//    public void SelectM() => SetActiveField(mTxt, "m");
//    public void SelectV() => SetActiveField(vTxt, "v");
//    public void SelectP() => SetActiveField(pTxt, "p");
//    public void SelectU() => SetActiveField(UTxt, "U");

//    private void SetActiveField(TextMeshProUGUI field, string fieldName)
//    {
//        if (field == null)
//        {
//            Debug.LogWarning($"[CalculationsManager] Поле '{fieldName}' не назначено в инспекторе!");
//            return;
//        }

//        activeInput = field;
//        HighlightActiveField();

//        if (keypad != null)
//        {
//            keypad.SetInteractable(true);
//        }

//        NotifyPanelManager();
//    }

//    private void HighlightActiveField()
//    {
//        if (m1Txt != null) m1Txt.color = new Color(1f, 1f, 1f, 0.4f);
//        if (m2Txt != null) m2Txt.color = new Color(1f, 1f, 1f, 0.4f);
//        if (rTxt != null) rTxt.color = new Color(1f, 1f, 1f, 0.4f);
//        if (mTxt != null) mTxt.color = new Color(1f, 1f, 1f, 0.4f);
//        if (vTxt != null) vTxt.color = new Color(1f, 1f, 1f, 0.4f);
//        if (pTxt != null) pTxt.color = new Color(1f, 1f, 1f, 0.4f);
//        if (UTxt != null) UTxt.color = new Color(1f, 1f, 1f, 0.4f);

//        if (activeInput != null)
//        {
//            activeInput.color = Color.white;
//        }
//    }

//    public void AppendDigit(string digit)
//    {
//        if (activeInput == null) return;
//        activeInput.text += digit;
//        NotifyPanelManager();
//    }

//    public void AppendDecimal()
//    {
//        if (activeInput == null) return;
//        if (!activeInput.text.Contains("."))
//        {
//            activeInput.text += ".";
//            NotifyPanelManager();
//        }
//    }

//    public void ClearActive()
//    {
//        if (activeInput == null) return;
//        activeInput.text = "";
//        NotifyPanelManager();
//    }

//    // УБРАНО: BackspaceActive() - метод удален по вашему требованию

//    public bool IsFieldEmpty(string fieldName)
//    {
//        TextMeshProUGUI field = GetFieldByName(fieldName);
//        return field == null || string.IsNullOrEmpty(field.text);
//    }

//    public float GetFloatValue(string fieldName)
//    {
//        TextMeshProUGUI field = GetFieldByName(fieldName);
//        if (field != null)
//        {
//            float.TryParse(field.text, out float value);
//            return value;
//        }
//        return 0f;
//    }

//    private TextMeshProUGUI GetFieldByName(string fieldName)
//    {
//        return fieldName switch
//        {
//            "m1" => m1Txt,
//            "m2" => m2Txt,
//            "r" => rTxt,
//            "m" => mTxt,
//            "v" => vTxt,
//            "p" => pTxt,
//            "U" => UTxt,
//            _ => null
//        };
//    }

//    private void ClearAllFields()
//    {
//        if (m1Txt != null) m1Txt.text = "";
//        if (m2Txt != null) m2Txt.text = "";
//        if (rTxt != null) rTxt.text = "";
//        if (mTxt != null) mTxt.text = "";
//        if (vTxt != null) vTxt.text = "";
//        if (pTxt != null) pTxt.text = "";
//        if (UTxt != null) UTxt.text = "";
//    }

//    private void NotifyPanelManager()
//    {
//        panelManager?.CheckValidation();
//    }
//}


//public float OnButtonClick(int id)
//{
//    float G = (constants != null) ? constants.gravitationalConstant : 6.674e-11f;
//    float c = (constants != null) ? constants.speedOfLight : 299792458f;
//    float h = (constants != null) ? constants.planckConstant : 6.626e-34f;
//    float e = (constants != null) ? constants.elementaryCharge : 1.602e-19f;

//    float.TryParse(m1Txt.text, out float val_m1);
//    float.TryParse(m2Txt.text, out float val_m2);
//    float.TryParse(rTxt.text, out float val_r);
//    float.TryParse(mTxt.text, out float val_m);
//    float.TryParse(vTxt.text, out float val_v);
//    float.TryParse(pTxt.text, out float val_p);
//    float.TryParse(UTxt.text, out float val_U);

//    if (val_r == 0f) val_r = 1f;
//    if (val_p == 0f) val_p = 1f;

//    switch (id)
//    {
//        case 0:
//            return G * (val_m1 * val_m2) / (val_r * val_r); 
//        case 1:
//            return val_m * c * c; 
//        case 2:
//            return h * val_v;
//        case 3:
//            return h / val_p;
//        case 4:
//            return e * val_U;
//        default:
//            return 0f;
//    }
//}