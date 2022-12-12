# MONOCLE REDUX GAME ENGINE
Monocle Redux is a 2D game engine for the FNA rendering framework and csharp 6.0. 
Monocle Redux is an extension of the Monocle Game Engine by Maddy Thorson (previously available as open source under MIT License, BitBucket repository was removed or privated). 
Over the years I expanded it to fit my needs and now I'm open sourcing it under the same license.

# Demo
- [Celeste](https://www.youtube.com/watch?v=70d9irlxiB4)

Some of my recent games were made with this engine:
- [Fishing Game](https://youtu.be/qOIECLcgGXw) - side view 2d building game with fishing elements, inspired by Terraria
- [Whiteout](https://youtu.be/UUHIKTK7KCQ) - basic top down arpg/roguelike akin to path of exile with spells, randomly generated dungeons and several bosses
- the demo project in this repository

# Features
The following features were designed and crafted by Maddy Thorson, I'm just listing them here.
- fully featured Scene - Entity - Component system. Use components to implement functionality. Use Entities to group that functionality and hold common data. Use Scenes to group and manage Entities.
- fully featured Collision system. Give entities rectangle, circle, line or grid colliders
- layered rendering in a grouping system utilizing tags. Use `SingleTagRenderers` to separate game elements with ui
- extensive debugging with an in-engine expandable command-based framework (essentially a basic terminal inside the engine)

Features added by me:
- (WIP) extendable and reusable UI system with mouse capture and advanced layouting since those are always a pain to develop
- several Graphical Components for simple sprite sheets if `SpriteBanks` are too complicated
- an implementation of SimplexNoise
- `MultiTagRenderer`, `ParallaxRenderer`, `TiledRenderer` for when you need them
- raycasting algorithm in `GridCollider`
- several smaller changes, fixes and extensions in too many places to list and also moved the engine over to net6.0

# Installation
- pull this repository
- add the "Monocle Redux" project as a dependency
- subclass "Monocle.Engine" and proceed like normal FNA practice

Use the Demo project as a reference and create GitHub issues if you have questions. I'm happy to help.