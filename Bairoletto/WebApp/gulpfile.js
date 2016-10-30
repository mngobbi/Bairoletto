/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var ngAnnotate = require('gulp-ng-annotate');
var useref = require('gulp-useref');
var uglify = require('gulp-uglify');
var rev = require('gulp-rev');
var revReplace = require('gulp-rev-replace');
var del = require('del');
var merge = require('merge-stream');
var runSequence = require('run-sequence');
var templateCache = require('gulp-angular-templatecache');
var htmlmin = require('gulp-htmlmin');

gulp.task('templates', function () {
    return gulp.src('bairoletto/**/*.html')
      .pipe(htmlmin({ collapseWhitespace: false }))
      .pipe(templateCache({ module: 'templates', filename: 'bai-templates.js', standalone: true, base: function (file) { return '/bairoletto/' + file.relative; } }))
      .pipe(gulp.dest('js'));
});

gulp.task('prod', function (callback) {
    runSequence(
        ['master-angular-js', 'master-external-js', 'master-external-css', 'fonts', 'clean', 'templates'],
        'useref-bai-fabrica',
        'useref-bai-puntoventa',
        'useref-bai-login',
        'uglify',
        'rev',
        'revreplace',
        callback);
});

gulp.task('dev', ['master-angular-js', 'master-external-js', 'master-external-css', 'fonts', 'templates'], function () {
    var fabrica = gulp.src('bairoletto/fabrica/fabrica-raw.html')
        .pipe(rename("fabrica.html"))
        .pipe(gulp.dest('bairoletto/fabrica'));
    var puntoventa = gulp.src('bairoletto/puntoventa/puntoventa-raw.html')
       .pipe(rename("puntoventa.html"))
       .pipe(gulp.dest('bairoletto/puntoventa'));
    var login = gulp.src('bairoletto/login/login-raw.html')
       .pipe(rename("login.html"))
       .pipe(gulp.dest('bairoletto/login'));

    return merge(fabrica, puntoventa, login);
});

gulp.task('fonts', function () {
    return gulp.src([
        'node_modules/font-awesome/fonts/fontawesome-*',
        'node_modules/bootstrap/fonts/glyphicons-*'
    ])
        .pipe(gulp.dest('fonts'));
});

gulp.task('useref-bai-fabrica', function () {
    return gulp.src('bairoletto/fabrica/fabrica-raw.html')
        .pipe(rename("fabrica.html"))
        .pipe(useref({ searchPath: './' }))
        .pipe(gulp.dest('bairoletto/fabrica'));
});

gulp.task('useref-bai-puntoventa', function () {
    return gulp.src('bairoletto/puntoventa/puntoventa-raw.html')
        .pipe(rename("puntoventa.html"))
        .pipe(useref({ searchPath: './' }))
        .pipe(gulp.dest('bairoletto/puntoventa'));
});

gulp.task('useref-bai-login', function () {
    return gulp.src('bairoletto/login/login-raw.html')
        .pipe(rename("login.html"))
        .pipe(useref({ searchPath: './' }))
        .pipe(gulp.dest('bairoletto/login'));
});


gulp.task('master-angular-js', function () {
    return gulp.src([
        'node_modules/jquery/dist/jquery.min.js',
        'node_modules/angular/angular.min.js',
        'node_modules/angular-i18n/angular-locale_es-ar.js',
        'node_modules/angular-animate/angular-animate.min.js',
        'node_modules/angular-jwt/dist/angular-jwt.js',
        'node_modules/angular-lock/dist/angular-lock.js',
        'node_modules/angular-messages/angular-messages.min.js',
        'node_modules/angular-route/angular-route.min.js',
        'node_modules/angular-sanitize/angular-sanitize.min.js',
    ])
        .pipe(concat('bai-angular.js'))
        .pipe(gulp.dest('js'));
});

gulp.task('master-external-js', function () {
    return gulp.src([
        'node_modules/angular-busy/dist/angular-busy.min.js',
        'node_modules/angular-toastr/dist/angular-toastr.tpls.min.js',
        'node_modules/angular-ui-bootstrap/dist/ui-bootstrap-tpls.js',
        'node_modules/angular-xeditable/dist/js/xeditable.min.js',
        'node_modules/bootstrap/dist/js/bootstrap.min.js',
        'node_modules/metismenu/dist/metisMenu.min.js',
        'node_modules/moment/min/moment.min.js',
        'node_modules/moment/locale/es.js',
        'node_modules/angular-moment/angular-moment.min.js',
        'node_modules/lodash/lodash.min.js',
        'node_modules/ui-select/dist/select.min.js'
    ])
        .pipe(concat('bai-external.js'))
        .pipe(gulp.dest('js'));
});

gulp.task('master-external-css', function () {
    return gulp.src([
        'node_modules/bootstrap/dist/css/bootstrap.min.css',
        'node_modules/angular-busy/dist/angular-busy.min.css',
        'node_modules/angular-toastr/dist/angular-toastr.css',
        'node_modules/angular-xeditable/dist/css/xeditable.min.css',
        'node_modules/font-awesome/css/font-awesome.min.css',
        'node_modules/metismenu/dist/metisMenu.min.css',
        'node_modules/ui-select/dist/select.min.css',
    ])
        .pipe(concat('bai-external.css'))
        .pipe(gulp.dest('css'));
});

gulp.task('uglify', function () {
    return gulp.src([
        './js/bai-fab*.js',
        './js/bai-pv*.js',
        './js/bai-log*.js'
    ], { base: './' })
      .pipe(ngAnnotate({
          add: true,
          remove: true
      }))
      .pipe(uglify())
      .pipe(gulp.dest(''));
});

gulp.task('rev', function () {
    return gulp.src([
         './js/bai-fab*.js',
         './js/bai-pv*.js',
         './js/bai-log*.js'
    ], { base: './' })
      .pipe(rev())
      .pipe(gulp.dest('./'))
      .pipe(rev.manifest())
      .pipe(gulp.dest('./'));
});

gulp.task('revreplace', function () {
    var manifest = gulp.src('./rev-manifest.json', { base: './' });
    return gulp.src([
        './bairoletto/fabrica/fabrica.html',
        './bairoletto/puntoventa/puntoventa.html',
        './bairoletto/login/login.html'
    ], { base: './' })
      .pipe(revReplace({ manifest: manifest, replaceInExtensions: ['.js', '.css', '.html'] }))
      .pipe(gulp.dest('./'));
});

gulp.task('clean', function () {
    return del([
        './css/bai*.css',
        './js/bai*.js'
    ], { base: './' });
});