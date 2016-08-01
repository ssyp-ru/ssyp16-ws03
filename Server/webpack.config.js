module.exports = {
    entry: {
        App: './Content/Scripts/UI/App.ts'
    },
    output: {
        filename: '[name].js',
        path: __dirname + "/Content/Scripts/Build/",
        library: "App"
    },
    devtool: 'source-map',
    resolve: {
        extensions: ['', '.webpack.js', '.web.js', '.ts', '.js']
    },
    module: {
        loaders: [
            {
                test: /\.ts$/,
                loader: "regenerator!babel!ts-loader"
            }
        ]
    }
}