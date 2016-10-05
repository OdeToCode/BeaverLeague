var gulp = require("gulp");
var del = require("del");
var cleanCss = require("gulp-clean-css");

gulp.task("clean:assets",
    function() {
        return del("wwwroot/assets");
    });

gulp.task("css:minify",
    ["clean:assets"],
    function() {
        return gulp.src("wwwroot/app/css/theme.css")
            .pipe(cleanCss())
            .pipe(gulp.dest("wwwroot/assets/app/css"));
    });

gulp.task("copy:assets",
    ["clean:assets"],
    function() {
        return gulp.src([
                "node_modules/font-awesome/css/**/*",
                "node_modules/font-awesome/fonts/**/*",
                "node_modules/bootstrap/dist/**/*"
            ], {base:"node_modules"})
            .pipe(gulp.dest("wwwroot/assets"));
    });

gulp.task("default", ["copy:assets", "css:minify"]);