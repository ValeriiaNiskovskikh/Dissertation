const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const bundleOutputDir = './wwwroot/dist';
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return [{
        mode: isDevBuild? 'development' : 'production',
        stats: {modules: false},
        context: __dirname,
        resolve: {extensions: ['.js', '.ts', '.vue']},
        entry: {'main': './ClientApp/boot.ts'},
        module: {
            rules: [
                {
                    test: /\.vue\.html$/,
                    include: /ClientApp/,
                    loader: 'vue-loader',
                    options: {loaders: {js: 'awesome-typescript-loader?silent=true'}}
                },
                {test: /\.ts$/, include: /ClientApp/, use: 'awesome-typescript-loader?silent=true'},
                {
                    test: /\.css$/,
                    use: ['style-loader', 'css-loader']
                },
                // {test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=35000000'},
                {
                    test: /\.(png|svg|jpg|gif)$/,
                    use: [{
                        loader: 'file-loader',
                        options: {
                            name:'img/[name]_[hash:7].[ext]',
                        }}]
                },
                // {
                //     test: /\.vue$/,
                //     loader: 'vue-loader'
                // },
                // {
                //     test: /\.js$/,
                //     loader: 'script-loader'
                // },
                // {
                //     test: /\.ts$/,
                //     loader: 'vue-loader'
                // }
            ]
        },
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: 'dist/'
        },
        plugins: [
            new VueLoaderPlugin(),
            new CheckerPlugin(),
            new webpack.DefinePlugin({
                'process.env': {
                    NODE_ENV: JSON.stringify(isDevBuild ? 'development' : 'production')
                }
            }),
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
            // Plugins that apply in production builds only
            new ExtractTextPlugin('site.css')
        ]), 
    }];
};
