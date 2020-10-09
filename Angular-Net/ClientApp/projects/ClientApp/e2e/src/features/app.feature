Feature: Go to the Default Page
    Display the page works! message

    Scenario: Default Page
        Given I am on the Default page
        When I view the Default page
        Then I should see the redirected text "home works!"