@Delete
@Pet
@Regression
Feature: Delete Pet

Scenario: 1. Delete Pet by id
	Given I create Pet
	When I send delete request
	Then I see 0 id in pet response

Scenario Outline: 2. Delete Pet by wrong id
	Given I create Pet
	When I send delete request to <wrongId> wrong Id
	Then I see null in response

	Examples: 
	| wrongId    |
	| -1         |
	| 0          |
	| -999999999 |

