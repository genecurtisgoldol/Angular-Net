import { Before, Given, Then, When } from 'cucumber';
import { expect } from 'chai';

import { AppPage } from '../pages/app.po';

let page: AppPage;

Before(() => {
    page = new AppPage();
});

Given('I am on the Default page', async () => {
    await page.navigateTo();
});
When('I view the Default page', async () => {});
Then('I should see the redirected text "home works!"', async () => {
    expect(await page.getText('parent')).to.equal('home works!');
});