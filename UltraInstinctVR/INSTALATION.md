# How to Install UltraInstinctVR

To install **UltraInstinctVR**, you first need to install **Xareus**.  
Follow this tutorial for installation: [Xareus First Installation Guide](https://xareus.insa-rennes.fr/tutorials/firstinstallation.html)
If you have problem with ILog after Xareus installation, remove **Version Control** package

> **Important:**  
> For authentication to the repository, **contact Gerry Longfils on Teams**.

### Installation Steps:

- Import the UltraInstinctVR package into your Unity `Assets` folder by [Import local package](https://docs.unity3d.com/es/2019.4/Manual/AssetPackagesImport.html) 
- Add the **Zeno** GameObject to your scene hierarchy.

---

# How to Run UltraInstinctVR
1. Assign oracle to game object -> see explanation just bellow
2. Run the Unity application.
3. Let UltraInstinctVR execute the test cases automatically.
4. The test suite finish when in the log the message "Test suite terminated appears"
5. Once UltraInstinctVR has finished:
   - Stop the Unity project.
   - Retrieve the generated **HTML report** from the root directory of your project.
  
# Assign oracle to game object

1. Open the scenario editor : Xareus -> Open scenario editor
2. Open a scenario file, it's a .xml file
3. Click on the transition
4. Affect the good game object to sensor and effector

# Game Object to XML File Mapping

| Game Object | XML File                          |
|-------------|-----------------------------------|
| GOKU        | Oracle_Teleportation.xml          |
| GOHAN       | Oracle_Teleportation_Outside.xml  |
| GOTEN       | Oracle_Teleportation_InObject.xml |
| MARADONA    | Oracle_Selection.xml              |
| BROLY       | Oracle_Colission.xml              |
| VEGETA      | Oracle_MoveObjectToOrigin.xml     |



 
