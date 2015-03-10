#nw-edge-example

An example usage of Node-Webkit and Edge.JS. This code calls a function inside 
a .NET class library from the DOM. I've included everything (except Node-Webkit) 
so this example code should work out of the box.

<img src="https://github.com/frankhale/nw-edge-example/blob/master/edge-test.png?raw=true" alt="screenshot"/>

###Usage

You need Node-Webkit and Windows to run this.

- Clone or download a zip of this repository
- Unzip into it's own folder (assuming folder named edge-test-app)
- Unzip node-webkit
- Copy nw-edge-example folder to node-webkit folder
- Open command prompt to node-webkit
- Run using the command: nw nw-edge-example

**NOTE: The Edge node module is included in the repo on purpose. If you are 
running x64 Windows you won't need to run any of the compile instructions below 
as the module has been compiled for NW 0.12.0 already.**

###C# Class Library

The SimpleLibrary.dll is built from the Hello.cs source file. I've omitted the 
Visual Studio project to build this from this repository. This library only 
contains one function as noted in the Hello.cs. Notice the function signature 
is special because by default Edge.JS wants to call asynchronous methods so it 
does not block the Javascript engine. 

If you want to see more examples of using Edge.JS please see it's Github 
repository located at:

https://github.com/tjanczuk/edge

##Development

###Building Your Own Edge.JS

Edge.JS has to be rebuilt using nw-gyp in order for it to work from within 
Node-Webkit. 

NOTE: By default Edge.JS is built using node-gyp and only works within Node.JS.

Things you need in order to build Edge.JS yourself:

- Visual Studio 2013
- Python 2.7.x
- Node.JS 0.12.0
- nw-gyp (npm install -g nw-gyp)

Next, open a command prompt to your source code directory and install the 
Edge.JS module using npm:

Create a folder on your desktop (for illustration call it my-app) and copy the 
Node-Webkit runtime files to it.

Next open a command prompt to the my-app folder and install the Edge.JS module:

```
c:\>cd my-app
c:\my-app>npm install edge
```

This will create a node-modules folder and then install edge into that folder. 
Now we need to recompile Edge using nw-gyp (instead of node-gyp which it is 
built with by default).

**NOTE: Assuming Node-Webkit 0.12.0 is the target version of Node-Webkit.**

```
c:\my-app\>cd node_modules\edge
c:\my-app\node_modules\edge>nw-gyp configure --target=v0.12.0 --msvs_version=2013
c:\my-app\node_modules\edge>nw-gyp build
```

Once the build finishes, the new module will be in:

```
c:\my-app\node_modules\edge\build\Release
```

Copy edge.node to: (depending on your architecture, I built against x64)

```
c:\my-app\node_modules\edge\lib\native\win32\x64\0.12.0
```

Additionally, you will likely need to edit the versionMap in node_modules\edge\lib\edge.js

Add the following line: (update as necessary for the version of Node you are 
using, currently Node 0.12 is being reported as Node 0.1.2 by Edges version 
detection function. So you'll have to update the versionMap inside the 
following file:

```
node_modules\edge\lib\edge.js
```

Add the following line to the versionMap:

```
[ /1.2.0/, '0.12.0' ]
```

###Author

Frank Hale &lt;frankhale@gmail.com&gt;  
9 March 2015

###License 

GPL version 3, see LICENSE file for details
