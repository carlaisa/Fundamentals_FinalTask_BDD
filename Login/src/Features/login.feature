Feature: User Login

  Scenario: Login form with empty credentials
    Given the user is in the login page
    And the user types the username
    And the user types the password
    When the user clears the username field
    And the user clears the password field
    And clicks the login button
    Then an error message should be displayed: "Username is required"

    Scenario: Login form with credentials by passing username
    Given the user is in the login page
    And the user types any credentials in username field
    And the user types the password
    When the user clear the password field
    And the user hit the login button

    Scenario: Login form with credentials by passing username and password
    Given the user is in the login page
    And  the user types a valid username
    And the user types a valid password
    When the user clicks the login button
    Then the user should see the title: "Swag Labs" in the dashboard

