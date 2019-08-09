using UnityEngine;
using UnityEditor;


class MeshPostProcessor : AssetPostprocessor {


	void OnPreprocessModel () {
		// (assetImporter as ModelImporter).globalScale = 1;
	}


}
