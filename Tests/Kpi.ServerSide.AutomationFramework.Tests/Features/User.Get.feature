@Get
@Regression
Feature: Get User by Token
	Story:

@Smoke
Scenario: 1. Validate Get User by Token with valid data
	Given I have registered user
	When I get User by providing token
	Then I see returned Assignment details which are equal with created