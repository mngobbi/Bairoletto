﻿/// <binding BeforeBuild='default' />

var gulp = require('gulp');
var concat = require('gulp-concat');
var ngAnnotate = require('gulp-ng-annotate');
var uglify = require('gulp-uglify');
var merge = require('merge-stream');
//var runSequence = require('run-sequence');

gulp.task('default', [
    'master-angular-js',
    'master-external-js',
    'master-external-css',
    'fonts'], function () {
    });

gulp.task('fonts', function () {
    return gulp.src([
        'node_modules/font-awesome/fonts/fontawesome-*',
        'node_modules/bootstrap/fonts/glyphicons-*'
    ])
        .pipe(gulp.dest('fonts'));
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
