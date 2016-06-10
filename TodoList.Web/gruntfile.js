/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "src/lib",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        },
        htmlConvert: {
            options: {
            
            },
            mytemplate: {
                src: ['src/**/index.html'],
                dest: 'src/js/templates.js'
            }
        },
        copy: {
            js: {
                cwd: "src/js/",
                src: "*",
                dest: 'dist/js/',
                expand: true
            },
            css: {
                src: "src/css/todolist.min.css",
                dest: 'dist/css/',
                flatten: true,
                expand: true
            },
            img: {
                cwd: "src/img/",
                src: "*",
                dest: 'dist/img/',
                expand: true
            },
            html: {
                src: "src/test.html",
                dest: "dist/",
                flatten: true,
                expand: true
            },
            lib: {
                cwd: "src/lib/",
                src: "**",
                dest: 'dist/lib/',
                expand: true
            }
        },
        clean: {
            dist: ["dist/*"]
        },
        uglify: {
            dist: {
                options: {
                    mangle: false,
                    compress: true
                },
                files: {
                    "src/js/todolist.min.js": [
                        "src/js/templates.js",
                        "src/js/todolist.paths.js",
                        "src/js/todolist.js"
                    ]
                }
            }
        },
        cssmin: {
            options: {
                shorthandCompacting: false,
                roundingPrecision: -1
            },
            target: {
                files: {
                    "src/css/todolist.min.css": [
                        "src/css/todolist.css"
                    ]
                }
            }
        }
    });
    grunt.registerTask("default", [
        "bower:install"
    ]);
    grunt.loadNpmTasks("grunt-bower-task");
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-html-convert');
    //    grunt.loadNpmTasks('grunt-contrib-htmlmin');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask("build", [
        "bower:install",
        "htmlConvert",
        "uglify:dist",
        "cssmin",
        "clean:dist",
        "copy"
    ]);


};