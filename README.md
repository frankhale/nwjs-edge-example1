#nw-edge-example

An example usage of Node-Webkit and EdgeJS. This code calls a function inside a .NET class library. I've included everything (except Node-Webkit) so this example code should work out of the box.

###Note (If you want to build your own Edge.JS)

Edge.JS had to be rebuilt using nw-gyp in order for it to work from within Node-Webkit.

Things you need in order to build Edge.JS yourself:

- Windows
- Windows 7.1 SDK
- Visual C++ 2010 Express
- Python 2.7.x
- Node.JS
- nw-gyp (node module)

Next, open a command prompt to your source code directory and install the Edge.JS module using npm:

```
c:\>cd my-app
c:\my-app>npm install edge
```

This will create a node-modules folder and then install edge into that folder. Now we need to recompile Edge using nw-gyp (instead of node-gyp which it is built with by default).

(assuming Node-Webkit 0.8.4 is the target version of Node-Webkit)

```
c:\my-app\>cd node_modules\edge
c:\my-app\node_modules\edge>nw-gyp configure --target=v0.8.4
c:\my-app\node_modules\edge>nw-gyp build
```

Once the build finishes, the new module will be in:

```
c:\my-app\node_modules\edge\build\Release
```

Copy edge.node to:

```
c:\my-app\node_modules\edge\lib\native\win32\ia32\0.10.0
```

###Usage

You need Node-Webkit and Windows to run this.

- Clone or download a zip of this repository
- Unzip into it's own folder (assuming folder named edge-test-app)
- Unzip node-webkit
- Copy edge-test-app folder to node-webkit folder
- Open command prompt to node-webkit
- Run using the command: nw edge-test-app

###License 

GPL version 3, see LICENSE file for details