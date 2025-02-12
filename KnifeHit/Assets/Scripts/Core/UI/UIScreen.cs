﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour {
	[SerializeField] protected CanvasGroup canvasGroup;

	void Awake() {
		Hide(true);
	}

	public void Show(bool isForce, Action setOnComplete = null) {
		if (!gameObject.activeSelf)
			gameObject.SetActive(true);
		LeanTween.cancel(gameObject, false);

		if (!isForce) {
			LeanTween.value(gameObject, canvasGroup.alpha, 1, UIConsts.menuAnimationsTime)
			.setOnUpdate((a) => {
				canvasGroup.alpha = a;
			})
			.setOnComplete(() => {
				canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
				setOnComplete?.Invoke();
			});
		}
		else {
			canvasGroup.alpha = 1.0f;
			canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
			setOnComplete?.Invoke();
		}
	}

	public void Hide(bool isForce, Action setOnComplete = null) {
		LeanTween.cancel(gameObject, false);

		if (!isForce) {
			LeanTween.value(gameObject, canvasGroup.alpha, 0, UIConsts.menuAnimationsTime)
			.setOnUpdate((a) => {
				canvasGroup.alpha = a;
			})
			.setOnComplete(() => {
				canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
				setOnComplete?.Invoke();
				gameObject.SetActive(false);
			});
		}
		else {
			canvasGroup.alpha = 0.0f;
			canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
			setOnComplete?.Invoke();
			gameObject.SetActive(false);
		}
	}
}
