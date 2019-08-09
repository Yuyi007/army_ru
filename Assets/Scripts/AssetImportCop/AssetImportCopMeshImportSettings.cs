using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct MeshImporterSettings
{
    public bool readWriteEnabled;
    public bool optimiseMesh;
    public bool ImportBlendShapes;
    public bool importMaterials;
    public bool changeReadableSettings;
    #if UNITY_EDITOR
    public ModelImporterNormals normalImportMode;
    public ModelImporterAnimationType animationType;
    public ModelImporterMeshCompression meshCompression;
	public ModelImporterTangents importTangents;
    #endif

#if UNITY_EDITOR
    public static MeshImporterSettings Extract(ModelImporter importer)
    {
        if (importer == null)
            throw new ArgumentException();

        MeshImporterSettings settings = new MeshImporterSettings();
        settings.readWriteEnabled = importer.isReadable;
        settings.optimiseMesh = importer.optimizeMesh;
        settings.ImportBlendShapes = importer.importBlendShapes;
        settings.normalImportMode = importer.importNormals;
        settings.animationType = importer.animationType;
        settings.importMaterials = importer.importMaterials;
        settings.meshCompression = importer.meshCompression;
		settings.importTangents = importer.importTangents;
        return settings;
    }

    public static bool Equal(MeshImporterSettings a, MeshImporterSettings b)
    {
        return (a.readWriteEnabled == b.readWriteEnabled) && 
            (a.optimiseMesh == b.optimiseMesh) && 
            (a.ImportBlendShapes == b.ImportBlendShapes) && 
            (a.normalImportMode == b.normalImportMode) &&
            (a.importMaterials == b.importMaterials) &&
            (a.animationType == b.animationType) &&
            (a.meshCompression == b.meshCompression) &&
			(a.importTangents == b.importTangents) &&
            (a.changeReadableSettings == b.changeReadableSettings);
    }

    public void ApplyDefaults()
    {
        readWriteEnabled = false;
        optimiseMesh = true;
        ImportBlendShapes = false;
        normalImportMode = ModelImporterNormals.Import;
        animationType = ModelImporterAnimationType.None;
        meshCompression = ModelImporterMeshCompression.Off;
        importMaterials = true;
		importTangents = ModelImporterTangents.None;
        changeReadableSettings = false;
    }
#endif
}