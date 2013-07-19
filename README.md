nppPluginTypescript
===================

notepad ++ plugin for typescript, 
so far I have compile on save
and run js in node

To use the plugin comiple it (VS2012) and put the DLL into the plugin folder under the notpad ++ install folder.
Restart notepap++ and you should find a new menu under the plugins menu.

Also this hooks into the save notification and if you are saving a .ts file 
it will compile it using a shell and the tsc command line compiler, which you will need to install separately.

The "Run (node.js) javascript" command will execute node with the js file as argument.

Todo:
syntax coloring and intellisense
