import { Before, Given, Then, When } from 'cucumber';
import { expect } from 'chai';

import { HomePage } from '../pages/home.po';

let page: HomePage;

Before(() => {
    page = new HomePage();
});

Given('I am on the Home page', async () => {
    await page.navigateTo();
});
When('I view the Home page', async () => {});
Then('I should see the text "home works!"', async () => {
    expect(await page.getText('parent')).to.equal('home works!');
});