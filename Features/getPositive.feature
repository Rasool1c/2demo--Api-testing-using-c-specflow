Feature: 2.getPositive

Sending a POST request and validating the response

@2
Scenario: GET1
	Given I given valid uri and endpoints
	When I choose the respective http method type as get
	And i excute the request
	Then i parse and validate the response