var webpack = require("webpack");
var path = require("path");
var glob = require("glob");

var assets = path.join(__dirname, "wwwroot", "assets");

module.exports = {
    resolve: {
        extensions: ["", ".ts", ".tsx", ".js"]
    },
    entry: {
        "/home/home": "./features/home/home.tsx"
    },
    output: {
        path: assets,
        filename: "[name].js",      
    },
    module: {
    loaders: [
      // all files with a `.ts` or `.tsx` extension will be handled by `ts-loader`
      { test: /\.tsx?$/, loader: 'ts-loader' }
    ]
    },
    plugins: [
         new webpack.DllReferencePlugin({            
             context: ".",
             manifest: require("./wwwroot/assets/vendor-manifest.json")
         }),
        new webpack.optimize.UglifyJsPlugin({
             compress: { warnings: false }
        })
    ]
};