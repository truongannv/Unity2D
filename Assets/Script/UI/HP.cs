using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Image HP_UI;
    public void updateHP(float HP, float maxHP)
    {
        HP_UI.fillAmount = HP/maxHP;
    }
}
