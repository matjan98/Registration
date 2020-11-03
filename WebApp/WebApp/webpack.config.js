const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin')
var nodeExternals = require('webpack-node-externals');
module.exports = {
  mode: 'development',
  entry: {
    Index: './src/index.ts',
  },
  resolve: {
    extensions: ['.js', '.ts', '.vue'],
    alias: { 
      vue: 'vue/dist/vue.esm.js' 
    }
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
        loader: 'vue-loader',
        options: {
          loaders: {
              scss: 'vue-style-loader!css-loader!sass-loader', // <style lang="scss">
              sass: 'vue-style-loader!css-loader!sass-loader?indentedSyntax' // <style lang="sass">
          }
      }
      },
      {
        test: /\.css$/i,
        use: ['style-loader', 'css-loader'],
      },
      {
        test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
        use: [
          {
            loader: 'file-loader',
            options: {
              name: '[name].[ext]',
              outputPath: 'fonts/'
            }
          }
        ]
      }
    ],
  },
  plugins: [
    new VueLoaderPlugin()
  ]
};