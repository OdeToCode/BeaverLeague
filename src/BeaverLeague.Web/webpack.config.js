const webpack = require("webpack");
const path = require("path");
const assets = path.join(__dirname, "wwwroot", "assets");
const glob = require("glob");

const entries = {};
const files = glob.sync("./Features/**/*.main.tsx");
files.forEach(file => {
    var name = file.match("./Features(.+/[^/]+)\.main\.tsx$")[1];
    entries[name] = file;
});

module.exports = {
    resolve: {
        extensions: [".ts", ".tsx", ".js"],
        modules: [
            "./Client/script/",
            "./node_modules"
        ]
    },
    entry: entries,
    output: {
        path: assets,
        filename: "[name].js"           
    },
    devtool: "source-map",
    module: {
        rules: [
          { test: /\.tsx?$/, loader: 'ts-loader' }
        ]
    }, 
    plugins: [
         new webpack.DllReferencePlugin({            
             context: ".",
             manifest: require("./wwwroot/assets/vendor-manifest.json")
         })
    ]
};