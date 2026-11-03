using TMPro;
using UnityEngine;

public class Resolve : PanelManager
{
    [Header("Поле для вывода результата")]
    [SerializeField] private TextMeshProUGUI _testTxt;

    [Header("Физические константы")]
    private PhysicsConstants constants;

    public void OnButtonClick(int id)
    {
        float G = constants != null ? constants.gravitationalConstant : 6.674e-11f;
        float c = constants != null ? constants.speedOfLight : 299792458f;
        float h = constants != null ? constants.planckConstant : 6.626e-34f;
        float e = constants != null ? constants.elementaryCharge : 1.602e-19f;

        float.TryParse(m1Txt.text, out float val_m1);
        float.TryParse(m2Txt.text, out float val_m2);
        float.TryParse(rTxt.text, out float val_r);
        float.TryParse(mTxt.text, out float val_m);
        float.TryParse(vTxt.text, out float val_v);
        float.TryParse(pTxt.text, out float val_p);
        float.TryParse(UTxt.text, out float val_U);

        if (val_r == 0f) val_r = 1f;
        if (val_p == 0f) val_p = 1f;

        float result = 0f;

        switch (id)
        {
            case 0:
                result = G * (val_m1 * val_m2) / (val_r * val_r);
                break;

            case 1:
                result = val_m * c * c;
                break;

            case 2:
                result = h * val_v;
                break;

            case 3:
                result = h / val_p;
                break;

            case 4:
                result = e * val_U;
                break;

            default:
                Debug.LogWarning("Неизвестный индекс формулы: " + id);
                return;
        }

        if (_testTxt != null)
        {
            _testTxt.text = result.ToString();
        }
    }
}