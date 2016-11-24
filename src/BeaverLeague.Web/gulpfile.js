var gulp = require("gulp");
var del = require("del");
var cleancss = require("gulp-clean-css");
var run = require("run-sequence");
var exec = require('child_process').exec;

gulp.task("clean", function () {
    return del("wwwroot/assets");
});

gulp.task("js:vendor", function (done) {
    exec("webpack --config webpack.vendor.config.js", function(err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        done(err);
    });
});

gulp.task("js:app", function(done) {
    exec("webpack --config webpack.config.js", function(err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        done(err);
    });
});

gulp.task("css:minify", function () {
    return gulp.src("client/css/theme.css")
               .pipe(cleancss())
               .pipe(gulp.dest("wwwroot/assets/"));
});

gulp.task("vendorcss:copy", function () {
    return gulp.src([
            "node_modules/font-awesome/css/**/*",
            "node_modules/font-awesome/fonts/**/*",
            "node_modules/bootstrap/dist/**/*"
           ], { base: "node_modules" })
        .pipe(gulp.dest("wwwroot/assets"));
});


gulp.task("build", function () {
    return run("clean",
                ["css:minify", "vendorcss:copy", "js:vendor"],
                "js:app");
});

gulp.task("default", ["build"]);