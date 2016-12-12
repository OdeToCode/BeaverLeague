module.exports = function(config) {
  config.set({
    basePath: '',
    frameworks: ['jasmine'],
    files: [
      "./wwwroot/assets/vendor.js",
      "./wwwroot/assets/tests/**/*.specs.js"
    ],
    reporters: ['progress'],
    browsers: ['Chrome'],
  })
}
