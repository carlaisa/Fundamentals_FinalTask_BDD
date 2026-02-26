Feature: User Login

  Scenario: Login form with empty credentials
    Given the user is in the login page
    And the user types an invalid username
    And the user types an invalid password
    When the user clears the username field
    And the user clears the password field
    And the user clicks the login button
    Then an error message should be displayed: "Username is required"

    Scenario: Login form with credentials by passing username
    Given the user is in the login page
    And the user types an invalid username
    And the user types a valid password
    When the user clears the password field
    And the user clicks the login button
    Then an error message should be displayed: "Password is required"

    Scenario: Login form with credentials by passing username and password
    Given the user is in the login page
    And  the user types a valid username
    And the user types a valid password
    When the user clicks the login button
    Then the user should see the title: "Swag Labs" in the dashboard

