var webpack = require("webpack");
var path = require("path");
var assets = path.join(__dirname, "wwwroot", "assets");
var glob = require("glob");

var entries = {};
var files = glob.sync("./Features/**/*.tsx");
files.forEach(file => {
    var name = file.match("./Features(.+/[^/]+)\.tsx$")[1];
    entries[name] = file;
});

module.exports = {
    resolve: {
        extensions: ["", ".ts", ".tsx", ".js"],
        modulesDirectories: [
            "./Client/script/"
        ]
    },
    entry: entries,
    output: {
        path: assets,
        filename: "[name].js"    
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