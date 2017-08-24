using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WallGenerator))]
public class WallGeneratorEditor : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		WallGenerator script = (WallGenerator)target;

		if (GUILayout.Button ("Rebuild")) {
			script.Generate ();
		}

	}

}
