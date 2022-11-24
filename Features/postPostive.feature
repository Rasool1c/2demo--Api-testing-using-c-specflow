Feature: 1.postPostive
 Sending a POST request and validating the response

 @1
Scenario: POST1
	Given I given valid uri and endpoint
	When I choose the respective http method type as post
	And I enter the body and format details
	Then I excute the request and parse the response
	And I validate the response