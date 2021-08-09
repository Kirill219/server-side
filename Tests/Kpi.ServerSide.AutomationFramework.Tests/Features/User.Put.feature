@Put
@Regression
Feature: Update User by authorization token
	Story:

@Smoke
Scenario: 1. Validate Update User by by authorization token with valid data
	Given I have registered user
	When I send update request with new user name
	Then I see updated user in get request

Scenario: 1. Validate Update User by by authorization token with invalid data
	Given I have invalid authorization token
	When I send update request with invalid token
	Then I see Unauthorized status code