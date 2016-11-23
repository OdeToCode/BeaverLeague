var webpack = require("webpack");
var path = require("path");

var assets = path.join(__dirname, "wwwroot", "assets");

module.exports = {
    resolve: {
        extensions: ["", ".js"]
    },
    entry: {
        vendor: [
            "react",
            "react-dom"
        ]
    },
    output: {
        path: assets,
        filename: "[name].js",      
    },
    plugins: [
        new webpack.DllPlugin({
            path: path.join(assets, "[name]-manifest.json"),
            name: '[name]'
        }),
        new webpack.optimize.UglifyJsPlugin({ compress: { warnings: false } })
    ]
};