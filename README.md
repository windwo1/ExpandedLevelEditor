# Expanded Level Editor

A modified version of the Level Editor plugin for Frosty Editor (1.0.7) for both PvZ GW2 & PvZ GW1. Other games like SWBF2 and Mass Effect are supported but haven't really been tested. 

## Editing

With this fork of the Level Editor, you'll be able to now:
- Modify static models, maps are mostly made up of these, and they are now editable!
- Add objects to a map
- Delete objects from a map
- Duplicate a selected object
- Modify an object's transform from the Properties panel, so you're no longer limited to the Translate gizmo

Also make sure you convert your project back to 1.0.6.3 by going to 'Developer > Save project as old' so you can export your mod in 1.0.6.3, so everyone else can use your mod.

# **Important Note:**
If you're editing static models for a mod (which most likely you will, since maps are mostly made of them), anyone using your mod will need this plugin to open it:

https://github.com/windwo1/HavokPhysicsResourcePlugin/releases

Which includes you, since you'll need to open the project in 1.0.6.3 to export it in the first place.

## Exporting

This plugin will also let you export levels to Blender, and will export meshes, textures, terrain, terrain layers and vector paramaters.

Python scripts to import the levels to blender:

**GW2:** https://drive.google.com/file/d/1yKodkvfjvWh45hn-r1Hrh7_lF9b2vswg/view?usp=sharing

**GW1:** https://drive.google.com/file/d/1gL5wfgkK6MpXSoGN444G5yZl-snCyWI_/view?usp=sharing