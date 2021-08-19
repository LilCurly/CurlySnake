using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class MyButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler, IDeselectHandler, ISubmitHandler, IPointerClickHandler
{

    RectTransform buttonText;

    virtual public void Awake() {
        TryGetTextComponentIfNeeded();
    }

    abstract public void PlayerDidSubmit();

    public void OnSubmit(BaseEventData eventData) {
        PlayerDidSubmit();
    }

    public void OnPointerClick(PointerEventData eventData) {
        PlayerDidSubmit();
    }

    public void OnSelect(BaseEventData eventData) {
        UiHandler.instance.selectedButton = gameObject;
        LeanTween.textColor(buttonText, Color.black, 0.2f).setIgnoreTimeScale(true);
    }

    public void OnDeselect(BaseEventData eventData) {
        LeanTween.textColor(buttonText, Color.white, 0.2f).setIgnoreTimeScale(true);
        if (UiHandler.instance.selectedButton.Equals(gameObject)) {
            UiHandler.instance.selectedButton = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (!gameObject.Equals(UiHandler.instance.selectedButton)) {
            LeanTween.textColor(buttonText, Color.black, 0.2f).setIgnoreTimeScale(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (!gameObject.Equals(UiHandler.instance.selectedButton)) {
            LeanTween.textColor(buttonText, Color.white, 0.2f).setIgnoreTimeScale(true);
        }
    }

    protected void TryGetTextComponentIfNeeded() {
        if (buttonText == null) {
            buttonText = GetComponentInChildren<Text>().rectTransform;
        }
    }
}
