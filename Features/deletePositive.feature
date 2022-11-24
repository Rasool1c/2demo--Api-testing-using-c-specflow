Feature: 4.deletePositive

Sending a DELETE request and validating the response
@4
Scenario: DELETE1
	Given I give A valid uri
	When I enter S valid endpoint and choose http method
	And I excute request
	Then I validate the response using get method
