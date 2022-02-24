# Top down 2D controller for Unity

## Description
This project is a Unity package containing scripts as well as example assets/scene.

This project contains a lot of scripts to allow the user to easily customize the behaviors attached to an entity. 

Be mindful that this project is still in development and there are some parts of the code that have still not been properly refactorized.

## Features
- Top down movement with 2D sprites
- Top down shooting mechanic
- Health and damage system
- Reusable scripts between player and enemies
- Sound and visual effects system
- Highly customizable stats and power-ups
- Playable with mouse/keyboard or with a controller
- Easy to implements enemy AIs

## How it works
In order to use this package you should check the example scene located at Sample/Scenes/TopDownExampleScene. This scene and its content should give you a rough idea of how this system works.

This packages uses dynamic rigidbodies for the physics and movements and by playing with its values as well as the speed of the character you can achieve different style of movement.

This packages also uses Unity's tags and layers systems so be careful to properly set those in order for the enemies to behave properly and the bullets to actually hit the right type of entities.

For an entity to be valid it needs at least a script extending from TopDownCharacterController this script will be in charge of creating the events (such as OnMove, OnAttack...) and transmit them to the other components of the system. In case you want an entity to have an AI you can take a look at some other example controllers (Scripts/Controllers/TopDownRangeEnemyControler for example) to see how to write your own implementation.

An entity will also need a CharacterStatHandler component to work since it contains some important values such as the speed and max health of the entity, as well as its attack properties (At the moment the only type of attack implemented is ranged attack with bullets, and a configuration for such an attack can be created by right clicking in the project hierarchy and selecting Create -> TopDownController -> Attacks -> Shoot)