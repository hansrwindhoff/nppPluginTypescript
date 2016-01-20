DEPRECIATED - nppPluginTypescript
===================

notepad ++ plugin for typescript, 
so far 'compile on save'
and 'run js in node'.

To use the plugin compile it (VS2012) and put the DLL into the plugin folder under the notpad++ install folder.
Restart notepad++ and you should find a new submenu in the plugins menu.

Also, this plugin hooks into the save notification and if you are saving a .ts file 
the plugin will compile it using a shell and the tsc command line compiler, which you will need to install separately.

The "Run (node.js) javascript" command will execute node (install separately) with the js file as argument.

In the plugin info dialog you will find the link to the websites for typescript and node.js

Todo:
  support for tss (https://github.com/clausreinke/typescript-tools)
  


There is a syntax coloring xml file at: https://gist.github.com/wate/5077019 , this gist is not related to me.
