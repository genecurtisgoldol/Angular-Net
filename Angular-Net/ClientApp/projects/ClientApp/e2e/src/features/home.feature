Feature: Go to the Home Page
    Display the page works! message

    Scenario: Home Page
        Given I am on the Home page
        When I view the Home page
        Then I should see the text "home works!"