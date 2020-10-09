// @ts-check
// Protractor configuration file, see link for more information
// Test Framework using Cucumber
// https://github.com/angular/protractor/blob/master/lib/config.ts
/**
 * @type { import("protractor").Config }
 */

exports.config = {
  allScriptsTimeout: 60000,
  specs: ['src/features/**/*.feature'],
  capabilities: {
    browserName: 'chrome'
  },
  directConnect: true,
  baseUrl: 'http://localhost:4200/',
  framework: 'custom',
  frameworkPath: require.resolve('protractor-cucumber-framework'),
    cucumberOpts: {
        require: ['src/steps/**/*.steps.ts']
    },
    onPrepare() {
        require('ts-node').register({
            project: require('path').join(__dirname, './tsconfig.json')
        });
    }
};