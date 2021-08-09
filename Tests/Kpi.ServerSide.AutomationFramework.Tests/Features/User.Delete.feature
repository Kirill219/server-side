@Delete
@Regression
Feature: Delete User by authorization token
	Story:

@Smoke
Scenario: 1. Validate Delete User by authorization token with valid data
	Given I have registered user
	When I send delete request with provided user authorization token
	Then I see OK status code