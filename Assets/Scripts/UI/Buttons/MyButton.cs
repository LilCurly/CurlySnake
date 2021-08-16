using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class MyButton<T> : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler, IDeselectHandler, ISubmitHandler where T : BaseUiHandler
{

    RectTransform buttonText;

    T uiHandler;

    virtual public void Awake() {
        TryGetTextComponentIfNeeded();
    }

    abstract public void OnSubmit(BaseEventData eventData);

    public void SetUiHandler(T uiHandler) {
        this.uiHandler = uiHandler;
    }

    public void OnSelect(BaseEventData eventData) {
        uiHandler.selectedButton = gameObject;
        LeanTween.textColor(buttonText, Color.black, 0.2f).setIgnoreTimeScale(true);
    }

    public void OnDeselect(BaseEventData eventData) {
        LeanTween.textColor(buttonText, Color.white, 0.2f).setIgnoreTimeScale(true);
        if (uiHandler.selectedButton.Equals(gameObject)) {
            uiHandler.selectedButton = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (!gameObject.Equals(uiHandler.selectedButton)) {
            LeanTween.textColor(buttonText, Color.black, 0.2f).setIgnoreTimeScale(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (!gameObject.Equals(uiHandler.selectedButton)) {
            LeanTween.textColor(buttonText, Color.white, 0.2f).setIgnoreTimeScale(true);
        }
    }

    protected void TryGetTextComponentIfNeeded() {
        if (buttonText == null) {
            buttonText = GetComponentInChildren<Text>().rectTransform;
        }
    }
}
