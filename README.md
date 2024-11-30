# C# / UnityExercise-OP
Take Home Exercise

All Exercises exist within their own branches and merged into main. 
The first 2 exercises are not implemented within unity and are done as implementations of individual functions as C# Code that would be used in other games.

Ex1 is Exercise1.cs , Located within the EX1 folder.

Ex2 is Board.cs , Located within the EX2 folder.

Ex3 is the unity project, contained within the Exercise 3 Scene, with scripts found in the asset folder.

The unity project allows you to test your luck by watching if your player can make it through the 3 rings without hitting a random asteroid, don't worry if you hit one as the option to reset will be presented for you to try as many times as you want. Your attempts and wins will be displayed while playing. 

There is no player input, it is all based on luck if you can make it to the end of the course, however you can go around the problem by disabling collisions within the inspector should you choose.

The path can be altered through the editor by utilizing the LevelManager, here you can set a list of points for the player to go between in order, You can also change the amount of asteroids each run, and importantly where they might appear as they are confined to spawn randomly within the spawnerbounds.
