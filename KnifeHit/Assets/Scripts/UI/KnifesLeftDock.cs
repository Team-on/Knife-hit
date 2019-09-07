﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifesLeftDock : MonoBehaviour {
	public GameObject KnifeLeftIconPrefab;

	GameObject[] icons;
	int currIcon;

	private void Awake() {
		EventManager.OnGameStart += OnGameStart;
		EventManager.OnKnifeShoot += OnKnifeShoot;
	}

	void OnDestroy() {
		EventManager.OnGameStart -= OnGameStart;
		EventManager.OnKnifeShoot -= OnKnifeShoot;
	}

	void OnGameStart(EventData eventData) {
		Init((int)(eventData?["maxShoots"] ?? 0));
	}

	void OnKnifeShoot(EventData eventData) {
		Image img = icons[currIcon++].GetComponent<Image>();
		Color c = img.color;
		c.a = 0.5f;
		img.color = c;
	}

	void Init(int maxShoots) {
		if(icons != null) {
			foreach (var i in icons) 
				Destroy(i);
		}

		icons = new GameObject[maxShoots];
		currIcon = 0;
		while (maxShoots-- != 0) {
			icons[maxShoots] = Instantiate(KnifeLeftIconPrefab, transform);
		}
	}
}
