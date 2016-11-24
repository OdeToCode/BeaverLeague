var webpack = require("webpack");
var path = require("path");

var assets = path.join(__dirname, "wwwroot", "assets");

module.exports = {
    resolve: {
        extensions: ["", ".ts", ".tsx", ".js"]
    },
    entry: {
        
    },
    output: {
        path: assets,
        filename: "[name].js",      
    },
    module: {
    loaders: [
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