Feature: API_Tests
	Simple API test to validate its response

@mytag
Scenario: Validate Create User API Response
	Given I execute POST create user API
	And I validate status code '201' 
	Then I validate create user API response details

Scenario: Validate Get User Details API Response
	Given I execute GET user details API
	And I validate status code '200'