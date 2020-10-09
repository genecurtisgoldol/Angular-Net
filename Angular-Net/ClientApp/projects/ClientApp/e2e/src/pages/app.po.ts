import { browser, by, element, WebElementPromise } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get(browser.baseUrl) as Promise<any>;
  }
  getText(text: string): Promise<string> {
    try {
      return browser.findElement(by.id(text)).getText() as Promise<string>;
    }
    catch {
      return Promise.resolve("error");
    }
  }
}
