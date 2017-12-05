const path = require('path')
const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
    entry: './src/core/root/index.tsx',
    output: {
        path: path.resolve('dist'),
        filename: 'bundle.js'
    },
    module: {
        rules: [
            { test: /\.tsx?$/, use: ['awesome-typescript-loader', 'source-map-loader'] },
            { test: /\.less/, use: [ 'style-loader', 'css-loader','postcss-loader', 'less-loader'] }
        ]
    },
    resolve: {
        extensions: ['.js', '.ts', '.tsx'],
        modules: [
            path.join(__dirname, 'src'),
            'node_modules'
        ]
    },
    plugins: [
        new HtmlWebpackPlugin({
            template: './src/core/root/index.html',
            inject: 'body'
        })
    ],
    devServer: {
        quiet: true,
        historyApiFallback: true,
        compress: true,
        port: 3000
    }
}