using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class MainContextRoot : ContextView {
	void Start () {
		context = new MainContext(this);
	}
}
