@Post
@User
@Regression
Feature: Post User
	
Scenario: 1. Validate User creation with empty model
	Given I have free API with swagger
	When I send the pet creation request with empty model
	Then I see created pet in the get response
	
Scenario: 2. Validate User creation with null model
	Given I have free API with swagger
	When I send the pet creation request with null model
	Then I see 'UnsupportedMediaType' status code request
