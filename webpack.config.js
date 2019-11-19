const path = require("path")

module.exports = {
    entry: "./src/App.fsproj",
    devServer: {
        contentBase: path.join(__dirname, "./dist")
    },
    module: {
        rules: [{
            test: /\.fs(x|proj)?$/,
            use: "fable-loader"
        }]
    }
}

module: {
    loaders: [
      { test: /\.(png|jpg)$/, loader: 'url-loader?limit=8192' }
    ]
  }