var path = require('path');

exports.getCompiler = function () {
	return process.env.EDGE_CS_NATIVE || path.join(__dirname, 'edge-cs.dll');
};
