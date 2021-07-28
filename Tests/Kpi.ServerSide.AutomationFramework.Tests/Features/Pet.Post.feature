@Post
@Pet
@Regression
Feature: Post Pet
	
Scenario: 1. Validate Post Pet
	Given I have free API with swagger
	When I send pet creation request 
	Then I send get request
	And I see created pet