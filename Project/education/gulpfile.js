// const elixir = require('laravel-elixir');

// require('laravel-elixir-vue-2');

/*
 |--------------------------------------------------------------------------
 | Elixir Asset Management
 |--------------------------------------------------------------------------
 |
 | Elixir provides a clean, fluent API for defining some basic Gulp tasks
 | for your Laravel application. By default, we are compiling the Sass
 | file for our application, as well as publishing vendor resources.
 |
 */

// elixir(mix => {
//     mix.sass('app.scss')
//        .webpack('app.js');
// });
var gulp = require('gulp');
var sass = require('gulp-sass');
gulp.task('default', function() {
    gulp.src('resources/assets/sass/pages/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('resources/assets/sass/dist'));
    gulp.src('resources/assets/sass/admin/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('resources/assets/sass/dist'));
});