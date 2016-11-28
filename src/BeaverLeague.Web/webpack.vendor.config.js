const webpack = require("webpack");
const path = require("path");
const assets = path.join(__dirname, "wwwroot", "assets");

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
        library: "[name]_dll"      
    },
    plugins: [
        new webpack.DllPlugin({
            path: path.join(assets, "[name]-manifest.json"),
            name: '[name]_dll'
        }),
        //new webpack.optimize.UglifyJsPlugin({ compress: { warnings: false } })
    ]
};