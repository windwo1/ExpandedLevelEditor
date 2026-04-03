# GW2 Level Editor

A modified version of the Level Editor plugin for 1.0.7 for PvZ GW2. It will let you export levels. Exports meshes, textures, terrain, terrain layers and vector paramaters.

If you want to port this to other games, it'll probably be better if you clone the original repo: https://github.com/CadeEvs/FrostyToolsuite/tree/LevelEditor.
Then copy in the main scripts I've edited:

- ModelRenderProxy.cs
- TerrainRenderable.cs
- MeshAsset.cs
- MeshRenderable.cs
- LevelEditor.cs

This is because when I ported this to GW2 I did it very lazily.