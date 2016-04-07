#nw-edge-example

An example usage of Node-Webkit and Edge.JS. This code calls a function inside
a .NET class library from the DOM. 

<img src="https://github.com/frankhale/nw-edge-example/blob/master/edge-test.png?raw=true" alt="screenshot"/>

###Usage

You need Node-Webkit and Windows to run this.

- Clone or download a zip of this repository
- Unzip into it's own folder (assuming folder named edge-test-app)
- Unzip node-webkit
- Copy nw-edge-example folder to node-webkit folder
- Open command prompt to node-webkit
- Run using the command: nw nw-edge-example

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
- Node.JS 5.x
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

```
c:\my-app\>cd node_modules\edge
c:\my-app\node_modules\edge>nw-gyp configure --target=v0.13.3 --msvs_version=2013 --arch=x64
c:\my-app\node_modules\edge>nw-gyp build
```

Once the build finishes, the new module will be in:

```
c:\my-app\node_modules\edge\build\Release
```

Copy edge_coreclr.node and edge_nativeclr to: (depending on your architecture, I built against x64)

```
c:\my-app\node_modules\edge\lib\native\win32\x64\5.1.0
```

###Author

Frank Hale &lt;frankhale@gmail.com&gt;  
7 April 2016

###License

GPL version 3, see LICENSE file for details
