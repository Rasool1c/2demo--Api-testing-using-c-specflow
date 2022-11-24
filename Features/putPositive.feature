Feature: 3.putPostive

 Sending a PUT request and validating the response
 @3
Scenario: PUT1
	Given I given valid uri
	When I enter valid endpoint and choose http method
	And I enter the valid body and format details
	And I excute the request
	Then I parse the response and validate it
