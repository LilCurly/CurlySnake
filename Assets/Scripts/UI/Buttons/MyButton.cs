using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class MyButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler, IDeselectHandler, ISubmitHandler
{

    RectTransform buttonText;

    void Awake() {
        TryGetTextComponentIfNeeded();
    }

    abstract public void OnSubmit(BaseEventData eventData);

    public void OnSelect(BaseEventData eventData) {
        GameOverHandler.instance.selectedButton = gameObject;
        LeanTween.textColor(buttonText, Color.black, 0.2f).setIgnoreTimeScale(true);
    }

    public void OnDeselect(BaseEventData eventData) {
        LeanTween.textColor(buttonText, Color.white, 0.2f).setIgnoreTimeScale(true);
        if (GameOverHandler.instance.selectedButton.Equals(gameObject)) {
            GameOverHandler.instance.selectedButton = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (!gameObject.Equals(GameOverHandler.instance.selectedButton)) {
            LeanTween.textColor(buttonText, Color.black, 0.2f).setIgnoreTimeScale(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (!gameObject.Equals(GameOverHandler.instance.selectedButton)) {
            LeanTween.textColor(buttonText, Color.white, 0.2f).setIgnoreTimeScale(true);
        }
    }

    protected void TryGetTextComponentIfNeeded() {
        if (buttonText == null) {
            buttonText = GetComponentInChildren<Text>().rectTransform;
        }
    }
}
