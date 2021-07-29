@Put
@Regression
Feature: Put Pet

Scenario: 1. Validate Pet Put Request
	Given I have free API with swagger
	When I send put request 
	Then I send get request
	And I see Pet details