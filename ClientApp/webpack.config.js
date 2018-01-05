const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const WriteFilePlugin = require('write-file-webpack-plugin');

module.exports = {
    entry: './src/js/index.jsx',
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'bundle.js'
    },
    devServer: {
        contentBase: path.join(__dirname, "dist"),
        port: 12000,
        hot: true,
        historyApiFallback: true
    },
    module: {
        loaders: [
            {
                test: /\.jsx$/,
                exclude: /node_modules/,
                loader: 'babel-loader'
            },
            {
                test: /\.scss$/,
                loader: ExtractTextPlugin.extract('css-loader','sass-loader')
            }
        ]
    },
    plugins: [
        new ExtractTextPlugin('bundle.css'),
        new WriteFilePlugin({
            test: /\.(jpg|png|gif)$/,
            useHashIndex: true
        }),
        new webpack.NamedModulesPlugin(),
        new webpack.HotModuleReplacementPlugin()
    ]
}