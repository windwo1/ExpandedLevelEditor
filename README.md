# Expanded Level Editor

A modified version of the Level Editor plugin for Frosty Editor for both PvZ GW2 & PvZ GW1. Other games like SWBF2 and Mass Effect are supported but haven't been tested. 

## Editing

With this fork of the Level Editor, you'll be able to now:
- Modify static models, maps are mostly made up of these, and they are now editable
- Add objects to a map (make sure you use a bundle manager plugin if they are crashing the game)
- Delete objects from a map
- Duplicate a selected object
- Modify an object's transform from the Properties panel, so you're no longer limited to the Translate gizmo

# **Important Note:**
If you're editing static models for a mod (which most likely you will, since maps are mostly made of them), anyone using your mod will need this plugin to open it (plugin for the mod manager):

https://github.com/windwo1/HavokPhysicsResourcePlugin/releases

Also make sure you don't have both the Havok plugin and the Level Editor plugin on at the same time, it seems to cause static model edits to not work.

## Exporting

This plugin will also let you export levels to Blender, and will export meshes, materials, terrain and terrain layers.

Python scripts to import the levels to blender:

**GW2:** https://drive.google.com/file/d/16JkmI7uJgIomrbtzTAEZAbnzJDg5ZWW6/view?usp=sharing

**GW1:** https://drive.google.com/file/d/1qvZfDA08LsRXEWmlV674npO87DdL6WMc/view?usp=sharing