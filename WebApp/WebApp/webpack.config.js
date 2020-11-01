const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin')
var nodeExternals = require('webpack-node-externals');
module.exports = {
  mode: 'development',
  entry: {
    Index: './src/index.ts',
  },
  resolve: {
    extensions: ['.js', '.ts', '.vue']
  },
  devtool: 'inline-source-map',
  devServer: {
    contentBase: './wwwroot',
  },
  output: {
    filename: 'bundle/[name].js',
    path: path.resolve(__dirname, 'wwwroot'),
  },
  target: 'web',
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        loader: 'ts-loader',
        options:{
          appendTsSuffixTo: [/\.vue$/],
        }
      },
      {
        test: /\.vue$/,
        loader: 'vue-loader'
      }
    ],
  },
  plugins: [
    new VueLoaderPlugin()
  ]
};