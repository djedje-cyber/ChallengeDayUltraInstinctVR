# UltraInstinctVR 

## What is UltraInstinctVR 

UltraInstinctVR is a VR interaction testing framework that simulate interaction in a VR application and check that actions/oracles passed and are done correctly throughout the scenario engine Xareus.

### What is Xareus?

"Xareus is a set of tools that help creators develop XR applications easily and fast. It aims to put the domain experts in the center of the development process and provide higher abstraction levels than code when necessary. It is compatible with any C# application and can be delivered as a Unity package to facilitate its management."

references : https://xareus.insa-rennes.fr/?tabs=air



### What is a interaction in VR ?
An interaction can be defined as selecting, grabbing, moving objects and players in the virtual world.

There exists three types of interaction in VR.
- Selection : it's selecting game object in the scene, it tell you that after selecting an object you can interact with it.
- Locomotion : It's the way of moving in the scene, it can be perform by teleportation of movement with the headset in the scene

- Manipulation : it's interacting with game object, making actions in the scene with game objects

More and precise informations : https://www.futurelearn.com/info/courses/construct-a-virtual-reality-experience/0/steps/96390


### How test cases are defined in UltraInstinctVR?

To define test cases in virtual reality, we need severals components, that will simulate interactions when the application will run.

The first component is the parent component, it serve to launch each tests cases one by one independenly.

Each, tests cases contains a gameobject that represent a part of the player.

By example, Goku represent the headset of the player, its simulates the locomotion instead of Vegeta that represent the hand of the player.

Each game objects contains OpenXR scripts that unity need to trigger an action on the game object, contains a script that simulate an interaction (by example moving each game object to the center) and a Xareus scenario to verify the oracle.


### How de we define oracle with Xareus Tool?

In virtual reality, we don't define oracle as we can do as usual with assertion at the end of the test.

We use instead petri-nets to define oracle because they need to be checked each time the interaction is trigger.


An oracle has the form of a  petri-nets, we define the initial state, it's bassicaly when you lanch the unity application. Then we move to the first transition, where a sensor listen to the scene each millisecond et wait that a specific action is trigger (by example performing a teleportation), then the transition move to the effector and check that the action detected by the sensor is well effected, if the action failed, a log error appear, if not a simple log to say that the oracle passed.

After that we pass to the final state to finally go back to the initial state.


### How to write a new test cases?


#### Creation of a game object
  - Create a child game object to the parent game object
  - Insert all component that you need to perform your task (Eg : if it's a hand, add openXR component related to)
  - Create an automated interaction in a monobehavior script
  - Add the child component script in the game object

#### Create an oracle using Xareus
 - Add all the component needed to make Xareus works.
 - Create the sensor in the /Sensor folder
 - Create the effector in the /Effector folder
 - Open the Xareus editor and create a new scenario, edit the scenario as the petri-net described above.
 - Assign the initial and the final state
 - Affect the sensor and the effector to the transition



 ### Already implemented oracles and details about the prefab component

 #### Zeno
 Manage to control each subcomponent, responsible of launching each componenent independantly

 #### Beerus

 Scan the unity scene, and find interactable object, in the scene, the scan stopeed once the ammount of object found drop to zero.

 #### Goku

 Try to carry out a some teleportation in the scene, the oracle pass if goku can teleport, and fail if not

 #### Gohan
  Try to carry out out teleportation outside the scene, the oracle fail, if the teleportation is done


 #### Goten

Try to carry out teleportation in game object, the oracle fail, if the goten can teleport in a game object



 #### Maradona (it's a reference to maradona hand's god in the 86's FIFA world cup  : https://www.youtube.com/watch?v=-ccNkksrfls)

 Try to select game object, the oracle pass if it's done, fail if not, 

 #### Broly

 It's a cube in the game that will enter in collision with each interactable object, if the colission is done, the oracle pass, fail if not

 #### Vegeta

 VEGETA will select each interactable object, grab and move it to the point (0,0,0), the oracle verify that the object can move by a OpenXR hands.
 The oracle pass if the action is done and fail if not.

 #### Karin
Generate the HTML report by reading the log.






