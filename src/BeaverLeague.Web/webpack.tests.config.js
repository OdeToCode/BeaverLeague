const webpack = require("webpack");
const path = require("path");
const assets = path.join(__dirname, "wwwroot", "assets", "tests");
const glob = require("glob");

const entries = {};
let files = [];
files = files.concat(glob.sync("./Features/**/*.specs.ts*"));
files = files.concat(glob.sync("./Client/script/**/*.specs.ts*"));

files.forEach(file => {
    var name = file.match("\.\/(?:Features|Client\/script)(.+\/[^\/]+)\.tsx?")[1];
    entries[name] = file;
});

module.exports = {
    resolve: {
        extensions: ["", ".ts", ".tsx", ".js"],
        modulesDirectories: [
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
        loaders: [
          { test: /\.tsx?$/, loader: 'ts-loader' }
        ]
    }, 
    plugins: [
         new webpack.DllReferencePlugin({            
             context: ".",
             manifest: require("./wwwroot/assets/vendor-manifest.json")
         }),
    ]
};