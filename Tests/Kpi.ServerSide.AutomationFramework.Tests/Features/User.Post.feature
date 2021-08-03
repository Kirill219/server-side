@Post
@Regression
Feature: User Registration
	Story:

@Smoke
Scenario: 1. Validate User registration with with provided model
	Given I have user credentials
	When I send register request with provided model
	Then I see generated authorization token