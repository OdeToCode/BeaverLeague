var gulp = require("gulp");
var del = require("del");

gulp.task("clean:assets",
    function() {
        return del("wwwroot/assets");
    });

gulp.task("copy:assets", ["clean:assets"],
    function() {
        return gulp.src([
                "node_modules/font-awesome/css/**/*",
                "node_modules/font-awesome/fonts/**/*",
                "node_modules/bootstrap/dist/**/*"
            ], {base:"node_modules"})
            .pipe(gulp.dest("wwwroot/assets"));
    });

gulp.task("default", ["copy:assets"]);
