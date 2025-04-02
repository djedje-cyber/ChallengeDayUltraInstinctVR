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


An oracle has this form in the petri-nets, we define the initial state, it's bassicaly when you lanch the unity project we have this state. 




