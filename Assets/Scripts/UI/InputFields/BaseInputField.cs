using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseInputField : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    protected bool isSelected = false;
    protected InputField mInputField;

    public virtual void Awake() {
        mInputField = GetComponent<InputField>();
    }

    public void OnSelect(BaseEventData eventData) {
        isSelected = true;
    }

    public void OnDeselect(BaseEventData eventData) {
        isSelected = false;
    }
}
