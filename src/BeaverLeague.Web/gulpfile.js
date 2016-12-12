var gulp = require("gulp");
var del = require("del");
var cleancss = require("gulp-clean-css");
var run = require("run-sequence");
var exec = require("child_process").exec;
var path = require("path");
var webpackcmd = path.join("node_modules", ".bin", "webpack");

gulp.task("clean", () => del("wwwroot/assets"));

gulp.task("js:vendor", (done) => {
    exec(webpackcmd + " --config webpack.vendor.config.js", function(err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        done(err);
    });
});

gulp.task("js:app", (done) => {
    exec(webpackcmd + " --config webpack.config.js", function(err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        done(err);
    });
});

gulp.task("js", () => run("js:vendor", "js:app"));

gulp.task("css:minify", () =>
    gulp.src("client/css/theme.css")
        .pipe(cleancss())
        .pipe(gulp.dest("wwwroot/assets/"))
);

gulp.task("vendorcss:copy", () => 
    gulp.src([
            "node_modules/font-awesome/css/**/*",
            "node_modules/font-awesome/fonts/**/*",
            "node_modules/bootstrap/dist/**/*"
           ], { base: "node_modules" })
        .pipe(gulp.dest("wwwroot/assets"))
);


gulp.task("build", () => 
        run("clean", ["css:minify", "vendorcss:copy", "js"])
);

gulp.task("default", ["build"]);